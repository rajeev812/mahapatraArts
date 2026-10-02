namespace MahapatraArts.Services;

public static class Paths
{
    public static readonly string[] Cultures = ["en", "fr", "de", "ja"];

    public static string WithCulture(string? culture, string path)
    {
        if (string.IsNullOrWhiteSpace(path)) path = "/";
        if (!path.StartsWith('/')) path = "/" + path;
        if (path.Length > 1 && path.EndsWith('/')) path = path.TrimEnd('/');
        culture = string.IsNullOrWhiteSpace(culture) ? "en" : culture.ToLowerInvariant();
        if (culture == "en") return path.Length == 0 ? "/" : path;
        if (path == "/") return "/" + culture;
        return "/" + culture + path;
    }
}

public static class Money
{
    public static readonly string[] Codes = ["INR", "USD", "EUR", "GBP", "JPY", "SGD"];

    public static readonly IReadOnlyDictionary<string, decimal> DefaultRates =
        new Dictionary<string, decimal>
        {
            ["INR"] = 1m,
            ["USD"] = 0.012m,
            ["EUR"] = 0.011m,
            ["GBP"] = 0.0092m,
            ["JPY"] = 1.78m,
            ["SGD"] = 0.0155m
        };

    public static bool IsValid(string? code) =>
        code is not null && DefaultRates.ContainsKey(code.ToUpperInvariant());

    public static string Format(decimal? inr, string currency, IReadOnlyDictionary<string, decimal> rates, string poa)
    {
        if (inr is null) return poa;
        currency = rates.ContainsKey(currency) ? currency : "INR";
        var value = inr.Value * rates[currency];
        if (currency == "JPY") value = Math.Round(value, 0, MidpointRounding.AwayFromZero);
        var culture = currency switch
        {
            "USD" => "en-US",
            "EUR" => "fr-FR",
            "GBP" => "en-GB",
            "JPY" => "ja-JP",
            "SGD" => "en-SG",
            _ => "en-IN"
        };
        return value.ToString("C0", CultureInfo.GetCultureInfo(culture));
    }
}
