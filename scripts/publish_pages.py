#!/usr/bin/env python3
"""Mirror a running Mahapatra Arts site into a GitHub Pages tree.

Usage:
  python3 scripts/publish_pages.py OUT ORIGIN BASE PUBLIC_HOST
Example:
  python3 scripts/publish_pages.py /tmp/site http://127.0.0.1:47291 /mahapatraArts https://rajeev812.github.io
"""
import os
import re
import sys
import urllib.error
import urllib.request
from html.parser import HTMLParser
from urllib.parse import urljoin, urlparse

OUT, ORIGIN, BASE, PUBLIC_HOST = sys.argv[1:5]
ORIGIN = ORIGIN.rstrip("/")
PUBLIC = PUBLIC_HOST.rstrip("/") + BASE
os.makedirs(OUT, exist_ok=True)


class LinkParser(HTMLParser):
    def __init__(self):
        super().__init__()
        self.links = []

    def handle_starttag(self, tag, attrs):
        data = dict(attrs)
        for key in ("href", "src"):
            if data.get(key):
                self.links.append(data[key])


def fetch(url):
    req = urllib.request.Request(url, headers={"User-Agent": "mahapatra-pages"})
    with urllib.request.urlopen(req, timeout=60) as res:
        return res.read(), res.headers.get_content_type()


def dest_for(path):
    path = path.split("?", 1)[0].split("#", 1)[0]
    if path.endswith("/"):
        path += "index.html"
    elif "." not in os.path.basename(path):
        path = path.rstrip("/") + "/index.html"
    return path.lstrip("/")


def rewrite(text):
    text = text.replace(ORIGIN, PUBLIC)

    def repl(match):
        attr, quote, url = match.group(1), match.group(2), match.group(3)
        if url == BASE or url.startswith(BASE + "/"):
            return match.group(0)
        return f"{attr}={quote}{BASE}{url}{quote}"

    text = re.sub(r"\b(href|src|action)=(\"|')(/[^\"']*)\2", repl, text)

    def prefix_url(match):
        url = match.group(2)
        if url == BASE or url.startswith(BASE + "/"):
            return match.group(0)
        return match.group(1) + BASE + url

    text = re.sub(r"(url\((?:['\"]|&#x27;|&#39;))(/[^)'\"&]+)", prefix_url, text)
    text = re.sub(r"(?m)^(Disallow: )(/.*)$", lambda m: m.group(1) + BASE + m.group(2), text)

    def prefix_json(match):
        url = match.group(2)
        if url == BASE or url.startswith(BASE + "/"):
            return match.group(0)
        return match.group(1) + BASE + url + '"'

    text = re.sub(r'("(?:src|start_url)"\s*:\s*")(/[^"]*)"', prefix_json, text)
    return text


seen = set()
queue = []


def enqueue(raw, base_url):
    abs_url = urljoin(base_url, raw)
    parsed = urlparse(abs_url)
    origin = urlparse(ORIGIN)
    if parsed.netloc and parsed.netloc != origin.netloc:
        return
    if parsed.scheme not in ("", "http"):
        return
    path = parsed.path or "/"
    if path.startswith(BASE):
        path = path[len(BASE):] or "/"
    if path in seen:
        return
    seen.add(path)
    queue.append(ORIGIN + path)


body, _ = fetch(ORIGIN + "/sitemap.xml")
for loc in re.findall(r"<loc>([^<]+)</loc>", body.decode()):
    enqueue(loc, ORIGIN + "/")
for extra in ("/css/site.css", "/js/site.js", "/favicon.ico", "/favicon-32.png", "/favicon-192.png", "/favicon-512.png", "/apple-touch-icon.png", "/brand/logo.jpg", "/site.webmanifest", "/robots.txt", "/sitemap.xml"):
    enqueue(extra, ORIGIN + "/")

while queue:
    url = queue.pop(0)
    path = urlparse(url).path or "/"
    try:
        data, ctype = fetch(url)
    except urllib.error.HTTPError as exc:
        print(f"skip {path} {exc.code}")
        continue
    rel = dest_for(path)
    target = os.path.join(OUT, rel)
    os.makedirs(os.path.dirname(target), exist_ok=True)
    textish = ctype.startswith("text/") or ctype in (
        "application/javascript",
        "application/xml",
        "application/manifest+json",
        "image/svg+xml",
    )
    if textish:
        text = data.decode("utf-8", "replace")
        if "html" in ctype:
            parser = LinkParser()
            parser.feed(text)
            for link in parser.links:
                enqueue(link, url)
            for link in re.findall(r"url\((?:['\"]|&#x27;|&#39;)?(/[^)'\"&]+)", text):
                enqueue(link, url)
        data = rewrite(text).encode("utf-8")
    with open(target, "wb") as handle:
        handle.write(data)
    print(rel)

with open(os.path.join(OUT, ".nojekyll"), "w", encoding="utf-8") as handle:
    handle.write("")
print(f"wrote {OUT}")
