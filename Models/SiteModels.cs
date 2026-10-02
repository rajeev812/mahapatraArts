namespace MahapatraArts.Models;

public readonly record struct LStr(string En, string Fr = "", string De = "", string Ja = "")
{
    public string Of(string? culture)
    {
        var value = culture switch
        {
            "fr" => Fr,
            "de" => De,
            "ja" => Ja,
            _ => En
        };
        return string.IsNullOrWhiteSpace(value) ? En : value;
    }

    public string AllText() => string.Join(' ', En, Fr, De, Ja);
}

public sealed record BioSection(string Id, LStr Heading, LStr Body);

public sealed record Milestone(string Year, LStr Title, LStr Body);

public sealed record Work(
    string Slug,
    string Category,
    LStr Title,
    LStr Story,
    LStr Materials,
    string Stone,
    LStr Dimensions,
    LStr Location,
    string Motif,
    string Year,
    string Frame);

public sealed record Award(string Slug, string Year, LStr Title, LStr Body, string Motif);

public sealed record WorldProject(string Slug, LStr Title, LStr History, string Motif, string Year);

public sealed record Destination(string Id, LStr Country, double X, double Y, IReadOnlyList<WorldProject> Projects);

public sealed record Course(string Id, LStr Title, LStr Duration, LStr Summary);

public sealed record PressItem(string Id, LStr Kind, LStr Title, LStr Body, string Year);

public sealed record Product(
    string Slug,
    string Category,
    LStr Title,
    LStr Story,
    string Stone,
    LStr Dimensions,
    decimal? GuidePriceInr,
    string Motif,
    bool Commission);

public sealed record TourRoom(string Id, LStr Title, LStr Body, string Motif, string Href);

public sealed record Station(string Id, LStr Title, LStr Body, string Motif);

public sealed record SearchHit(string Kind, string Path, string Title, string Excerpt, int Score);

public sealed class EnquiryForm
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Country { get; set; } = "";
    public string Message { get; set; } = "";
    public string Topic { get; set; } = "";
    public string Program { get; set; } = "";
    public string Option { get; set; } = "";
    public string Amount { get; set; } = "";
    public string Website { get; set; } = "";
}

public sealed class FormSpec
{
    public required string Action { get; init; }
    public required string SubmitKey { get; init; }
    public bool ShowTopic { get; init; }
    public bool ShowProgram { get; init; }
    public bool ShowOption { get; init; }
    public bool ShowAmount { get; init; }
    public string Intro { get; init; } = "";
}

public sealed record CartLine(string Slug, int Qty);

public sealed record PlateView(string Slot, string Motif, string Alt, string Frame = "regular");

public sealed record StoredEnquiry(
    string Id,
    string Kind,
    string Name,
    string Email,
    string Phone,
    string Country,
    string Message,
    string Topic,
    string Program,
    string Option,
    string Amount,
    string Extra,
    string Culture,
    DateTimeOffset Created);
