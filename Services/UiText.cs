namespace MahapatraArts.Services;

public static class UiText
{
    private static readonly Dictionary<string, string[]> Map = new()
    {
        ["skip"] = ["Skip to content", "Aller au contenu", "Zum Inhalt", "本文へ"],
        ["kicker.bar"] = [
            "National Award for Master Craftsperson, 2005  ·  Padma Shri nomination profile",
            "Prix national du maître artisan, 2005  ·  Dossier de nomination Padma Shri",
            "Nationalpreis für Meisterhandwerk, 2005  ·  Padma-Shri-Nominierung",
            "マスター・クラフツパーソン国家賞、2005年  ·  パドマ・シュリー推薦記録"
        ],
        ["site.name"] = ["Mahapatra Arts", "Mahapatra Arts", "Mahapatra Arts", "マハパトラ・アーツ"],
        ["site.tagline"] = [
            "Master Stone Sculptor  ·  National Awardee",
            "Maître sculpteur sur pierre  ·  Lauréat national",
            "Meister der Steinbildhauerei  ·  Nationalpreisträger",
            "石彫の名匠  ·  国家賞受賞"
        ],
        ["nav.home"] = ["Home", "Accueil", "Start", "ホーム"],
        ["nav.biography"] = ["Biography", "Biographie", "Biografie", "経歴"],
        ["nav.timeline"] = ["Timeline", "Chronologie", "Chronik", "年譜"],
        ["nav.masterpieces"] = ["Masterpieces", "Chefs-d'œuvre", "Meisterwerke", "作品"],
        ["nav.awards"] = ["Awards", "Distinctions", "Auszeichnungen", "顕彰"],
        ["nav.padma"] = ["Padma Shri dossier", "Dossier Padma Shri", "Padma-Shri-Dossier", "パドマ・シュリー"],
        ["nav.projects"] = ["Global projects", "Projets dans le monde", "Weltprojekte", "世界の仕事"],
        ["nav.tour"] = ["Virtual museum", "Musée virtuel", "Virtuelles Museum", "仮想美術館"],
        ["nav.academy"] = ["Academy", "Académie", "Akademie", "学院"],
        ["nav.workshops"] = ["Workshops", "Ateliers", "Werkstätten", "講習"],
        ["nav.experience"] = ["360° workshop", "Atelier à 360°", "Werkstatt 360°", "工房360°"],
        ["nav.store"] = ["Store", "Boutique", "Kollektion", "受注"],
        ["nav.media"] = ["Media", "Presse", "Presse", "報道"],
        ["nav.contact"] = ["Contact", "Contact", "Kontakt", "連絡"],
        ["nav.donate"] = ["Patronage", "Mécénat", "Förderung", "支援"],
        ["nav.search"] = ["Search", "Recherche", "Suche", "検索"],
        ["nav.index"] = ["Index", "Index", "Index", "目次"],
        ["nav.enquire"] = ["Enquire", "Écrire", "Anfragen", "問い合わせ"],
        ["nav.menu"] = ["Menu", "Menu", "Menü", "メニュー"],
        ["nav.close"] = ["Close", "Fermer", "Schließen", "閉じる"],
        ["nav.visit"] = ["The master", "Le maître", "Der Meister", "名匠"],
        ["nav.collection"] = ["Collection", "Collection", "Sammlung", "収蔵"],
        ["nav.learn"] = ["Academy", "Académie", "Akademie", "学ぶ"],
        ["nav.patron"] = ["Patronage", "Mécénat", "Förderung", "庇護"],
        ["nav.cart"] = ["Cart", "Panier", "Korb", "依頼籠"],
        ["hero.kicker"] = [
            "Guru Ramakanta Mahapatra  ·  Puri, Odisha",
            "Guru Ramakanta Mahapatra  ·  Puri, Odisha",
            "Guru Ramakanta Mahapatra  ·  Puri, Odisha",
            "グル・ラマカンタ・マハパトラ  ·  プリー、オディシャ"
        ],
        ["hero.title.html"] = [
            "Chanting <em>Life</em> Into Lifeless Stones",
            "Chanter la <em>vie</em> dans la pierre inerte",
            "<em>Leben</em> in leblosen Stein singen",
            "命なき石に、<em>いのち</em>を唱える"
        ],
        ["hero.sub"] = [
            "40+ years of excellence in stone sculpture, temple architecture and artisan training",
            "Plus de quarante ans d’excellence en sculpture sur pierre, architecture de temple et formation d’artisans",
            "Mehr als vierzig Jahre Exzellenz in Steinbildhauerei, Tempelarchitektur und Ausbildung",
            "石彫、寺院建築、職人育成における四十年余の精進"
        ],
        ["hero.cta.works"] = ["View masterpieces", "Voir les chefs-d'œuvre", "Meisterwerke ansehen", "作品を見る"],
        ["hero.cta.workshop"] = ["Book a workshop", "Réserver un atelier", "Werkstatt buchen", "講習を予約"],
        ["hero.cta.store"] = ["Visit the store", "Entrer dans la boutique", "Zur Kollektion", "受注を見る"],
        ["hero.scene.carving"] = ["Stone carving", "Taille de la pierre", "Steinarbeit", "石彫"],
        ["hero.scene.temple"] = ["Temple sculptures", "Sculptures de temple", "Tempelskulpturen", "寺院彫刻"],
        ["hero.scene.workshop"] = ["The workshop", "L’atelier", "Die Werkstatt", "工房"],
        ["hero.scene.awards"] = ["Awards", "Distinctions", "Ehrungen", "顕彰"],
        ["hero.scene.world"] = ["International projects", "Projets internationaux", "Internationale Projekte", "国外の仕事"],
        ["hero.pause"] = ["Pause film", "Pause", "Pause", "一時停止"],
        ["hero.play"] = ["Play film", "Lecture", "Abspielen", "再生"],
        ["stat.years.n"] = ["40+", "40+", "40+", "40+"],
        ["stat.years.l"] = ["Years of practice", "Années de pratique", "Jahre Praxis", "年の実践"],
        ["stat.artisans.n"] = ["1000+", "1000+", "1000+", "1000+"],
        ["stat.artisans.l"] = ["Artisans trained", "Artisans formés", "Ausgebildete Handwerker", "育成した職人"],
        ["stat.award.n"] = ["2005", "2005", "2005", "2005"],
        ["stat.award.l"] = ["National Award", "Prix national", "Nationalpreis", "国家賞"],
        ["stat.intl.n"] = ["8", "8", "8", "8"],
        ["stat.intl.l"] = ["Countries of installation", "Pays d’installation", "Länder mit Installationen", "設置された国"],
        ["stat.temple.n"] = ["Temple", "Temples", "Tempel", "寺院"],
        ["stat.temple.l"] = ["Projects worldwide", "Projets dans le monde", "Projekte weltweit", "世界のプロジェクト"],
        ["home.master.kicker"] = ["01  —  The master", "01  —  Le maître", "01  —  Der Meister", "01  —  名匠"],
        ["home.master.title"] = [
            "A life given to the grain of the stone",
            "Une vie donnée au fil de la pierre",
            "Ein Leben im Lager des Steins",
            "石の目に捧げた生涯"
        ],
        ["home.master.body"] = [
            "Guru Ramakanta Mahapatra is a stone sculptor, temple architect, master craftsman and teacher from Puri, Odisha. Born on 3 December 1969 in Pathuria Sahi, he has practised since the family workshop of his father, Damodara Mahapatra, and since 1985 in the public life of the craft. The National Award for Master Craftsperson followed in 2005.",
            "Guru Ramakanta Mahapatra est sculpteur sur pierre, architecte de temple, maître artisan et professeur, né à Puri, en Odisha. Né le 3 décembre 1969 à Pathuria Sahi, il pratique depuis l’atelier familial de son père, Damodara Mahapatra, et depuis 1985 dans la vie publique du métier. Le Prix national du maître artisan est venu en 2005.",
            "Guru Ramakanta Mahapatra ist Steinbildhauer, Tempelarchitekt, Meisterhandwerker und Lehrer aus Puri, Odisha. Geboren am 3. Dezember 1969 in Pathuria Sahi, übt er das Handwerk seit der Familienwerkstatt seines Vaters Damodara Mahapatra und seit 1985 im öffentlichen Leben des Berufs aus. Der Nationalpreis für Meisterhandwerk folgte 2005.",
            "グル・ラマカンタ・マハパトラは、オディシャ州プリーの石彫家、寺院建築家、名匠、師です。1969年12月3日、パトゥリア・サヒに生まれ、父ダモーダラ・マハパトラの家の工房から、1985年以降は公の職人の世界で仕事を続けてきました。2005年、マスター・クラフツパーソン国家賞を受けています。"
        ],
        ["home.master.cta"] = ["Read the biography", "Lire la biographie", "Biografie lesen", "経歴を読む"],
        ["home.works.kicker"] = ["02  —  Selected works", "02  —  Œuvres choisies", "02  —  Ausgewählte Werke", "02  —  選ばれた仕事"],
        ["home.works.title"] = [
            "Stones that keep a vigil",
            "Des pierres qui veillent",
            "Steine, die Wache halten",
            "見守る石"
        ],
        ["home.works.cta"] = ["Enter the gallery", "Entrer dans la galerie", "In die Galerie", "ギャラリーへ"],
        ["home.pillars.kicker"] = ["03  —  The practice", "03  —  La pratique", "03  —  Die Praxis", "03  —  仕事のかたち"],
        ["home.pillars.title"] = [
            "Sculpture, temple, and the handing on of skill",
            "Sculpture, temple, et transmission du geste",
            "Skulptur, Tempel und die Weitergabe der Hand",
            "彫刻、寺院、そして技の継承"
        ],
        ["home.pillar1.title"] = ["Stone carving", "Taille de la pierre", "Steinarbeit", "石彫"],
        ["home.pillar1.body"] = [
            "Sacred images and narrative relief, cut so that iconography and the block remain in agreement.",
            "Images sacrées et reliefs narratifs, taillés pour que l’iconographie et le bloc restent d’accord.",
            "Heilige Bilder und erzählende Reliefs, so gehauen, dass Ikonografie und Block übereinstimmen.",
            "図像と石塊が一致するように刻む、聖像と物語の浮彫。"
        ],
        ["home.pillar2.title"] = ["Temple architecture", "Architecture de temple", "Tempelarchitektur", "寺院建築"],
        ["home.pillar2.body"] = [
            "Shrines, mandapams, gateways and architectural stone prepared for sacred space in India and abroad.",
            "Sanctuaires, mandapams, portails et pierre d’architecture préparés pour l’espace sacré, en Inde et ailleurs.",
            "Schreine, Mandapams, Tore und Architekturstein für sakrale Räume in Indien und im Ausland.",
            "インドと国外の聖なる空間のための祠堂、マンダパム、門、建築石材。"
        ],
        ["home.pillar3.title"] = ["The guru-shishya line", "La lignée guru-shishya", "Die Guru-Shishya-Linie", "師弟の系譜"],
        ["home.pillar3.body"] = [
            "More than a thousand artisans trained, so the craft stays in many hands rather than in a single workshop.",
            "Plus de mille artisans formés, afin que le métier reste dans de nombreuses mains.",
            "Mehr als tausend ausgebildete Handwerker, damit das Handwerk in vielen Händen bleibt.",
            "千人を超える職人を育て、技を一つの工房に閉じ込めない。"
        ],
        ["home.global.kicker"] = ["04  —  The world", "04  —  Le monde", "04  —  Die Welt", "04  —  世界"],
        ["home.global.title"] = [
            "From a lane in Puri to eight countries",
            "D’une ruelle de Puri vers huit pays",
            "Aus einer Gasse in Puri in acht Länder",
            "プリーの路地から、八つの国へ"
        ],
        ["home.global.body"] = [
            "Installations and commissions are recorded in India, Japan, Singapore, Italy, Thailand, Russia, the United States and Israel. The Ashokan pillar in Japan (1995) and the seven temple shrines in Singapore anchor the international record.",
            "Des installations et des commandes sont attestées en Inde, au Japon, à Singapour, en Italie, en Thaïlande, en Russie, aux États-Unis et en Israël. Le pilier d’Ashoka au Japon (1995) et les sept sanctuaires de Singapour ancrent ce parcours.",
            "Installationen und Aufträge sind in Indien, Japan, Singapur, Italien, Thailand, Russland, den Vereinigten Staaten und Israel verzeichnet. Die Ashoka-Säule in Japan (1995) und die sieben Tempelschreine in Singapur tragen den internationalen Nachweis.",
            "インド、日本、シンガポール、イタリア、タイ、ロシア、米国、イスラエルに設置と注文の記録があります。1995年の日本のアショーカ石柱と、シンガポールの七つの寺院祠堂が、国外の仕事の基点です。"
        ],
        ["home.global.cta"] = ["Open the atlas", "Ouvrir l’atlas", "Den Atlas öffnen", "地図を開く"],
        ["home.academy.kicker"] = ["05  —  The academy", "05  —  L’académie", "05  —  Die Akademie", "05  —  学院"],
        ["home.academy.title"] = [
            "Learn the chisel from a National Awardee",
            "Apprendre le ciseau auprès d’un lauréat national",
            "Den Meißel bei einem Nationalpreisträger lernen",
            "国家賞の師から、鑿を学ぶ"
        ],
        ["home.academy.body"] = [
            "The Guru-Shishya Stone Sculpture Academy receives architects, collectors, students and travellers. Courses run from one week to a one-year master artisan fellowship, with a certificate, carving, temple drawing, and help with lodging.",
            "L’académie Guru-Shishya accueille architectes, collectionneurs, étudiants et voyageurs. Les cours vont d’une semaine à une résidence d’un an, avec certificat, taille, dessin de temple et aide au logement.",
            "Die Guru-Shishya-Akademie empfängt Architekten, Sammler, Studierende und Reisende. Kurse reichen von einer Woche bis zum einjährigen Meisterstipendium, mit Zertifikat, Steinarbeit, Tempelzeichnung und Hilfe bei der Unterkunft.",
            "グル・シシュヤ石彫学院は、建築家、蒐集家、学生、旅人を迎えます。一週間から一年の名匠フェローシップまで。修了証、実技、寺院図面、滞在の手引きがあります。"
        ],
        ["home.academy.cta"] = ["See the courses", "Voir les cours", "Kurse ansehen", "課程を見る"],
        ["home.store.kicker"] = ["06  —  The collection", "06  —  La collection", "06  —  Die Kollektion", "06  —  収蔵"],
        ["home.store.title"] = [
            "Works prepared for shrines, gardens and museums",
            "Des œuvres pour sanctuaires, jardins et musées",
            "Werke für Schreine, Gärten und Museen",
            "祠堂、庭、美術館のための仕事"
        ],
        ["home.store.body"] = [
            "Devotional images, garden guardians, museum studies and architectural panels. International crating, a certificate of authenticity from the atelier, and a proforma invoice in the currency you choose.",
            "Images de dévotion, gardiens de jardin, études de musée et panneaux d’architecture. Caisse internationale, certificat d’authenticité de l’atelier, et facture pro forma dans la monnaie choisie.",
            "Andachtsbilder, Gartenschützer, Museumsstudien und Architekturplatten. Internationale Verpackung, Atelierzertifikat und Proforma in der gewählten Währung.",
            "信仰の像、庭の守護、美術館のための習作、建築パネル。国際梱包、工房の真正証明書、選んだ通貨のプロフォーマインボイス。"
        ],
        ["home.store.cta"] = ["Browse the store", "Parcourir la boutique", "Kollektion ansehen", "受注一覧"],
        ["home.awards.kicker"] = ["07  —  Recognition", "07  —  Reconnaissance", "07  —  Anerkennung", "07  —  顕彰"],
        ["home.awards.title"] = [
            "A public record of honour",
            "Un registre public des honneurs",
            "Ein öffentliches Verzeichnis der Ehrungen",
            "栄誉の公の記録"
        ],
        ["home.awards.cta"] = ["View awards", "Voir les distinctions", "Auszeichnungen", "顕彰を見る"],
        ["home.motto"] = [
            "Chanting life into lifeless stones.",
            "Chanter la vie dans la pierre inerte.",
            "Leben in leblosen Stein singen.",
            "命なき石に、いのちを唱える。"
        ],
        ["home.motto.by"] = [
            "Motto of the atelier",
            "Devise de l’atelier",
            "Wahlspruch des Ateliers",
            "工房の標語"
        ],
        ["home.donate.kicker"] = ["Patronage", "Mécénat", "Förderung", "支援"],
        ["home.donate.title"] = [
            "Keep a living stone tradition in teaching",
            "Maintenir vivante une tradition de pierre",
            "Eine lebendige Steintradition im Unterricht halten",
            "生きた石の伝統を、教えることのなかに残す"
        ],
        ["home.donate.body"] = [
            "Gifts support materials for students of the academy and the keeping of traditional Indian stone sculpture. A pledge is confirmed by the emporium before any transfer.",
            "Les dons soutiennent les matériaux des élèves et la transmission de la sculpture traditionnelle indienne sur pierre. L’emporium confirme l’intention avant tout virement.",
            "Gaben stützen Material für Schüler der Akademie und die Weitergabe traditioneller indischer Steinbildhauerei. Das Emporium bestätigt die Zusage vor jeder Überweisung.",
            "ご支援は学院の生徒の材料と、インドの伝統石彫の継承に充てられます。送金の前に、エンポリアムが誓約を確認します。"
        ],
        ["home.donate.cta"] = ["Support the heritage", "Soutenir le patrimoine", "Das Erbe stützen", "遺産を支える"],
        ["footer.colophon"] = [
            "Mahapatra Handicrafts Emporium, Bhubaneswar, Odisha. Stone sculpture, temple architecture, and the Guru-Shishya academy.",
            "Mahapatra Handicrafts Emporium, Bhubaneswar, Odisha. Sculpture sur pierre, architecture de temple et académie Guru-Shishya.",
            "Mahapatra Handicrafts Emporium, Bhubaneswar, Odisha. Steinbildhauerei, Tempelarchitektur und die Guru-Shishya-Akademie.",
            "マハパトラ手工芸エンポリアム、ブバネーシュワル、オディシャ。石彫、寺院建築、グル・シシュヤ学院。"
        ],
        ["footer.rights"] = [
            "Mahapatra Handicrafts Emporium. All rights reserved.",
            "Mahapatra Handicrafts Emporium. Tous droits réservés.",
            "Mahapatra Handicrafts Emporium. Alle Rechte vorbehalten.",
            "マハパトラ手工芸エンポリアム。無断転載を禁じます。"
        ],
        ["footer.privacy"] = ["Privacy", "Confidentialité", "Datenschutz", "個人情報"],
        ["read.more"] = ["Read", "Lire", "Lesen", "読む"],
        ["view"] = ["View", "Voir", "Ansehen", "見る"],
        ["filter.all"] = ["All", "Tout", "Alle", "すべて"],
        ["materials"] = ["Materials", "Matériaux", "Material", "材料"],
        ["stone"] = ["Stone", "Pierre", "Stein", "石"],
        ["dimensions"] = ["Scale", "Échelle", "Maßstab", "規模"],
        ["location"] = ["Location", "Lieu", "Ort", "場所"],
        ["year"] = ["Year", "Année", "Jahr", "年"],
        ["story"] = ["Story", "Récit", "Geschichte", "物語"],
        ["back"] = ["Back", "Retour", "Zurück", "戻る"],
        ["related"] = ["Related", "Dans le même esprit", "Verwandtes", "関連"],
        ["enlarge"] = ["Enlarge", "Agrandir", "Vergrößern", "拡大"],
        ["dialog.close"] = ["Close", "Fermer", "Schließen", "閉じる"],
        ["search.placeholder"] = [
            "A deity, a stone, a country, a year",
            "Une divinité, une pierre, un pays, une année",
            "Eine Gottheit, ein Stein, ein Land, ein Jahr",
            "神、石、国、年"
        ],
        ["search.submit"] = ["Search", "Rechercher", "Suchen", "検索"],
        ["search.title"] = ["Gallery search", "Recherche dans la galerie", "Galerisuche", "ギャラリー検索"],
        ["search.kicker"] = ["Curatorial index", "Index de conservation", "Kuratorischer Index", "学芸索引"],
        ["search.lede"] = [
            "Ask in ordinary language. The index relates deities, stones, places, awards, courses and commissions across the atelier.",
            "Posez la question en langage ordinaire. L’index relie divinités, pierres, lieux, prix, cours et commandes.",
            "Fragen Sie in gewöhnlicher Sprache. Der Index verbindet Gottheiten, Steine, Orte, Preise, Kurse und Aufträge.",
            "日常の言葉で尋ねてください。神、石、場所、賞、課程、注文を工房の索引が結びます。"
        ],
        ["search.interpreted"] = ["Read as", "Lu comme", "Gelesen als", "読み取り"],
        ["search.empty"] = [
            "Nothing in the index matches that yet. Try a deity, a country, or “National Award”.",
            "Rien dans l’index ne correspond encore. Essayez une divinité, un pays, ou « prix national ».",
            "Nichts im Index entspricht dem bisher. Versuchen Sie eine Gottheit, ein Land oder „Nationalpreis“.",
            "索引に一致がありません。神の名、国、または「国家賞」を試してください。"
        ],
        ["search.works"] = ["Masterpieces", "Chefs-d'œuvre", "Meisterwerke", "作品"],
        ["search.products"] = ["Store", "Boutique", "Kollektion", "受注"],
        ["search.projects"] = ["Global projects", "Projets", "Projekte", "世界"],
        ["search.awards"] = ["Awards", "Distinctions", "Auszeichnungen", "顕彰"],
        ["search.pages"] = ["Pages", "Pages", "Seiten", "ページ"],
        ["search.press"] = ["Media", "Presse", "Presse", "報道"],
        ["crumb.home"] = ["Home", "Accueil", "Start", "ホーム"],
        ["price.poa"] = ["Price on application", "Prix sur demande", "Preis auf Anfrage", "価格は照会"],
        ["price.guide"] = ["Guide price", "Prix indicatif", "Richtpreis", "案内価格"],
        ["price.note"] = [
            "Guide figures for enquiry, converted at a fixed atelier rate, not a live market rate. The proforma invoice confirms stone, scale and price. Each block is unique.",
            "Chiffres indicatifs, convertis à un taux fixe de l’atelier, et non au cours du marché. La facture pro forma confirme la pierre, l’échelle et le prix. Chaque bloc est unique.",
            "Richtwerte zur Anfrage, umgerechnet zu einem festen Ateliersatz, nicht zum Tageskurs. Die Proforma bestätigt Stein, Maß und Preis. Jeder Block ist einzig.",
            "問い合わせのための案内価格です。工房の固定レートによる換算であり、実勢相場ではありません。石種、規模、価格はプロフォーマで確定します。石は一点ごとに異なります。"
        ],
        ["currency.label"] = ["Currency", "Monnaie", "Währung", "通貨"],
        ["cat.temple"] = ["Temple sculptures", "Sculptures de temple", "Tempelskulpturen", "寺院彫刻"],
        ["cat.idols"] = ["God idols", "Images divines", "Götterbilder", "神像"],
        ["cat.murals"] = ["Murals", "Murales", "Wandbilder", "壁画"],
        ["cat.international"] = ["International projects", "Projets internationaux", "Internationale Projekte", "国外の仕事"],
        ["cat.rare"] = ["Rare masterpieces", "Chefs-d'œuvre rares", "Seltene Meisterwerke", "稀少な傑作"],
        ["cat.architecture"] = ["Architectural stone", "Pierre d’architecture", "Architekturstein", "建築石材"],
        ["pcat.ganesha"] = ["Lord Ganesha", "Seigneur Ganesha", "Herr Ganesha", "ガネーシャ"],
        ["pcat.krishna"] = ["Lord Krishna", "Seigneur Krishna", "Herr Krishna", "クリシュナ"],
        ["pcat.decor"] = ["Temple decor", "Décor de temple", "Tempelschmuck", "寺院装飾"],
        ["pcat.custom"] = ["Custom sculptures", "Sculptures sur mesure", "Skulpturen auf Maß", "注文彫刻"],
        ["pcat.garden"] = ["Garden sculptures", "Sculptures de jardin", "Gartenskulpturen", "庭の彫刻"],
        ["pcat.museum"] = ["Museum replicas", "Répliques de musée", "Museumsstudien", "美術館のための習作"],
        ["pcat.premium"] = ["Premium art pieces", "Pièces d’exception", "Premiumwerke", "特別作品"],
        ["pcat.panels"] = ["Architectural panels", "Panneaux d’architecture", "Architekturplatten", "建築パネル"],
        ["bio.kicker"] = ["Biography", "Biographie", "Biografie", "経歴"],
        ["bio.title"] = [
            "Guru Ramakanta Mahapatra",
            "Guru Ramakanta Mahapatra",
            "Guru Ramakanta Mahapatra",
            "グル・ラマカンタ・マハパトラ"
        ],
        ["portrait.alt"] = [
            "Guru Ramakanta carving semi-precious stone in his workshop",
            "Guru Ramakanta taillant une pierre semi-précieuse dans son atelier",
            "Guru Ramakanta bei der Arbeit an einem Halbedelstein in der Werkstatt",
            "工房で半貴石を刻むグル・ラマカンタ"
        ],
        ["portrait.caption"] = [
            "Guru Ramakanta carving semi-precious stone at his workshop.",
            "Guru Ramakanta taille une pierre semi-précieuse dans son atelier.",
            "Guru Ramakanta arbeitet in seiner Werkstatt an einem Halbedelstein.",
            "工房で半貴石を刻むグル・ラマカンタ。"
        ],
        ["footer.motto"] = [
            "Bring Smile on Stones",
            "Bring Smile on Stones",
            "Bring Smile on Stones",
            "石に微笑みを"
        ],
        ["bio.lede"] = [
            "Indian stone sculptor, temple architect, master craftsman and teacher. National Awardee for Master Craftsperson (2005). Known for temple carving, sacred images, and multi-coloured stone patchwork. Founder of Mahapatra Handicrafts Emporium.",
            "Sculpteur indien sur pierre, architecte de temple, maître artisan et professeur. Lauréat national du maître artisan (2005). Connu pour la taille de temple, les images sacrées et le patchwork de pierres multicolores. Fondateur du Mahapatra Handicrafts Emporium.",
            "Indischer Steinbildhauer, Tempelarchitekt, Meisterhandwerker und Lehrer. Nationalpreisträger für Meisterhandwerk (2005). Bekannt für Tempelarbeit, heilige Bilder und mehrfarbiges Steinpatchwork. Gründer des Mahapatra Handicrafts Emporium.",
            "インドの石彫家、寺院建築家、名匠、師。2005年マスター・クラフツパーソン国家賞。寺院彫刻、聖像、多色石のパッチワークで知られる。マハパトラ手工芸エンポリアムの創設者。"
        ],
        ["bio.toc"] = ["Contents", "Sommaire", "Inhalt", "目次"],
        ["bio.note"] = [
            "This is the atelier’s public biography, prepared for readers, museums and the Padma Shri nomination profile.",
            "Ceci est la biographie publique de l’atelier, préparée pour les lecteurs, les musées et le dossier Padma Shri.",
            "Dies ist die öffentliche Biografie des Ateliers, für Leser, Museen und das Padma-Shri-Dossier.",
            "これは工房の公の経歴であり、読者、美術館、パドマ・シュリー推薦記録のために編まれています。"
        ],
        ["info.title"] = ["Infobox", "Fiche", "Steckbrief", "概要"],
        ["info.name"] = ["Full name", "Nom complet", "Vollständiger Name", "氏名"],
        ["info.born"] = ["Born", "Naissance", "Geboren", "生誕"],
        ["info.born.v"] = [
            "3 December 1969, Puri, Odisha, India",
            "3 décembre 1969, Puri, Odisha, Inde",
            "3. Dezember 1969, Puri, Odisha, Indien",
            "1969年12月3日、インド・オディシャ州プリー"
        ],
        ["info.occupation"] = ["Occupation", "Occupation", "Tätigkeit", "職業"],
        ["info.occupation.v"] = [
            "Stone sculptor; temple architect; master craftsman; teacher",
            "Sculpteur sur pierre ; architecte de temple ; maître artisan ; professeur",
            "Steinbildhauer; Tempelarchitekt; Meisterhandwerker; Lehrer",
            "石彫家、寺院建築家、名匠、師"
        ],
        ["info.known"] = ["Known for", "Connu pour", "Bekannt für", "知られる理由"],
        ["info.known.v"] = [
            "Stone carving; temple construction; multi-coloured stone patchwork",
            "Taille de la pierre ; construction de temples ; patchwork de pierres multicolores",
            "Steinarbeit; Tempelbau; mehrfarbiges Steinpatchwork",
            "石彫、寺院造営、多色石のパッチワーク"
        ],
        ["info.org"] = ["Organization", "Organisation", "Organisation", "所属"],
        ["info.org.v"] = [
            "Mahapatra Handicrafts Emporium",
            "Mahapatra Handicrafts Emporium",
            "Mahapatra Handicrafts Emporium",
            "マハパトラ手工芸エンポリアム"
        ],
        ["info.years"] = ["Years active", "Années d’activité", "Aktiv seit", "活動期間"],
        ["info.years.v"] = ["1985 – present", "1985 – aujourd’hui", "1985 – heute", "1985年 – 現在"],
        ["info.award"] = ["Major award", "Distinction majeure", "Hauptauszeichnung", "主要な賞"],
        ["info.award.v"] = [
            "National Award for Master Craftsperson (2005)",
            "Prix national du maître artisan (2005)",
            "Nationalpreis für Meisterhandwerk (2005)",
            "マスター・クラフツパーソン国家賞（2005）"
        ],
        ["info.nationality"] = ["Nationality", "Nationalité", "Nationalität", "国籍"],
        ["info.nationality.v"] = ["Indian", "Indienne", "Indisch", "インド"],
        ["time.kicker"] = ["Timeline", "Chronologie", "Chronik", "年譜"],
        ["time.title"] = ["A chronology", "Une chronologie", "Eine Chronologie", "年表"],
        ["time.lede"] = [
            "From the learning years in Puri to the National Award, the emporium, and the Padma Shri nomination of 2024.",
            "Des années d’apprentissage à Puri jusqu’au Prix national, à l’emporium et à la nomination Padma Shri de 2024.",
            "Von den Lehrjahren in Puri bis zum Nationalpreis, dem Emporium und der Padma-Shri-Nominierung 2024.",
            "プリーでの修業から、国家賞、エンポリアム、そして2024年のパドマ・シュリー推薦まで。"
        ],
        ["gal.kicker"] = ["Masterpieces", "Chefs-d'œuvre", "Meisterwerke", "作品"],
        ["gal.title"] = ["The gallery", "La galerie", "Die Galerie", "ギャラリー"],
        ["gal.lede"] = [
            "Temple sculptures, sacred images, murals, international projects, rare works and architectural stone. Open a plate to read its material, scale, place and story. Photographs from the atelier archive replace the engraved plates when they are filed.",
            "Sculptures de temple, images sacrées, murales, projets internationaux, œuvres rares et pierre d’architecture. Ouvrez une plaque pour la matière, l’échelle, le lieu et le récit. Les photographies d’archives remplaceront les plaques gravées lorsqu’elles seront versées.",
            "Tempelskulpturen, heilige Bilder, Wandbilder, internationale Projekte, seltene Werke und Architekturstein. Öffnen Sie eine Tafel für Material, Maß, Ort und Geschichte. Archivfotografien ersetzen die gravierten Tafeln, sobald sie vorliegen.",
            "寺院彫刻、神像、壁画、国外の仕事、稀少な作品、建築石材。板を開くと、材料、規模、場所、物語が読めます。工房の写真が納められたとき、彫版に代わります。"
        ],
        ["awards.kicker"] = ["Awards and recognitions", "Distinctions", "Auszeichnungen", "顕彰"],
        ["awards.title"] = ["The honour wall", "Le mur des honneurs", "Die Ehrenwand", "栄誉の壁"],
        ["awards.lede"] = [
            "State, national and institutional recognitions, together with international notice. Certificate scans from the archive appear in the frames when they are placed.",
            "Reconnaissances de l’État, nationales et institutionnelles, et échos internationaux. Les scans de certificats paraissent dans les cadres lorsqu’ils sont déposés.",
            "Anerkennungen des Staates, der Nation und der Institutionen, dazu internationale Beachtung. Zertifikatsscans erscheinen in den Rahmen, sobald sie hinterlegt sind.",
            "州、国、機関の顕彰と、国外からの評価。証明書の画像は、アーカイブに納められたとき枠に入ります。"
        ],
        ["awards.certs"] = ["Certificate archive", "Archives des certificats", "Zertifikatsarchiv", "証明書アーカイブ"],
        ["padma.kicker"] = ["Recognition dossier", "Dossier de reconnaissance", "Anerkennungsdossier", "顕彰記録"],
        ["padma.title"] = ["Padma Shri nomination profile", "Profil de nomination Padma Shri", "Profil der Padma-Shri-Nominierung", "パドマ・シュリー推薦プロフィール"],
        ["padma.lede"] = [
            "A structured public profile gathered in support of the 2024 Padma Shri nomination of Guru Ramakanta Mahapatra.",
            "Un profil public structuré, réuni à l’appui de la nomination Padma Shri 2024 de Guru Ramakanta Mahapatra.",
            "Ein geordnetes öffentliches Profil zur Padma-Shri-Nominierung 2024 von Guru Ramakanta Mahapatra.",
            "2024年のパドマ・シュリー推薦を支えるため編んだ、グル・ラマカンタ・マハパトラの公のプロフィール。"
        ],
        ["padma.note"] = [
            "A nomination proposes a name for India’s civilian honour. It is not the conferment of the Padma Shri. This page does not describe him as a Padma Shri awardee.",
            "Une nomination propose un nom pour l’honneur civil indien. Elle n’est pas la remise du Padma Shri. Cette page ne le présente pas comme lauréat du Padma Shri.",
            "Eine Nominierung schlägt einen Namen für Indiens zivile Ehrung vor. Sie ist nicht die Verleihung des Padma Shri. Diese Seite bezeichnet ihn nicht als Padma-Shri-Träger.",
            "推薦は、インドの市民栄誉への提案です。パドマ・シュリーの授与そのものではありません。このページは、彼をパドマ・シュリー受章者とは記しません。"
        ],
        ["padma.field"] = ["Field", "Domaine", "Feld", "分野"],
        ["padma.field.v"] = [
            "Art — stone sculpture, temple architecture, artisan training",
            "Arts — sculpture sur pierre, architecture de temple, formation d’artisans",
            "Kunst — Steinbildhauerei, Tempelarchitektur, Ausbildung",
            "芸術 — 石彫、寺院建築、職人育成"
        ],
        ["padma.print"] = ["Print this dossier", "Imprimer ce dossier", "Dossier drucken", "この記録を印刷"],
        ["map.kicker"] = ["Global projects", "Projets dans le monde", "Weltprojekte", "世界の仕事"],
        ["map.title"] = ["An atlas of installations", "Un atlas des installations", "Ein Atlas der Installationen", "設置の地図"],
        ["map.lede"] = [
            "Choose a country. Named works are given where this site’s record identifies them. Other countries record the atelier’s international practice without inventing a monument.",
            "Choisissez un pays. Les œuvres nommées figurent lorsque le registre du site les identifie. Les autres pays consignent la pratique internationale sans inventer de monument.",
            "Wählen Sie ein Land. Benannte Werke stehen dort, wo das Register dieser Site sie kennt. Andere Länder verzeichnen die internationale Praxis, ohne ein Denkmal zu erfinden.",
            "国を選んでください。このサイトの記録が名を特定できる仕事は、その名で記します。ほかの国は、存在しない記念碑を作らず、工房の国際的な実践として記します。"
        ],
        ["map.select"] = ["Destinations", "Destinations", "Reiseziele", "行き先"],
        ["academy.kicker"] = ["Guru-Shishya Stone Sculpture Academy", "Académie Guru-Shishya", "Guru-Shishya-Akademie", "グル・シシュヤ石彫学院"],
        ["academy.title"] = [
            "Learn traditional Indian stone sculpting",
            "Apprendre la sculpture traditionnelle indienne sur pierre",
            "Traditionelle indische Steinbildhauerei lernen",
            "インドの伝統石彫を学ぶ"
        ],
        ["academy.lede"] = [
            "Study directly in the practice of National Awardee Guru Ramakanta Mahapatra. The academy is for foreign students as well as Indian makers.",
            "Étudiez directement dans la pratique du lauréat national Guru Ramakanta Mahapatra. L’académie accueille les étudiants étrangers comme les artisans indiens.",
            "Studieren Sie unmittelbar in der Praxis des Nationalpreisträgers Guru Ramakanta Mahapatra. Die Akademie ist für ausländische Studierende wie für indische Meisterschüler offen.",
            "国家賞受賞者グル・ラマカンタ・マハパトラの実践のなかで、直接学びます。学院は海外の学生とインドの作り手の双方に開かれています。"
        ],
        ["academy.features"] = ["What is included", "Ce qui est compris", "Enthalten", "含まれるもの"],
        ["academy.book"] = ["Request a place", "Demander une place", "Einen Platz erbitten", "席を申し込む"],
        ["feat.certificate"] = ["Certificate of the academy", "Certificat de l’académie", "Zertifikat der Akademie", "学院の修了証"],
        ["feat.stay"] = ["Assistance with accommodation", "Aide au logement", "Hilfe bei der Unterkunft", "滞在の手引き"],
        ["feat.tours"] = ["Local cultural tours", "Visites culturelles", "Kulturelle Ausflüge", "土地の文化見学"],
        ["feat.hands"] = ["Hands-on stone carving", "Taille de la pierre en pratique", "Steinarbeit mit der Hand", "手で石を刻む"],
        ["feat.design"] = ["Temple design studies", "Études de dessin de temple", "Tempelzeichnen", "寺院設計の学習"],
        ["store.kicker"] = ["Atelier store", "Boutique de l’atelier", "Atelierkollektion", "工房の受注"],
        ["store.title"] = ["Works for the world", "Des œuvres pour le monde", "Werke für die Welt", "世界のための仕事"],
        ["store.lede"] = [
            "Sacred images, temple ornament, garden guardians, museum studies and architectural panels, prepared in Odisha for international buyers.",
            "Images sacrées, ornement de temple, gardiens de jardin, études de musée et panneaux, préparés en Odisha pour des acheteurs internationaux.",
            "Heilige Bilder, Tempelschmuck, Gartenwächter, Museumsstudien und Platten, in Odisha für internationale Käufer gearbeitet.",
            "オディシャで、国外の求めに応じて準備する聖像、寺院装飾、庭の守護、美術館の習作、建築パネル。"
        ],
        ["store.secure"] = ["Secure settlement", "Règlement sûr", "Sichere Zahlung", "安全な決済"],
        ["store.secure.body"] = [
            "High-value stone is not paid by typing a card number into this website. You receive a proforma invoice. Settlement is by the emporium’s secure payment link or by international transfer, after the work is confirmed.",
            "Une pierre de grande valeur ne se règle pas en saisissant une carte sur ce site. Vous recevez une facture pro forma. Le paiement se fait par le lien sécurisé de l’emporium ou par virement international, une fois l’œuvre confirmée.",
            "Hochwertiger Stein wird nicht bezahlt, indem eine Karte auf dieser Website eingegeben wird. Sie erhalten eine Proforma. Die Zahlung erfolgt über den sicheren Link des Emporiums oder per Auslandsüberweisung, nach Bestätigung.",
            "高価な石は、このサイトにカード番号を入れて支払うものではありません。プロフォーマインボイスが届きます。仕事の確認のあと、エンポリアムの安全な決済リンク、または国際送金で清算します。"
        ],
        ["store.ship"] = ["International shipping", "Expédition internationale", "Internationaler Versand", "国際配送"],
        ["store.ship.body"] = [
            "Works are crated in Odisha. Sea or air freight, insurance and customs papers are arranged with the proforma. Garden and architectural pieces are quoted with their crate.",
            "Les œuvres sont mises en caisse en Odisha. Fret maritime ou aérien, assurance et documents douaniers sont prévus avec la pro forma. Jardins et pièces d’architecture sont devisés avec leur caisse.",
            "Werke werden in Odisha verpackt. See- oder Luftfracht, Versicherung und Zolldokumente stehen in der Proforma. Garten- und Architekturstücke werden mit Kiste angeboten.",
            "作品はオディシャで梱包します。海上または航空、保険、通関書類はプロフォーマに含めます。庭と建築の仕事は梱包込みで見積もります。"
        ],
        ["store.custom"] = ["Custom quotation", "Devis sur mesure", "Individuelles Angebot", "個別見積"],
        ["store.wa"] = ["Order by WhatsApp", "Commander par WhatsApp", "Per WhatsApp bestellen", "WhatsAppで注文"],
        ["store.pay"] = ["Payment link", "Lien de paiement", "Zahlungslink", "決済リンク"],
        ["product.view3d"] = ["Turn the plinth", "Tourner le socle", "Den Sockel drehen", "台座を回す"],
        ["product.story"] = ["Story", "Récit", "Geschichte", "物語"],
        ["product.process"] = ["Crafting process", "Processus", "Arbeitsgang", "制作の過程"],
        ["product.cert"] = ["Certificate of authenticity", "Certificat d’authenticité", "Echtheitszertifikat", "真正証明書"],
        ["product.cert.body"] = [
            "Each confirmed work leaves with an atelier certificate naming Guru Ramakanta Mahapatra, the stone, the scale and a reference. It is the emporium’s document, not a government paper.",
            "Chaque œuvre confirmée part avec un certificat d’atelier au nom de Guru Ramakanta Mahapatra, indiquant la pierre, l’échelle et une référence. C’est le document de l’emporium, non un papier d’État.",
            "Jedes bestätigte Werk verlässt das Atelier mit einem Zertifikat auf den Namen von Guru Ramakanta Mahapatra, mit Stein, Maß und Referenz. Es ist das Dokument des Emporiums, kein Staatspapier.",
            "確定した作品には、グル・ラマカンタ・マハパトラの名、石種、規模、整理番号を記した工房の証明書が付きます。これはエンポリアムの文書であり、政府の証書ではありません。"
        ],
        ["product.add"] = ["Add to enquiry", "Ajouter à la demande", "Zur Anfrage", "問い合わせに加える"],
        ["step.1.t"] = ["Stone", "Pierre", "Stein", "石"],
        ["step.1.b"] = [
            "A block is chosen for grain, colour and the scale of the image.",
            "Un bloc est choisi pour son fil, sa couleur et l’échelle de l’image.",
            "Ein Block wird nach Lager, Farbe und Maß des Bildes gewählt.",
            "石目、色、像の規模に合わせて石を選びます。"
        ],
        ["step.2.t"] = ["Drawing", "Dessin", "Zeichnung", "下絵"],
        ["step.2.b"] = [
            "Proportion and iconography are drawn before the chisel goes deep.",
            "Proportion et iconographie sont dessinées avant que le ciseau n’aille en profondeur.",
            "Proportion und Ikonografie werden gezeichnet, bevor der Meißel tief geht.",
            "鑿を深く入れる前に、比例と図像を描きます。"
        ],
        ["step.3.t"] = ["Roughing", "Dégrossi", "Schroten", "荒彫り"],
        ["step.3.b"] = [
            "The mass is opened and the silhouette is found.",
            "La masse est ouverte et la silhouette est trouvée.",
            "Die Masse wird geöffnet und die Silhouette gefunden.",
            "石の塊を開き、輪郭を見つけます。"
        ],
        ["step.4.t"] = ["Icon", "Icône", "Bild", "像"],
        ["step.4.b"] = [
            "Face, attributes and ornament are brought to the traditional measure.",
            "Visage, attributs et ornement sont amenés à la mesure traditionnelle.",
            "Gesicht, Attribute und Schmuck werden auf das traditionelle Maß gebracht.",
            "顔、持物、装飾を伝統の尺度まで運びます。"
        ],
        ["step.5.t"] = ["Colour in stone", "Couleur dans la pierre", "Farbe im Stein", "石の色"],
        ["step.5.b"] = [
            "Where the work asks for it, stones of different colour are fitted as patchwork.",
            "Lorsque l’œuvre le demande, des pierres de couleurs différentes sont ajustées en patchwork.",
            "Wo das Werk es verlangt, werden Steine verschiedener Farbe als Patchwork gefügt.",
            "仕事が求めるとき、異なる色の石をパッチワークとして嵌めます。"
        ],
        ["step.6.t"] = ["Surface", "Surface", "Oberfläche", "仕上げ"],
        ["step.6.b"] = [
            "The surface is finished so that light describes the form, then the certificate is prepared.",
            "La surface est finie pour que la lumière décrive la forme, puis le certificat est préparé.",
            "Die Oberfläche wird so vollendet, dass Licht die Form beschreibt; dann folgt das Zertifikat.",
            "光が形を語るまで表面を仕上げ、証明書を準備します。"
        ],
        ["cart.title"] = ["Enquiry list", "Liste de demande", "Anfrageliste", "問い合わせ一覧"],
        ["cart.kicker"] = ["Store", "Boutique", "Kollektion", "受注"],
        ["cart.empty"] = [
            "Nothing is listed yet. Choose a work, or write a commission directly.",
            "Rien n’est encore inscrit. Choisissez une œuvre, ou écrivez une commande.",
            "Noch nichts verzeichnet. Wählen Sie ein Werk oder schreiben Sie einen Auftrag.",
            "まだ何もありません。作品を選ぶか、直接注文を書いてください。"
        ],
        ["cart.update"] = ["Update", "Mettre à jour", "Aktualisieren", "更新"],
        ["cart.remove"] = ["Remove", "Retirer", "Entfernen", "外す"],
        ["cart.quote"] = ["Request a proforma", "Demander une pro forma", "Proforma erbitten", "プロフォーマを求める"],
        ["cart.qty"] = ["Quantity", "Quantité", "Menge", "数量"],
        ["cart.continue"] = ["Continue", "Continuer", "Weiter", "続ける"],
        ["quote.kicker"] = ["Proforma", "Pro forma", "Proforma", "プロフォーマ"],
        ["quote.title"] = ["Request a quotation", "Demander un devis", "Ein Angebot erbitten", "見積を依頼する"],
        ["quote.lede"] = [
            "Tell us where the work should stand. The emporium replies with stone, scale, crate and a secure way to settle.",
            "Dites-nous où l’œuvre doit se tenir. L’emporium répond avec la pierre, l’échelle, la caisse et un règlement sûr.",
            "Sagen Sie, wo das Werk stehen soll. Das Emporium antwortet mit Stein, Maß, Kiste und einem sicheren Weg der Zahlung.",
            "作品をどこに置くかを知らせてください。エンポリアムが、石、規模、梱包、安全な決済の方法を返信します。"
        ],
        ["media.kicker"] = ["Media and press", "Médias et presse", "Medien und Presse", "報道"],
        ["media.title"] = ["The public record", "Le registre public", "Der öffentliche Nachweis", "公の記録"],
        ["media.lede"] = [
            "Interviews, news, documentaries, the Padma Shri nomination story and exhibitions. Clippings are filed here as the archive is assembled. The chapters below are the record this site can state today.",
            "Entretiens, presse, documentaires, récit de la nomination Padma Shri et expositions. Les coupures seront versées ici à mesure de l’archive. Les chapitres ci-dessous sont ce que ce site peut affirmer aujourd’hui.",
            "Interviews, Nachrichten, Dokumentarfilme, die Geschichte der Padma-Shri-Nominierung und Ausstellungen. Ausschnitte werden hier abgelegt, während das Archiv wächst. Die Kapitel sind, was diese Site heute sagen kann.",
            "インタビュー、報道、記録映画、パドマ・シュリー推薦の物語、展覧会。切り抜きはアーカイブの整備とともにここに納めます。以下は、このサイトが今日述べられる記録です。"
        ],
        ["work.kicker"] = ["Workshops", "Ateliers", "Werkstätten", "講習"],
        ["work.title"] = ["Book time in the atelier", "Réserver un temps à l’atelier", "Zeit im Atelier buchen", "工房の時間を予約する"],
        ["work.lede"] = [
            "For architects, collectors, foreign visitors, museum curators and art students. Private teaching, groups, a temple architecture tour, or a residency.",
            "Pour architectes, collectionneurs, visiteurs étrangers, conservateurs et étudiants. Cours privé, groupe, parcours d’architecture de temple, ou résidence.",
            "Für Architekten, Sammler, ausländische Gäste, Kuratoren und Studierende. Privatunterricht, Gruppen, ein Tempelarchitekturweg oder eine Residenz.",
            "建築家、蒐集家、外国からの訪問者、美術館学芸員、美術学生のために。個人、団体、寺院建築の見学、または滞在制作。"
        ],
        ["work.book"] = ["Request dates", "Demander des dates", "Daten erbitten", "日程を申し込む"],
        ["aud.architects"] = ["Architects", "Architectes", "Architekten", "建築家"],
        ["aud.collectors"] = ["Collectors", "Collectionneurs", "Sammler", "蒐集家"],
        ["aud.tourists"] = ["Foreign visitors", "Visiteurs étrangers", "Ausländische Gäste", "外国からの訪問者"],
        ["aud.curators"] = ["Museum curators", "Conservateurs", "Museumskuratoren", "学芸員"],
        ["aud.students"] = ["Art students", "Étudiants d’art", "Kunststudierende", "美術学生"],
        ["opt.private"] = ["Private workshop", "Atelier privé", "Private Werkstatt", "個人講習"],
        ["opt.group"] = ["Group workshop", "Atelier de groupe", "Gruppenwerkstatt", "団体講習"],
        ["opt.tour"] = ["Temple architecture tour", "Parcours d’architecture de temple", "Tempelarchitektur-Rundgang", "寺院建築の見学"],
        ["opt.residency"] = ["Artisan residency", "Résidence d’artisan", "Handwerkerresidenz", "職人レジデンシー"],
        ["contact.kicker"] = ["Correspondence", "Correspondance", "Korrespondenz", "書簡"],
        ["contact.title"] = ["Write to the emporium", "Écrire à l’emporium", "An das Emporium schreiben", "エンポリアムへ書く"],
        ["contact.lede"] = [
            "Museums, architects, collectors, governments, students and the press. Mahapatra Handicrafts Emporium, Bhubaneswar, Odisha, India.",
            "Musées, architectes, collectionneurs, gouvernements, étudiants et presse. Mahapatra Handicrafts Emporium, Bhubaneswar, Odisha, Inde.",
            "Museen, Architekten, Sammler, Regierungen, Studierende und Presse. Mahapatra Handicrafts Emporium, Bhubaneswar, Odisha, Indien.",
            "美術館、建築家、蒐集家、政府、学生、報道。インド・オディシャ州ブバネーシュワル、マハパトラ手工芸エンポリアム。"
        ],
        ["contact.address"] = ["Address", "Adresse", "Adresse", "住所"],
        ["contact.phone"] = ["Telephone", "Téléphone", "Telefon", "電話"],
        ["contact.email"] = ["Email", "Courriel", "E-Mail", "メール"],
        ["contact.whatsapp"] = ["WhatsApp", "WhatsApp", "WhatsApp", "WhatsApp"],
        ["contact.map"] = ["Map", "Carte", "Karte", "地図"],
        ["contact.absent"] = [
            "Issued with a confirmed enquiry. Use the form and the emporium will reply.",
            "Communiqué avec une demande confirmée. Utilisez le formulaire ; l’emporium répondra.",
            "Wird mit einer bestätigten Anfrage mitgeteilt. Nutzen Sie das Formular; das Emporium antwortet.",
            "問い合わせが確定したのちにお伝えします。フォームから書けば、エンポリアムが返信します。"
        ],
        ["contact.openmap"] = ["Open the map", "Ouvrir la carte", "Karte öffnen", "地図を開く"],
        ["topic.buy"] = ["Buy artwork", "Acheter une œuvre", "Werk erwerben", "作品を求める"],
        ["topic.temple"] = ["Commission a temple", "Commander un temple", "Einen Tempel beauftragen", "寺院を発注する"],
        ["topic.learn"] = ["Learn sculpture", "Apprendre la sculpture", "Bildhauerei lernen", "彫刻を学ぶ"],
        ["topic.exhibit"] = ["Invite an exhibition", "Inviter une exposition", "Eine Ausstellung einladen", "展覧会を招く"],
        ["topic.media"] = ["Media enquiry", "Demande de presse", "Presseanfrage", "取材"],
        ["donate.kicker"] = ["Heritage fund", "Fonds du patrimoine", "Erbschaftsfonds", "遺産基金"],
        ["donate.title"] = [
            "Support traditional Indian stone sculpture",
            "Soutenir la sculpture traditionnelle indienne sur pierre",
            "Traditionelle indische Steinbildhauerei stützen",
            "インドの伝統石彫を支える"
        ],
        ["donate.lede"] = [
            "A pledge toward student stone, tools, and the keeping of the guru-shishya line. Nothing is charged on this page. The emporium confirms the gift and only then issues transfer details.",
            "Une intention de don pour la pierre des élèves, les outils, et la lignée guru-shishya. Rien n’est débité sur cette page. L’emporium confirme, puis seulement alors indique le virement.",
            "Eine Zusage für Stein und Werkzeug der Schüler und für die Guru-Shishya-Linie. Auf dieser Seite wird nichts abgebucht. Das Emporium bestätigt, und erst dann folgen die Überweisungsdaten.",
            "生徒の石と道具、師弟の系譜を守るための誓約です。このページでは決済しません。エンポリアムが確認したのちに、送金の案内を出します。"
        ],
        ["donate.tier1"] = ["Student stone", "Pierre d’élève", "Stein für Schüler", "生徒の石"],
        ["donate.tier1.b"] = ["A block and tools for a learner.", "Un bloc et des outils pour un élève.", "Ein Block und Werkzeug für einen Lernenden.", "学ぶ人のための石と道具。"],
        ["donate.tier2"] = ["Scholarship", "Bourse", "Stipendium", "奨学金"],
        ["donate.tier2.b"] = ["A month of foundation teaching.", "Un mois d’enseignement de fond.", "Ein Monat Grundlagenunterricht.", "基礎課程の一か月。"],
        ["donate.tier3"] = ["Heritage", "Patrimoine", "Erbe", "遺産"],
        ["donate.tier3.b"] = ["Support the wider craftsmen’s community.", "Soutenir la communauté plus large des artisans.", "Die weitere Handwerkergemeinschaft stützen.", "より広い職人共同体を支える。"],
        ["donate.pledge"] = ["Make a pledge", "Déposer une intention", "Eine Zusage geben", "誓約する"],
        ["tour.kicker"] = ["Virtual museum", "Musée virtuel", "Virtuelles Museum", "仮想美術館"],
        ["tour.title"] = ["A walk through six rooms", "Une marche en six salles", "Ein Gang durch sechs Räume", "六つの部屋を歩く"],
        ["tour.lede"] = [
            "A quiet sequence through the practice: threshold, sacred image, temple, the world, the teaching floor, and the honour wall. Use the room index or scroll.",
            "Une suite calme : seuil, image sacrée, temple, monde, salle d’enseignement, mur des honneurs. Utilisez l’index ou faites défiler.",
            "Eine ruhige Folge: Schwelle, heiliges Bild, Tempel, Welt, Unterricht, Ehrenwand. Nutzen Sie das Register oder scrollen Sie.",
            "静かな順路です。閾、聖像、寺院、世界、教える床、栄誉の壁。部屋の索引か、スクロールを使ってください。"
        ],
        ["tour.room"] = ["Room", "Salle", "Raum", "部屋"],
        ["exp.kicker"] = ["360° workshop", "Atelier à 360°", "Werkstatt 360°", "工房360°"],
        ["exp.title"] = ["Turn through the workshop", "Tourner dans l’atelier", "Durch die Werkstatt drehen", "工房を見渡す"],
        ["exp.lede"] = [
            "Six stations of the working day. Drag or scroll the floor. This is a spatial guide to the practice; the photographic panorama is filed when the atelier film is ready.",
            "Six stations de la journée. Faites glisser ou défiler. C’est un guide spatial ; le panorama photographique sera versé avec le film de l’atelier.",
            "Sechs Stationen des Arbeitstags. Ziehen oder scrollen Sie. Dies ist ein räumlicher Führer; das Fotopanorama folgt mit dem Film des Ateliers.",
            "仕事の一日の六つの場所。ドラッグするか、横に送ってください。これは空間の案内です。写真のパノラマは、工房の映像が整ったときに納めます。"
        ],
        ["exp.drag"] = ["Drag to look", "Glisser pour regarder", "Ziehen zum Schauen", "ドラッグして見る"],
        ["form.name"] = ["Name", "Nom", "Name", "名前"],
        ["form.email"] = ["Email", "Courriel", "E-Mail", "メール"],
        ["form.phone"] = ["Telephone", "Téléphone", "Telefon", "電話"],
        ["form.country"] = ["Country", "Pays", "Land", "国"],
        ["form.message"] = ["Message", "Message", "Nachricht", "本文"],
        ["form.topic"] = ["Enquiry", "Demande", "Anliegen", "用件"],
        ["form.program"] = ["Course", "Cours", "Kurs", "課程"],
        ["form.option"] = ["Format", "Format", "Format", "形式"],
        ["form.amount"] = ["Pledge amount (INR)", "Montant envisagé (INR)", "Zugesagter Betrag (INR)", "誓約額（INR）"],
        ["form.submit"] = ["Send", "Envoyer", "Senden", "送る"],
        ["form.sent"] = [
            "The emporium has your letter. Reference",
            "L’emporium a votre lettre. Référence",
            "Das Emporium hat Ihren Brief. Referenz",
            "エンポリアムが書簡を受け取りました。整理番号"
        ],
        ["form.err.name"] = ["Please write your name.", "Écrivez votre nom.", "Bitte Ihren Namen.", "お名前を書いてください。"],
        ["form.err.email"] = ["Please write a valid email.", "Écrivez un courriel valide.", "Bitte eine gültige E-Mail.", "有効なメールを書いてください。"],
        ["form.err.message"] = ["Please write a few words more.", "Écrivez encore quelques mots.", "Bitte noch einige Worte.", "もう少し書いてください。"],
        ["form.err.program"] = ["Choose a course.", "Choisissez un cours.", "Wählen Sie einen Kurs.", "課程を選んでください。"],
        ["form.err.option"] = ["Choose a format.", "Choisissez un format.", "Wählen Sie ein Format.", "形式を選んでください。"],
        ["form.err.limit"] = [
            "Too many letters from this network just now. Please wait a while.",
            "Trop de lettres depuis ce réseau. Veuillez patienter.",
            "Zu viele Briefe aus diesem Netz. Bitte warten Sie.",
            "このネットワークからの送信が続いています。しばらくお待ちください。"
        ],
        ["form.honeypot"] = ["Leave this empty", "Laissez vide", "Leer lassen", "空のまま"],
        ["privacy.title"] = ["Privacy", "Confidentialité", "Datenschutz", "個人情報"],
        ["privacy.body"] = [
            "Letters sent through this site — enquiries, course requests, workshop dates, quotations and pledges — are stored for the emporium to answer you. They are not sold. Write again and ask for a letter to be deleted, and it will be removed from the atelier file. This site does not take card numbers. Settlement, when a work is confirmed, happens on the emporium’s own payment link or by bank transfer.",
            "Les lettres envoyées ici — demandes, cours, ateliers, devis et intentions de don — sont conservées pour que l’emporium vous réponde. Elles ne sont pas vendues. Écrivez de nouveau pour demander l’effacement, et la lettre sera retirée du fichier de l’atelier. Ce site ne prend pas de numéros de carte. Le règlement, une fois l’œuvre confirmée, se fait sur le lien de paiement de l’emporium ou par virement.",
            "Briefe über diese Site — Anfragen, Kurse, Werkstätten, Angebote und Zusagen — werden gespeichert, damit das Emporium antworten kann. Sie werden nicht verkauft. Schreiben Sie erneut und bitten Sie um Löschung; der Brief wird aus der Atelierdatei genommen. Diese Site nimmt keine Kartennummern. Die Zahlung erfolgt nach Bestätigung über den Link des Emporiums oder per Überweisung.",
            "このサイトから送られた書簡（問い合わせ、課程、講習、見積、誓約）は、エンポリアムが返信するために保管します。販売はしません。削除を求めれば、工房のファイルから除きます。このサイトはカード番号を受け取りません。作品が確定したのちの支払いは、エンポリアムの決済リンクまたは銀行送金です。"
        ],
        ["nf.title"] = ["This path is not in the atelier", "Ce chemin n’est pas dans l’atelier", "Dieser Weg ist nicht im Atelier", "この道は工房にありません"],
        ["nf.body"] = [
            "The page may have moved. The index below will take you back to the work.",
            "La page a peut-être bougé. L’index ci-dessous vous ramène au travail.",
            "Die Seite ist vielleicht verzogen. Das Register unten führt zurück zur Arbeit.",
            "ページは移ったかもしれません。下の目次から仕事へ戻ってください。"
        ],
        ["err.title"] = ["The atelier stumbled", "L’atelier a trébuché", "Das Atelier ist gestolpert", "工房がつまずきました"],
        ["err.body"] = [
            "Something failed while preparing this page. Please return home and try again.",
            "Quelque chose a échoué en préparant cette page. Revenez à l’accueil.",
            "Beim Vorbereiten dieser Seite ist etwas fehlgeschlagen. Bitte kehren Sie zum Start zurück.",
            "このページの準備中に誤りがありました。ホームに戻って、もう一度お試しください。"
        ],
        ["seo.home"] = [
            "Guru Ramakanta Mahapatra, National Award stone sculptor of Odisha. Temple sculpture, masterpieces, an international atelier store, and the Guru-Shishya Stone Sculpture Academy.",
            "Guru Ramakanta Mahapatra, sculpteur sur pierre lauréat national en Odisha. Sculpture de temple, chefs-d’œuvre, boutique internationale et académie Guru-Shishya.",
            "Guru Ramakanta Mahapatra, Nationalpreisträger der Steinbildhauerei aus Odisha. Tempelskulptur, Meisterwerke, internationale Kollektion und Guru-Shishya-Akademie.",
            "オディシャの国家賞石彫家、グル・ラマカンタ・マハパトラ。寺院彫刻、作品、国外向けの受注、グル・シシュヤ石彫学院。"
        ],
        ["seo.bio"] = [
            "Biography of Guru Ramakanta Mahapatra, born 3 December 1969 in Puri, Odisha. National Award for Master Craftsperson, 2005. Temple sculptor and teacher.",
            "Biographie de Guru Ramakanta Mahapatra, né le 3 décembre 1969 à Puri, Odisha. Prix national du maître artisan, 2005.",
            "Biografie von Guru Ramakanta Mahapatra, geboren am 3. Dezember 1969 in Puri, Odisha. Nationalpreis 2005.",
            "1969年12月3日プリー生まれ、グル・ラマカンタ・マハパトラの経歴。2005年国家賞。"
        ],
        ["seo.timeline"] = [
            "Chronology of Ramakanta Mahapatra from the 1970s to the 2024 Padma Shri nomination.",
            "Chronologie de Ramakanta Mahapatra, des années 1970 à la nomination Padma Shri de 2024.",
            "Chronik von Ramakanta Mahapatra von den 1970er Jahren bis zur Padma-Shri-Nominierung 2024.",
            "1970年代から2024年のパドマ・シュリー推薦までの年譜。"
        ],
        ["seo.gallery"] = [
            "Masterpieces by Ramakanta Mahapatra: Viswaroop Darsan, Dasavatara, Singapore shrines, Perumal Mandapam, the Ashokan pillar in Japan, and the Odisha heritage gate.",
            "Chefs-d’œuvre de Ramakanta Mahapatra : Viswaroop Darsan, Dasavatara, sanctuaires de Singapour, Perumal Mandapam, pilier d’Ashoka au Japon, porte patrimoniale d’Odisha.",
            "Meisterwerke von Ramakanta Mahapatra: Viswaroop Darsan, Dasavatara, Schreine in Singapur, Perumal Mandapam, Ashoka-Säule in Japan und das Erbe-Tor in Odisha.",
            "ラマカンタ・マハパトラの作品。ヴィシュワループ、ダシャーヴァターラ、シンガポールの祠堂、ペルマル・マンダパム、日本のアショーカ石柱、オディシャの遺産の門。"
        ],
        ["seo.awards"] = [
            "Awards of Ramakanta Mahapatra: Odisha State Award 1990, Lalit Kala Academy Award 1997, National Award 2005, STONA, Guru Samrat, Nitya Nutan Samman.",
            "Distinctions de Ramakanta Mahapatra : prix de l’Odisha 1990, Lalit Kala 1997, prix national 2005, STONA, Guru Samrat, Nitya Nutan Samman.",
            "Auszeichnungen von Ramakanta Mahapatra: Odisha 1990, Lalit Kala 1997, Nationalpreis 2005, STONA, Guru Samrat, Nitya Nutan Samman.",
            "ラマカンタ・マハパトラの顕彰。1990年州賞、1997年ラリット・カラ、2005年国家賞、ストーナ、グル・サムラート、ニティヤ・ヌタン。"
        ],
        ["seo.padma"] = [
            "Padma Shri nomination profile of Guru Ramakanta Mahapatra, National Awardee stone sculptor of Odisha.",
            "Profil de nomination Padma Shri de Guru Ramakanta Mahapatra, sculpteur lauréat national de l’Odisha.",
            "Padma-Shri-Nominierungsprofil von Guru Ramakanta Mahapatra, Nationalpreisträger aus Odisha.",
            "オディシャの国家賞石彫家、グル・ラマカンタ・マハパトラのパドマ・シュリー推薦プロフィール。"
        ],
        ["seo.projects"] = [
            "Stone sculpture installations of the Mahapatra atelier in India, Japan, Singapore, Italy, Thailand, Russia, the USA and Israel.",
            "Installations de l’atelier Mahapatra en Inde, au Japon, à Singapour, en Italie, en Thaïlande, en Russie, aux États-Unis et en Israël.",
            "Installationen des Ateliers Mahapatra in Indien, Japan, Singapur, Italien, Thailand, Russland, den USA und Israel.",
            "インド、日本、シンガポール、イタリア、タイ、ロシア、米国、イスラエルにおけるマハパトラ工房の設置。"
        ],
        ["seo.academy"] = [
            "Guru-Shishya Stone Sculpture Academy. Learn stone carving in Odisha with National Awardee Ramakanta Mahapatra. Courses from one week to one year.",
            "Académie Guru-Shishya. Apprendre la taille de la pierre en Odisha avec Ramakanta Mahapatra. Cours d’une semaine à un an.",
            "Guru-Shishya-Akademie. Steinbildhauerei in Odisha bei Ramakanta Mahapatra lernen. Kurse von einer Woche bis zu einem Jahr.",
            "グル・シシュヤ石彫学院。オディシャで国家賞のラマカンタ・マハパトラに石彫を学ぶ。一週間から一年。"
        ],
        ["seo.store"] = [
            "Atelier store of Mahapatra Arts. Custom stone sculpture, Ganesha, Krishna, temple decor, garden works and museum studies. International shipping.",
            "Boutique de Mahapatra Arts. Sculpture sur pierre sur mesure, Ganesha, Krishna, décor de temple, jardin et études de musée. Expédition internationale.",
            "Kollektion von Mahapatra Arts. Stein auf Maß, Ganesha, Krishna, Tempelschmuck, Garten und Museumsstudien. Internationaler Versand.",
            "マハパトラ・アーツの受注。注文石彫、ガネーシャ、クリシュナ、寺院装飾、庭、美術館習作。国際配送。"
        ],
        ["seo.media"] = [
            "Press and public record of stone sculptor Ramakanta Mahapatra: interviews, exhibitions and the Padma Shri nomination.",
            "Presse et registre public du sculpteur Ramakanta Mahapatra.",
            "Presse und öffentlicher Nachweis des Bildhauers Ramakanta Mahapatra.",
            "石彫家ラマカンタ・マハパトラの報道と公の記録。"
        ],
        ["seo.workshops"] = [
            "Book a stone sculpture workshop in Odisha with Guru Ramakanta Mahapatra. Private, group, temple tour or artisan residency.",
            "Réserver un atelier de sculpture sur pierre en Odisha avec Guru Ramakanta Mahapatra.",
            "Eine Steinbildhauer-Werkstatt in Odisha bei Guru Ramakanta Mahapatra buchen.",
            "オディシャでグル・ラマカンタ・マハパトラの石彫講習を予約する。"
        ],
        ["seo.contact"] = [
            "Contact Mahapatra Handicrafts Emporium, Bhubaneswar, Odisha, for commissions, exhibitions, study and press.",
            "Contacter le Mahapatra Handicrafts Emporium à Bhubaneswar pour commandes, expositions, études et presse.",
            "Mahapatra Handicrafts Emporium in Bhubaneswar kontaktieren für Aufträge, Ausstellungen, Studium und Presse.",
            "ブバネーシュワルのマハパトラ手工芸エンポリアムへ。注文、展覧会、学習、取材。"
        ],
        ["seo.donate"] = [
            "Support traditional Indian stone sculpture heritage through the Mahapatra atelier academy.",
            "Soutenir le patrimoine de la sculpture traditionnelle indienne sur pierre.",
            "Das Erbe traditioneller indischer Steinbildhauerei stützen.",
            "インドの伝統石彫の遺産を、マハパトラ工房の学院を通して支える。"
        ],
        ["seo.tour"] = [
            "Virtual museum tour of the Mahapatra Arts atelier: sacred image, temple, teaching and honours.",
            "Visite virtuelle du musée de l’atelier Mahapatra Arts.",
            "Virtueller Rundgang durch das Atelier Mahapatra Arts.",
            "マハパトラ・アーツ工房の仮想美術館。"
        ],
        ["seo.experience"] = [
            "A 360 degree guide to the stone carving workshop of Guru Ramakanta Mahapatra.",
            "Guide à 360 degrés de l’atelier de Guru Ramakanta Mahapatra.",
            "Ein 360-Grad-Führer durch die Werkstatt von Guru Ramakanta Mahapatra.",
            "グル・ラマカンタ・マハパトラの石彫工房を360度で案内します。"
        ],
        ["seo.search"] = [
            "Search the Mahapatra Arts gallery, store, awards and academy.",
            "Rechercher dans la galerie, la boutique, les prix et l’académie Mahapatra Arts.",
            "Suche in Galerie, Kollektion, Auszeichnungen und Akademie von Mahapatra Arts.",
            "マハパトラ・アーツのギャラリー、受注、顕彰、学院を検索する。"
        ],
        ["seo.cart"] = ["Your enquiry list at Mahapatra Arts.", "Votre liste de demande.", "Ihre Anfrageliste.", "問い合わせ一覧。"],
        ["seo.quote"] = ["Request a proforma invoice from Mahapatra Handicrafts Emporium.", "Demander une facture pro forma.", "Eine Proforma erbitten.", "プロフォーマを依頼する。"],
        ["seo.privacy"] = ["How Mahapatra Arts keeps enquiry letters.", "Comment Mahapatra Arts conserve les lettres.", "Wie Mahapatra Arts Briefe verwahrt.", "マハパトラ・アーツが書簡を扱う方法。"],
        ["keywords"] = [
            "Ramakanta Mahapatra, National Award Sculptor, Stone Sculptor India, Temple Sculpture Artist, Odisha Sculptor, Indian Stone Carving, Custom Stone Sculpture, Temple Architect India, Sculpture Workshop India, Learn Stone Carving India",
            "Ramakanta Mahapatra, sculpteur prix national, sculpture sur pierre Inde, temple, Odisha, atelier",
            "Ramakanta Mahapatra, Nationalpreis Bildhauer, Steinbildhauer Indien, Tempel, Odisha, Werkstatt",
            "ラマカンタ・マハパトラ, 国家賞, 石彫, インド, 寺院, オディシャ, 講習"
        ]
    };

    public static IEnumerable<string[]> Rows => Map.Values;

    public static bool Has(string key) => Map.ContainsKey(key);

    public static string Get(string? culture, string key)
    {
        if (!Map.TryGetValue(key, out var row)) return "⟦" + key + "⟧";
        var index = culture switch
        {
            "fr" => 1,
            "de" => 2,
            "ja" => 3,
            _ => 0
        };
        var value = index < row.Length ? row[index] : "";
        return string.IsNullOrWhiteSpace(value) ? row[0] : value;
    }
}
