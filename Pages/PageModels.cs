namespace MahapatraArts.Pages;

public abstract class EnquiryPageModel : PageModel
{
    protected EnquiryPageModel(EnquiryService enquiries, SiteView site)
    {
        Enquiries = enquiries;
        Site = site;
    }

    protected EnquiryService Enquiries { get; }
    protected SiteView Site { get; }

    [BindProperty]
    public EnquiryForm Form { get; set; } = new();

    protected void ValidateCore()
    {
        if (string.IsNullOrWhiteSpace(Form.Name) || Form.Name.Trim().Length < 2)
            ModelState.AddModelError("Form.Name", Site.T("form.err.name"));
        if (!IsEmail(Form.Email))
            ModelState.AddModelError("Form.Email", Site.T("form.err.email"));
        if (string.IsNullOrWhiteSpace(Form.Message) || Form.Message.Trim().Length < 8)
            ModelState.AddModelError("Form.Message", Site.T("form.err.message"));
    }

    protected IActionResult Save(string kind, string path, string? extra = null)
    {
        if (!string.IsNullOrWhiteSpace(Form.Website))
            return Redirect(Site.Href(path) + "?sent=1");
        ValidateCore();
        if (!ModelState.IsValid) return Page();
        var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        if (!Enquiries.Allow(ip))
        {
            ModelState.AddModelError(string.Empty, Site.T("form.err.limit"));
            return Page();
        }
        var id = EnquiryService.NewId();
        Enquiries.Save(new StoredEnquiry(
            id,
            kind,
            Form.Name.Trim(),
            Form.Email.Trim(),
            Form.Phone.Trim(),
            Form.Country.Trim(),
            Form.Message.Trim(),
            Form.Topic.Trim(),
            Form.Program.Trim(),
            Form.Option.Trim(),
            Form.Amount.Trim(),
            extra ?? "",
            Site.Culture,
            DateTimeOffset.UtcNow));
        return Redirect(Site.Href(path) + "?sent=1&ref=" + Uri.EscapeDataString(id));
    }

    private static bool IsEmail(string? value)
    {
        if (string.IsNullOrWhiteSpace(value)) return false;
        var text = value.Trim();
        var at = text.IndexOf('@');
        return at > 0 && at < text.Length - 3 && text.IndexOf('.', at) > at + 1 && !text.Contains(' ');
    }
}

public class ContactModel(EnquiryService enquiries, SiteView site) : EnquiryPageModel(enquiries, site)
{
    public void OnGet() { }
    public IActionResult OnPost() => Save("contact", "/contact");
}

public class AcademyModel(EnquiryService enquiries, SiteView site) : EnquiryPageModel(enquiries, site)
{
    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Form.Program))
            ModelState.AddModelError("Form.Program", Site.T("form.err.program"));
        return Save("academy", "/academy");
    }
}

public class WorkshopsModel(EnquiryService enquiries, SiteView site) : EnquiryPageModel(enquiries, site)
{
    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (string.IsNullOrWhiteSpace(Form.Option))
            ModelState.AddModelError("Form.Option", Site.T("form.err.option"));
        return Save("workshop", "/workshops");
    }
}

public class DonateModel(EnquiryService enquiries, SiteView site) : EnquiryPageModel(enquiries, site)
{
    public void OnGet() { }
    public IActionResult OnPost() => Save("donation", "/donate");
}

public class QuoteModel(EnquiryService enquiries, SiteView site, CartService cart, Catalog catalog) : EnquiryPageModel(enquiries, site)
{
    public IReadOnlyList<(Product Product, int Qty)> Lines { get; private set; } = [];

    public void OnGet() => Load();

    public IActionResult OnPost()
    {
        Load();
        var extra = string.Join("; ", Lines.Select(line => $"{line.Product.Slug} x{line.Qty}"));
        return Save("quotation", "/store/quotation", extra);
    }

    private void Load()
    {
        Lines = cart.Get(HttpContext.Session)
            .Select(line => (Product: catalog.FindProduct(line.Slug), line.Qty))
            .Where(line => line.Product is not null)
            .Select(line => (line.Product!, line.Qty))
            .ToList();
    }
}

public class CartModel(CartService cart, Catalog catalog, SiteView site) : PageModel
{
    public SiteView Site { get; } = site;
    public IReadOnlyList<(Product Product, int Qty)> Lines { get; private set; } = [];

    public void OnGet() => Load();

    public IActionResult OnPostAdd(string slug, int qty = 1)
    {
        if (catalog.FindProduct(slug) is not null)
            cart.Add(HttpContext.Session, slug, qty);
        return Redirect(Site.Href("/store/cart"));
    }

    public IActionResult OnPostUpdate(string slug, int qty)
    {
        cart.Update(HttpContext.Session, slug, qty);
        return Redirect(Site.Href("/store/cart"));
    }

    public IActionResult OnPostRemove(string slug)
    {
        cart.Remove(HttpContext.Session, slug);
        return Redirect(Site.Href("/store/cart"));
    }

    private void Load()
    {
        Lines = cart.Get(HttpContext.Session)
            .Select(line => (Product: catalog.FindProduct(line.Slug), line.Qty))
            .Where(line => line.Product is not null)
            .Select(line => (line.Product!, line.Qty))
            .ToList();
    }
}

public class ProductModel(Catalog catalog) : PageModel
{
    public Product? Item { get; private set; }
    public IReadOnlyList<Product> Related { get; private set; } = [];

    public IActionResult OnGet(string slug)
    {
        if (slug is "cart" or "quotation") return NotFound();
        Item = catalog.FindProduct(slug);
        if (Item is null) return NotFound();
        Related = catalog.RelatedProducts(Item);
        return Page();
    }
}

public class WorkModel(Catalog catalog) : PageModel
{
    public Work? Item { get; private set; }
    public IReadOnlyList<Work> Related { get; private set; } = [];

    public IActionResult OnGet(string slug)
    {
        Item = catalog.FindWork(slug);
        if (Item is null) return NotFound();
        Related = catalog.RelatedWorks(Item);
        return Page();
    }
}

public class SearchModel(Catalog catalog, SiteView site) : PageModel
{
    [BindProperty(SupportsGet = true, Name = "q")]
    public string? Q { get; set; }

    public IReadOnlyList<SearchHit> Hits { get; private set; } = [];
    public IReadOnlyList<string> Terms { get; private set; } = [];

    public void OnGet()
    {
        Hits = catalog.Search(Q, site.Culture);
        Terms = catalog.Interpret(Q);
    }
}

public class NotFoundModel : PageModel
{
    public void OnGet() => Response.StatusCode = StatusCodes.Status404NotFound;
}

public class ErrorModel : PageModel
{
    public void OnGet() => Response.StatusCode = StatusCodes.Status500InternalServerError;
}
