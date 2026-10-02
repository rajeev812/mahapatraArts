using System.Text.RegularExpressions;

namespace MahapatraArts.Services;

public sealed class Catalog
{
    private readonly List<SearchDoc> _docs;

    public Catalog()
    {
        Works = ContentWorks.Works;
        Awards = ContentWorks.Awards;
        Biography = ContentBiography.Sections;
        Timeline = ContentBiography.Timeline;
        Destinations = ContentWorld.Destinations;
        Courses = ContentWorld.Courses;
        Press = ContentWorld.Press;
        Rooms = ContentWorld.Rooms;
        Stations = ContentWorld.Stations;
        Products = ContentStore.Products;
        _docs = BuildDocs();
    }

    public IReadOnlyList<Work> Works { get; }
    public IReadOnlyList<Award> Awards { get; }
    public IReadOnlyList<BioSection> Biography { get; }
    public IReadOnlyList<Milestone> Timeline { get; }
    public IReadOnlyList<Destination> Destinations { get; }
    public IReadOnlyList<Course> Courses { get; }
    public IReadOnlyList<PressItem> Press { get; }
    public IReadOnlyList<TourRoom> Rooms { get; }
    public IReadOnlyList<Station> Stations { get; }
    public IReadOnlyList<Product> Products { get; }

    public static readonly string[] WorkCategories = ["temple", "idols", "murals", "international", "rare", "architecture"];
    public static readonly string[] ProductCategories = ["ganesha", "krishna", "decor", "custom", "garden", "museum", "premium", "panels"];

    public Work? FindWork(string? slug) => Works.FirstOrDefault(w => w.Slug == slug);
    public Product? FindProduct(string? slug) => Products.FirstOrDefault(p => p.Slug == slug);
    public Award? FindAward(string? slug) => Awards.FirstOrDefault(a => a.Slug == slug);

    public IReadOnlyList<Work> FilterWorks(string? kind) =>
        string.IsNullOrWhiteSpace(kind) || kind == "all"
            ? Works
            : Works.Where(w => w.Category == kind).ToList();

    public IReadOnlyList<Product> FilterProducts(string? kind) =>
        string.IsNullOrWhiteSpace(kind) || kind == "all"
            ? Products
            : Products.Where(p => p.Category == kind).ToList();

    public IReadOnlyList<Work> RelatedWorks(Work work, int take = 3) =>
        Works.Where(w => w.Slug != work.Slug && w.Category == work.Category)
            .Concat(Works.Where(w => w.Slug != work.Slug))
            .Distinct()
            .Take(take)
            .ToList();

    public IReadOnlyList<Product> RelatedProducts(Product product, int take = 3) =>
        Products.Where(p => p.Slug != product.Slug && p.Category == product.Category)
            .Concat(Products.Where(p => p.Slug != product.Slug))
            .Distinct()
            .Take(take)
            .ToList();

    public IReadOnlyList<string> IndexablePaths()
    {
        var paths = new List<string>
        {
            "/", "/biography", "/timeline", "/masterpieces", "/awards", "/padma-shri",
            "/global-projects", "/academy", "/store", "/media", "/workshops",
            "/workshop-experience", "/virtual-museum", "/contact", "/donate", "/privacy"
        };
        paths.AddRange(Works.Select(w => "/masterpieces/" + w.Slug));
        paths.AddRange(Products.Select(p => "/store/" + p.Slug));
        return paths;
    }

    public IReadOnlyList<SearchHit> Search(string? query, string? culture)
    {
        culture ??= "en";
        if (string.IsNullOrWhiteSpace(query)) return [];
        var raw = query.Trim().ToLowerInvariant();
        if (raw.Length < 2) return [];
        var terms = Expand(Tokenize(raw)).ToList();
        var hits = new List<SearchHit>();
        foreach (var doc in _docs)
        {
            var title = doc.Title.Of(culture);
            var titleL = title.ToLowerInvariant();
            var score = 0;
            if (titleL.Contains(raw, StringComparison.Ordinal)) score += 14;
            if (doc.Haystack.Contains(raw, StringComparison.Ordinal)) score += 6;
            foreach (var term in terms)
            {
                if (term.Length < 2) continue;
                if (titleL.Contains(term, StringComparison.Ordinal)) score += 4;
                else if (doc.Haystack.Contains(term, StringComparison.Ordinal)) score += 2;
            }
            if (score <= 0) continue;
            hits.Add(new SearchHit(doc.Kind, doc.Path, title, Excerpt(doc.Excerpt.Of(culture)), score));
        }
        return hits.OrderByDescending(h => h.Score).ThenBy(h => h.Title, StringComparer.CurrentCulture).Take(30).ToList();
    }

