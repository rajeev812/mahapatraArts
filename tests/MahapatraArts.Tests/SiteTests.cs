using System.Net;
using System.Text.RegularExpressions;
using MahapatraArts.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MahapatraArts.Tests;

public class CatalogTests
{
    [Fact]
    public void Slugs_are_unique()
    {
        var catalog = new Catalog();
        Assert.Equal(catalog.Works.Count, catalog.Works.Select(work => work.Slug).Distinct().Count());
        Assert.Equal(catalog.Products.Count, catalog.Products.Select(product => product.Slug).Distinct().Count());
        Assert.Equal(8, catalog.Destinations.Count);
        Assert.Contains(catalog.Works, work => work.Slug == "viswaroop-darsan");
        Assert.Contains(catalog.Works, work => work.Slug == "ashokan-pillar-japan");
        Assert.Contains(catalog.Awards, award => award.Slug == "national-award-2005");
    }

    [Fact]
    public void Search_relates_japan_to_the_ashokan_pillar()
    {
        var hits = new Catalog().Search("temple pillar in japan", "en");
        Assert.Contains(hits, hit => hit.Path.Contains("ashokan-pillar-japan", StringComparison.Ordinal));
    }

    [Fact]
    public void Search_finds_ganesha_in_japanese()
    {
        var hits = new Catalog().Search("ガネーシャ", "ja");
        Assert.Contains(hits, hit => hit.Path.Contains("ganesha", StringComparison.Ordinal));
    }

    [Theory]
    [InlineData("en", "/biography", "/biography")]
    [InlineData("fr", "/biography", "/fr/biography")]
    [InlineData("de", "/", "/de")]
    [InlineData("ja", "/store/seated-ganesha", "/ja/store/seated-ganesha")]
    public void Culture_prefixes_are_stable(string culture, string path, string expected) =>
        Assert.Equal(expected, Paths.WithCulture(culture, path));

    [Fact]
    public void Guide_prices_convert_without_claiming_a_live_rate()
    {
        var formatted = Money.Format(100000m, "USD", Money.DefaultRates, "POA");
        Assert.Contains("1,200", formatted);
        Assert.Equal("POA", Money.Format(null, "EUR", Money.DefaultRates, "POA"));
    }

    [Fact]
    public void Every_ui_string_has_four_languages()
    {
        foreach (var row in UiText.Rows)
            Assert.Equal(4, row.Length);
        Assert.Contains("Life", UiText.Get("en", "hero.title.html"));
        Assert.Contains("vie", UiText.Get("fr", "hero.title.html"));
        Assert.Contains("Leben", UiText.Get("de", "hero.title.html"));
        Assert.Contains("いのち", UiText.Get("ja", "hero.title.html"));
        Assert.DoesNotContain("⟦", UiText.Get("fr", "nav.masterpieces"));
    }
}

public class SiteFactory : WebApplicationFactory<Program>
{
}

public class RouteTests : IClassFixture<SiteFactory>
{
    private readonly SiteFactory _factory;

    public RouteTests(SiteFactory factory) => _factory = factory;

    [Fact]
    public async Task Public_pages_render_in_four_languages()
    {
        var client = _factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = true });
        var catalog = new Catalog();
        foreach (var path in catalog.IndexablePaths())
        {
            foreach (var culture in Paths.Cultures)
            {
                var url = Paths.WithCulture(culture, path);
                var response = await client.GetAsync(url);
                var body = await response.Content.ReadAsStringAsync();
                Assert.True(response.StatusCode == HttpStatusCode.OK, url + " -> " + response.StatusCode);
                Assert.DoesNotContain("⟦", body, StringComparison.Ordinal);
            }
        }
    }

    [Fact]
    public async Task Home_uses_the_atelier_motto()
    {
        var client = _factory.CreateClient();
        var english = await client.GetStringAsync("/");
        var french = await client.GetStringAsync("/fr");
        Assert.Contains("Chanting", english);
        Assert.Contains("Chanter", french);
        Assert.Contains("rel=\"canonical\"", english);
        Assert.Contains("application/ld+json", english);
    }

    [Fact]
    public async Task Unknown_path_is_not_found()
    {
        var client = _factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
        var response = await client.GetAsync("/no-such-stone");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task Sitemap_lists_the_ashokan_pillar()
    {
        var client = _factory.CreateClient();
        var xml = await client.GetStringAsync("/sitemap.xml");
        Assert.Contains("/masterpieces/ashokan-pillar-japan", xml);
        Assert.Contains("hreflang=\"ja\"", xml);
        var robots = await client.GetStringAsync("/robots.txt");
        Assert.Contains("Sitemap:", robots);
    }

    [Fact]
    public async Task Contact_letter_is_stored()
    {
        var client = _factory.CreateClient(new WebApplicationFactoryClientOptions { HandleCookies = true });
        var page = await client.GetStringAsync("/contact");
        var token = Regex.Match(page, "name=\"__RequestVerificationToken\"[^>]*value=\"([^\"]+)\"").Groups[1].Value;
        Assert.False(string.IsNullOrWhiteSpace(token));
        var email = "curator." + Guid.NewGuid().ToString("N")[..8] + "@museum.example";
        var response = await client.PostAsync("/contact", new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["__RequestVerificationToken"] = token,
            ["Form.Name"] = "A. Curator",
            ["Form.Email"] = email,
            ["Form.Country"] = "France",
            ["Form.Topic"] = "exhibit",
            ["Form.Message"] = "We would like to discuss an exhibition of temple sculpture."
        }));
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("MA-", body);
        var env = _factory.Services.GetRequiredService<IWebHostEnvironment>();
        var file = await File.ReadAllTextAsync(Path.Combine(env.ContentRootPath, "App_Data", "enquiries.json"));
        Assert.Contains(email, file);
    }
}
