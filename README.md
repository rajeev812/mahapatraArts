# Mahapatra Arts

Official atelier site for **Guru Ramakanta Mahapatra**, National Awardee stone sculptor of Odisha. It is a biography, gallery, global project atlas, academy, and enquiry store: a public record for museums, architects, collectors, students, and the Padma Shri nomination profile.

The site is **ASP.NET Core 10** (`net10.0`) with readable URLs and glass surfaces in CSS.

## Run

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
dotnet run --urls http://127.0.0.1:47291
```

Open [http://127.0.0.1:47291](http://127.0.0.1:47291).

The published reading copy is [https://rajeev812.github.io/mahapatraArts/](https://rajeev812.github.io/mahapatraArts/). GitHub Pages serves the pages, gallery, atlas, and academy. Enquiries, search, and the quotation cart run on the ASP.NET application above, because Pages cannot host that server. A push to `main` rebuilds the published copy.

```bash
dotnet test tests/MahapatraArts.Tests
```

## Routes

English lives at the root. French, German, and Japanese use the same paths under a prefix: `/fr/biography`, `/de/biography`, `/ja/store`.

| Path | Page |
| --- | --- |
| `/` | Home |
| `/biography` | Wikipedia-style life |
| `/timeline` | Chronology |
| `/masterpieces` and `/masterpieces/{slug}` | Gallery |
| `/awards` | Honours |
| `/padma-shri` | Nomination profile |
| `/global-projects` | Atlas |
| `/academy` | Guru-Shishya courses |
| `/workshops` | Private, group, tour, residency |
| `/workshop-experience` | 360° workshop |
| `/virtual-museum` | Six-room tour |
| `/store` and `/store/{slug}` | Collection |
| `/store/cart` and `/store/quotation` | Enquiry and proforma |
| `/media` | Public record |
| `/donate` | Heritage pledge |
| `/contact` | Emporium desk |
| `/search` | Curatorial index |
| `/sitemap.xml` | Sitemap with hreflang |

Settlement of a sculpture is by proforma invoice and the emporium’s own payment link or bank transfer. The site does not collect card numbers.

## Photographs

Archive photographs from the atelier now fill the named works: the Nataraja patchwork, Ganapati, the onyx Ganesha, the Dasa Avatar, the Buddhas, the Delhi gate, Jaypee University, Prashanti Nilayam, and the ongoing temples. `wwwroot/media/portraits/guru.jpg` is Guru Ramakanta carving semi-precious stone. Drop a `.jpg`, `.jpeg`, `.png`, `.webp`, or `.avif` on the same slot and the page uses the new file.

The emporium desk is Kharakhia Baidyanath Lane, Plot No. 1359, Old Town, Bhubaneswar 751002. Phone and WhatsApp: +91 9437031861. Email: ramakanta.mahapatra01@gmail.com.

| File | Where it appears |
| --- | --- |
| `wwwroot/media/portraits/guru.jpg` | Home and biography |
| `wwwroot/media/works/{slug}.jpg` | Gallery |
| `wwwroot/media/products/{slug}.jpg` | Store |
| `wwwroot/media/awards/{slug}.jpg` | Award frames |
| `wwwroot/media/projects/{slug}.jpg` | Atlas dossiers |
| `wwwroot/media/film/hero.mp4` | Home film |
| `wwwroot/media/film/carving.jpg` (and `temple`, `workshop`, `awards`, `world`) | Home stills |

Slugs are the last part of each masterpiece and product URL.

## Configuration

`appsettings.json` → `Site`:

- `Phone`, `Email`, `WhatsApp` (digits, country code, no plus)
- `PaymentUrl` (optional secure payment link shown after a quotation)
- `Address`, `MapLat`, `MapLng`

`CurrencyRates` are fixed guide rates for INR, USD, EUR, GBP, JPY, and SGD. They are not a live market feed. The invoice confirms the price.

Letters from the forms are appended to `App_Data/enquiries.json`, which is not committed.

## Record

The biography, dates, and named works follow the atelier’s public account: born 3 December 1969 in Puri; practice from Pathuria Sahi; National Award for Master Craftsperson, 2005; Padma Shri **nomination** in 2024. The nomination page states that a nomination is not the award.