    public IReadOnlyList<string> Interpret(string? query)
    {
        if (string.IsNullOrWhiteSpace(query)) return [];
        return Expand(Tokenize(query.Trim().ToLowerInvariant()))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Take(10)
            .ToList();
    }

    private static IEnumerable<string> Tokenize(string raw)
    {
        yield return raw;
        foreach (Match match in Regex.Matches(raw, @"[\p{L}\p{N}]{2,}"))
            yield return match.Value;
    }

    private static readonly string[][] Groups =
    [
        ["ganesha", "ganesh", "ganapati", "vinayaka", "ガネーシャ"],
        ["krishna", "venugopala", "govardhana", "クリシュナ"],
        ["jagannath", "ジャガンナート"],
        ["japan", "japon", "ashoka", "ashokan", "日本", "アショーカ"],
        ["singapore", "singapour", "シンガポール"],
        ["temple", "mandapam", "shrine", "寺院"],
        ["award", "padma", "national", "prix", "国家賞", "顕彰"],
        ["workshop", "academy", "course", "講習", "学院"],
        ["gate", "torana", "門"],
        ["patchwork", "パッチワーク"],
        ["konark", "コナーラク"],
        ["sculpture", "sculptor", "carving", "石彫"]
    ];

    private static IEnumerable<string> Expand(IEnumerable<string> tokens)
    {
        var list = tokens.Where(t => !string.IsNullOrWhiteSpace(t)).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        foreach (var group in Groups)
        {
            var hit = list.Any(token => group.Any(member =>
                token.Equals(member, StringComparison.OrdinalIgnoreCase)
                || (member.Length >= 4 && token.Contains(member, StringComparison.OrdinalIgnoreCase))));
            if (hit)
            {
                foreach (var member in group) list.Add(member);
            }
        }
        return list;
    }

    private static string Excerpt(string text)
    {
        var flat = Regex.Replace(text, @"\s+", " ").Trim();
        return flat.Length <= 180 ? flat : flat[..177] + "…";
    }

    private List<SearchDoc> BuildDocs()
    {
        var docs = new List<SearchDoc>();
        void Add(string kind, string path, LStr title, LStr excerpt, params LStr[] extra) =>
            docs.Add(new SearchDoc(kind, path, title, excerpt, Hay(title, excerpt, extra)));

        Add("pages", "/biography", Ui("bio.title"), Ui("bio.lede"));
        foreach (var section in Biography)
            Add("pages", "/biography#" + section.Id, section.Heading, section.Body);
        foreach (var mile in Timeline)
            Add("pages", "/timeline", mile.Title, mile.Body, new LStr(mile.Year));
        foreach (var work in Works)
            Add("works", "/masterpieces/" + work.Slug, work.Title, work.Story, work.Materials, work.Dimensions, work.Location, new LStr(work.Stone, work.Category));
        foreach (var award in Awards)
            Add("awards", "/awards#" + award.Slug, award.Title, award.Body, new LStr(award.Year));
        foreach (var place in Destinations)
        {
            foreach (var project in place.Projects)
                Add("projects", "/global-projects#" + place.Id, project.Title, project.History, place.Country, new LStr(project.Year));
        }
        foreach (var course in Courses)
            Add("pages", "/academy#" + course.Id, course.Title, course.Summary, course.Duration);
        foreach (var product in Products)
            Add("products", "/store/" + product.Slug, product.Title, product.Story, product.Dimensions, new LStr(product.Stone, product.Category));
        foreach (var item in Press)
            Add("press", "/media#" + item.Id, item.Title, item.Body, item.Kind);
        Add("pages", "/padma-shri", Ui("padma.title"), Ui("padma.lede"), Ui("padma.note"));
        Add("pages", "/workshops", Ui("work.title"), Ui("work.lede"));
        Add("pages", "/virtual-museum", Ui("tour.title"), Ui("tour.lede"));
        Add("pages", "/workshop-experience", Ui("exp.title"), Ui("exp.lede"));
        Add("pages", "/contact", Ui("contact.title"), Ui("contact.lede"));
        Add("pages", "/donate", Ui("donate.title"), Ui("donate.lede"));
        Add("pages", "/store", Ui("store.title"), Ui("store.lede"));
        Add("pages", "/masterpieces", Ui("gal.title"), Ui("gal.lede"));
        return docs;
    }

    private static LStr Ui(string key) => new(UiText.Get("en", key), UiText.Get("fr", key), UiText.Get("de", key), UiText.Get("ja", key));

    private static string Hay(LStr title, LStr excerpt, params LStr[] extra)
    {
        var parts = new List<string> { title.AllText(), excerpt.AllText() };
        parts.AddRange(extra.Select(item => item.AllText()));
        return string.Join(' ', parts).ToLowerInvariant();
    }

    private sealed record SearchDoc(string Kind, string Path, LStr Title, LStr Excerpt, string Haystack);
}
