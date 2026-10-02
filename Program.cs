using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);
builder.Services.AddResponseCompression(options => options.EnableForHttps = true);
builder.Services.Configure<SiteOptions>(builder.Configuration.GetSection(SiteOptions.Section));
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "mahapatra.session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.IdleTimeout = TimeSpan.FromHours(12);
});
builder.Services.AddRazorPages();
builder.Services.AddSingleton<Catalog>();
builder.Services.AddSingleton<EnquiryService>();
builder.Services.AddSingleton<CartService>();
builder.Services.AddSingleton<MediaLibrary>();
builder.Services.AddScoped<SiteView>();

var app = builder.Build();
var cultures = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "en", "fr", "de", "ja" };

app.UseResponseCompression();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    var original = context.Request.Path.Value ?? "/";
    context.Items["publicPath"] = original;
    var segments = original.Split('/', StringSplitOptions.RemoveEmptyEntries);
    var culture = "en";
    if (segments.Length > 0 && cultures.Contains(segments[0]))
    {
        culture = segments[0].ToLowerInvariant();
        if (!string.Equals(segments[0], culture, StringComparison.Ordinal))
        {
            var lower = "/" + culture + (segments.Length > 1 ? "/" + string.Join('/', segments.Skip(1)) : "");
            context.Response.Redirect(lower + context.Request.QueryString.Value);
            return;
        }
        var rest = string.Join('/', segments.Skip(1));
        context.Request.Path = string.IsNullOrEmpty(rest) ? "/" : "/" + rest;
    }
    context.Items["culture"] = culture;

    if (context.Request.Query.ContainsKey("cur"))
    {
        var code = context.Request.Query["cur"].ToString().ToUpperInvariant();
        if (Money.IsValid(code))
        {
            context.Response.Cookies.Append("mahapatra_cur", code, new CookieOptions
            {
                MaxAge = TimeSpan.FromDays(180),
                IsEssential = true,
                SameSite = SameSiteMode.Lax,
                HttpOnly = false,
                Path = "/"
            });
        }
        var pairs = context.Request.Query
            .Where(pair => !pair.Key.Equals("cur", StringComparison.OrdinalIgnoreCase))
            .SelectMany(pair => pair.Value.Select(value => new KeyValuePair<string, string?>(pair.Key, value)));
        context.Response.Redirect(original + QueryString.Create(pairs).Value);
        return;
    }

    context.Response.Headers["X-Content-Type-Options"] = "nosniff";
    context.Response.Headers["Referrer-Policy"] = "strict-origin-when-cross-origin";
    context.Response.Headers["X-Frame-Options"] = "SAMEORIGIN";
    context.Response.Headers["Permissions-Policy"] = "camera=(), microphone=(), geolocation=()";
    await next();
});

app.UseStatusCodePagesWithReExecute("/not-found");
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.MapRazorPages();

app.MapGet("/health", () => Results.Text("ok", "text/plain"));
app.MapGet("/robots.txt", (HttpContext context) =>
{
    var host = $"{context.Request.Scheme}://{context.Request.Host}";
    var body = $"""
        User-agent: *
        Allow: /
        Disallow: /store/cart
        Disallow: /store/quotation
        Disallow: /search
        Disallow: /fr/store/cart
        Disallow: /de/store/cart
        Disallow: /ja/store/cart
        Disallow: /fr/store/quotation
        Disallow: /de/store/quotation
        Disallow: /ja/store/quotation
        Disallow: /fr/search
        Disallow: /de/search
        Disallow: /ja/search

        Sitemap: {host}/sitemap.xml
        """;
    return Results.Text(body, "text/plain", Encoding.UTF8);
});

app.MapGet("/sitemap.xml", (HttpContext context, Catalog catalog) =>
{
    var host = $"{context.Request.Scheme}://{context.Request.Host}";
    var sb = new StringBuilder();
    sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
    sb.Append("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\" xmlns:xhtml=\"http://www.w3.org/1999/xhtml\">");
    foreach (var path in catalog.IndexablePaths())
    {
        foreach (var culture in Paths.Cultures)
        {
            var loc = host + Paths.WithCulture(culture, path);
            sb.Append("<url><loc>").Append(WebUtility.HtmlEncode(loc)).Append("</loc>");
            foreach (var alt in Paths.Cultures)
            {
                var href = host + Paths.WithCulture(alt, path);
                sb.Append("<xhtml:link rel=\"alternate\" hreflang=\"").Append(alt)
                    .Append("\" href=\"").Append(WebUtility.HtmlEncode(href)).Append("\"/>");
            }
            sb.Append("<xhtml:link rel=\"alternate\" hreflang=\"x-default\" href=\"")
                .Append(WebUtility.HtmlEncode(host + Paths.WithCulture("en", path)))
                .Append("\"/>");
            sb.Append("</url>");
        }
    }
    sb.Append("</urlset>");
    return Results.Text(sb.ToString(), "application/xml", Encoding.UTF8);
});

app.Run();

public partial class Program;
