using System.Collections.Concurrent;
using System.Text.Json;

namespace MahapatraArts.Services;

public sealed class EnquiryService(IWebHostEnvironment environment)
{
    private readonly object _gate = new();
    private readonly ConcurrentDictionary<string, Queue<DateTimeOffset>> _hits = new();

    public bool Allow(string ip)
    {
        var now = DateTimeOffset.UtcNow;
        var queue = _hits.GetOrAdd(ip, _ => new Queue<DateTimeOffset>());
        lock (queue)
        {
            while (queue.Count > 0 && now - queue.Peek() > TimeSpan.FromHours(1))
                queue.Dequeue();
            if (queue.Count >= 8) return false;
            queue.Enqueue(now);
            return true;
        }
    }

    public void Save(StoredEnquiry enquiry)
    {
        var directory = Path.Combine(environment.ContentRootPath, "App_Data");
        Directory.CreateDirectory(directory);
        var path = Path.Combine(directory, "enquiries.json");
        lock (_gate)
        {
            List<StoredEnquiry> list;
            try
            {
                list = File.Exists(path)
                    ? JsonSerializer.Deserialize<List<StoredEnquiry>>(File.ReadAllText(path)) ?? []
                    : [];
            }
            catch (JsonException)
            {
                list = [];
            }
            list.Add(enquiry);
            File.WriteAllText(path, JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true }));
        }
    }

    public static string NewId() =>
        "MA-" + DateTimeOffset.UtcNow.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
        + "-" + Guid.NewGuid().ToString("N")[..4].ToUpperInvariant();
}

public sealed class CartService
{
    private const string Key = "mahapatra.cart";

    public List<CartLine> Get(ISession session)
    {
        var json = session.GetString(Key);
        if (string.IsNullOrEmpty(json)) return [];
        return JsonSerializer.Deserialize<List<CartLine>>(json) ?? [];
    }

    public void Save(ISession session, List<CartLine> lines) =>
        session.SetString(Key, JsonSerializer.Serialize(lines));

    public void Add(ISession session, string slug, int qty)
    {
        qty = Math.Clamp(qty, 1, 9);
        var lines = Get(session);
        var index = lines.FindIndex(line => line.Slug == slug);
        if (index >= 0)
            lines[index] = lines[index] with { Qty = Math.Clamp(lines[index].Qty + qty, 1, 9) };
        else
            lines.Add(new CartLine(slug, qty));
        Save(session, lines);
    }

    public void Update(ISession session, string slug, int qty)
    {
        var lines = Get(session);
        var index = lines.FindIndex(line => line.Slug == slug);
        if (index < 0) return;
        if (qty <= 0) lines.RemoveAt(index);
        else lines[index] = lines[index] with { Qty = Math.Clamp(qty, 1, 9) };
        Save(session, lines);
    }

    public void Remove(ISession session, string slug)
    {
        var lines = Get(session);
        lines.RemoveAll(line => line.Slug == slug);
        Save(session, lines);
    }
}

public sealed class MediaLibrary(IWebHostEnvironment environment)
{
    private static readonly string[] Extensions = [".webp", ".jpg", ".jpeg", ".png", ".avif"];

    public string? Find(string slot)
    {
        foreach (var extension in Extensions)
        {
            var relative = Path.Combine("media", slot + extension);
            if (File.Exists(Path.Combine(environment.WebRootPath, relative)))
                return "/" + relative.Replace('\\', '/');
        }
        return null;
    }

    public IReadOnlyList<string> Gallery(string slot)
    {
        var found = new List<string>();
        var first = Find(slot);
        if (first is not null)
            found.Add(first);
        for (var i = 2; i <= 12; i++)
        {
            var next = Find(slot + "-" + i);
            if (next is null)
                break;
            found.Add(next);
        }
        return found;
    }

    public string? Video(string slot)
    {
        foreach (var extension in new[] { ".mp4", ".webm" })
        {
            var relative = Path.Combine("media", slot + extension);
            if (File.Exists(Path.Combine(environment.WebRootPath, relative)))
                return "/" + relative.Replace('\\', '/');
        }
        return null;
    }
}
