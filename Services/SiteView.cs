using System.Text.Json;
using Microsoft.Extensions.Options;

namespace MahapatraArts.Services;

public sealed class SiteOptions
{
    public const string Section = "Site";
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public string WhatsApp { get; set; } = "";
    public string Address { get; set; } = "Mahapatra Handicrafts Emporium, Bhubaneswar, Odisha, India";
    public string PaymentUrl { get; set; } = "";
    public double MapLat { get; set; } = 20.2961;
    public double MapLng { get; set; } = 85.8245;
}

public sealed class SiteView
{
    private readonly HttpContext _http;
    private readonly IReadOnlyDictionary<string, decimal> _rates;

    public SiteView(IHttpContextAccessor accessor, IOptions<SiteOptions> options, IConfiguration configuration)
    {
        _http = accessor.HttpContext ?? throw new InvalidOperationException("SiteView requires an HTTP request.");
        Options = options.Value;
        Culture = _http.Items["culture"] as string ?? "en";
        var cookie = _http.Request.Cookies["mahapatra_cur"];
        Currency = cookie is not null && Money.IsValid(cookie) ? cookie.ToUpperInvariant() : "INR";
        _rates = ReadRates(configuration);
    }

    public SiteOptions Options { get; }
    public string Culture { get; }
    public string Currency { get; }
    public string HtmlLang => Culture;
    public string OgLocale => Culture switch
    {
        "fr" => "fr_FR",
        "de" => "de_DE",
        "ja" => "ja_JP",
        _ => "en_IN"
    };

    public string T(string key) => UiText.Get(Culture, key);
    public string Href(string path) => Paths.WithCulture(Culture, path);

    public string Absolute(string path)
    {
        var request = _http.Request;
        return $"{request.Scheme}://{request.Host}{Href(path)}";
    }

    public bool IsCurrent(string path)
    {
        var current = _http.Request.Path.Value ?? "/";
        if (current.Length > 1 && current.EndsWith('/')) current = current.TrimEnd('/');
        if (path == "/") return current == "/";
        return current.Equals(path, StringComparison.OrdinalIgnoreCase)
            || current.StartsWith(path + "/", StringComparison.OrdinalIgnoreCase);
    }

    public string CurrencyLink(string code)
    {
        var path = _http.Items["publicPath"] as string ?? _http.Request.Path.Value ?? "/";
        var pairs = _http.Request.Query
            .Where(pair => !pair.Key.Equals("cur", StringComparison.OrdinalIgnoreCase))
            .SelectMany(pair => pair.Value.Select(value => new KeyValuePair<string, string?>(pair.Key, value)))
            .ToList();
        pairs.Add(new KeyValuePair<string, string?>("cur", code));
        return path + QueryString.Create(pairs).Value;
    }

    public string Switch(string culture)
    {
        var path = _http.Request.Path.Value ?? "/";
        var query = _http.Request.QueryString.Value ?? "";
        return Paths.WithCulture(culture, path) + query;
    }

    public string Format(decimal? inr) => Money.Format(inr, Currency, _rates, T("price.poa"));

    public string? WhatsAppHref(string message)
    {
        var digits = new string((Options.WhatsApp ?? "").Where(char.IsDigit).ToArray());
        if (digits.Length < 8) return null;
        return "https://wa.me/" + digits + "?text=" + Uri.EscapeDataString(message);
    }

    public string MapEmbed()
    {
        var lat = Options.MapLat.ToString(CultureInfo.InvariantCulture);
        var lng = Options.MapLng.ToString(CultureInfo.InvariantCulture);
        var south = (Options.MapLat - 0.08).ToString(CultureInfo.InvariantCulture);
        var north = (Options.MapLat + 0.08).ToString(CultureInfo.InvariantCulture);
        var west = (Options.MapLng - 0.08).ToString(CultureInfo.InvariantCulture);
        var east = (Options.MapLng + 0.08).ToString(CultureInfo.InvariantCulture);
        return $"https://www.openstreetmap.org/export/embed.html?bbox={west}%2C{south}%2C{east}%2C{north}&layer=mapnik&marker={lat}%2C{lng}";
    }

    public string MapLink()
    {
        var lat = Options.MapLat.ToString(CultureInfo.InvariantCulture);
        var lng = Options.MapLng.ToString(CultureInfo.InvariantCulture);
        return $"https://www.openstreetmap.org/?mlat={lat}&mlon={lng}#map=13/{lat}/{lng}";
    }

    public string JsonLd(string path, string title, string description)
    {
        var graph = new Dictionary<string, object?>
        {
            ["@context"] = "https://schema.org",
            ["@graph"] = new object[]
            {
                new Dictionary<string, object?>
                {
                    ["@type"] = "WebSite",
                    ["name"] = "Mahapatra Arts | Master Stone Sculptor | National Awardee",
                    ["url"] = Absolute("/"),
                    ["description"] = description,
                    ["inLanguage"] = new[] { "en", "fr", "de", "ja" },
                    ["potentialAction"] = new Dictionary<string, object?>
                    {
                        ["@type"] = "SearchAction",
                        ["target"] = Absolute("/search") + "?q={query}",
                        ["query-input"] = "required name=query"
                    }
                },
                new Dictionary<string, object?>
                {
                    ["@type"] = "Person",
                    ["name"] = "Guru Ramakanta Mahapatra",
                    ["alternateName"] = "Ramakanta Mahapatra",
                    ["birthDate"] = "1969-12-03",
                    ["birthPlace"] = new Dictionary<string, object?>
                    {
                        ["@type"] = "Place",
                        ["name"] = "Puri, Odisha, India"
                    },
                    ["jobTitle"] = new[] { "Stone Sculptor", "Temple Architect", "Master Craftsman", "Teacher" },
                    ["award"] = "National Award for Master Craftsperson (2005)",
                    ["nationality"] = "Indian",
                    ["url"] = Absolute("/biography"),
                    ["knowsAbout"] = new[] { "Stone carving", "Temple construction", "Multi-coloured stone patchwork" },
                    ["worksFor"] = new Dictionary<string, object?>
                    {
                        ["@type"] = "Organization",
                        ["name"] = "Mahapatra Handicrafts Emporium",
                        ["address"] = Options.Address
                    }
                },
                new Dictionary<string, object?>
                {
                    ["@type"] = "BreadcrumbList",
                    ["itemListElement"] = new object[]
                    {
                        new Dictionary<string, object?>
                        {
                            ["@type"] = "ListItem",
                            ["position"] = 1,
                            ["name"] = "Mahapatra Arts",
                            ["item"] = Absolute("/")
                        },
                        new Dictionary<string, object?>
                        {
                            ["@type"] = "ListItem",
                            ["position"] = 2,
                            ["name"] = title,
                            ["item"] = Absolute(path)
                        }
                    }
                }
            }
        };
        return JsonSerializer.Serialize(graph);
    }

    private static IReadOnlyDictionary<string, decimal> ReadRates(IConfiguration configuration)
    {
        var rates = new Dictionary<string, decimal>(Money.DefaultRates);
        var section = configuration.GetSection("CurrencyRates");
        foreach (var child in section.GetChildren())
        {
            if (decimal.TryParse(child.Value, NumberStyles.Number, CultureInfo.InvariantCulture, out var rate) && rate > 0)
                rates[child.Key.ToUpperInvariant()] = rate;
        }
        return rates;
    }
}
