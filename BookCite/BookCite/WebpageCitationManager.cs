using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using static BOOKCITE.JournalCitationManager;

namespace BOOKCITE
{
    public class WebpageCitationManager
    {
        public class WebMetadata
        {
            public string Title { get; set; }
            public string Authors { get; set; }
            public int PublicationYear { get; set; }
            public int PublicationMonth { get; set; }
            public int PublicationDay { get; set; }
            public string Publisher { get; set; }
            public string WebUrl { get; set; }
        }
        public enum CitationStyle
        {
            APA,
            CMOS,
            IEEE,
            MLA
        }
        private static List<WebMetadata> citations = new List<WebMetadata>();
        public static void WebAPA()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tWebpage Reference (APA)\n");
                Console.WriteLine("1. Add Citation");
                Console.WriteLine("2. Display Citations");
                Console.WriteLine("3. Change Citation Style");
                Console.WriteLine("4. Main Menu");

                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCitation(CitationStyle.APA);
                        break;
                    case "2":
                        DisplayCitations(CitationStyle.APA);
                        break;
                    case "3":
                        WebpageCitation.Run();
                        break;
                    case "4":
                        MainMenu.Run();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void WebCMOS()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tWebpage Reference (CMOS)\n");
                Console.WriteLine("1. Add Citation");
                Console.WriteLine("2. Display Citation");
                Console.WriteLine("3. Change Citation Style");
                Console.WriteLine("4. Main Menu");

                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCitation(CitationStyle.CMOS);
                        break;
                    case "2":
                        DisplayCitations(CitationStyle.CMOS);
                        break;
                    case "3":
                        WebpageCitation.Run();
                        break;
                    case "4":
                        MainMenu.Run();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public static void WebIEEE()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tWebpage Reference (IEEE)\n");
                Console.WriteLine("1. Add Citation");
                Console.WriteLine("2. Display Citation");
                Console.WriteLine("3. Change Citation Style");
                Console.WriteLine("4. Main Menu");

                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCitation(CitationStyle.IEEE);
                        break;
                    case "2":
                        DisplayCitations(CitationStyle.IEEE);
                        break;
                    case "3":
                        WebpageCitation.Run();
                        break;
                    case "4":
                        MainMenu.Run();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public static void WebMLA()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tWebpage Referenece (MLA)\n");
                Console.WriteLine("1. Add Citation");
                Console.WriteLine("2. Display Citation");
                Console.WriteLine("3. Change Citation Style");
                Console.WriteLine("4. Main Menu");

                Console.Write("\nSelect an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCitation(CitationStyle.MLA);
                        break;
                    case "2":
                        DisplayCitations(CitationStyle.MLA);
                        break;
                    case "3":
                        WebpageCitation.Run();
                        break;
                    case "4":
                        MainMenu.Run();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        private static void AddCitation(CitationStyle style)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("1. Input link/url");
            Console.WriteLine("2. Manually input citation details");
            Console.WriteLine("3. Back");
            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nEnter the link to the webpage:");
                    string webUrl = Console.ReadLine();
                    Console.WriteLine();

                    WebMetadata metadata = GetWebMetadata(webUrl);

                    if (metadata != null)
                    {
                        metadata.Title = ConvertFirstLetterToUpperCase(metadata.Title);
                        metadata.Authors = ConvertFirstLetterToUpperCase(metadata.Authors);

                        citations.Add(metadata);
                        Console.WriteLine("Citation added successfully. Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Unable to fetch metadata from the provided link. Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;

                case "2":
                    Console.Clear();
                    WebMetadata manualMetadata = new WebMetadata();
                    manualMetadata.Title = ReadNonEmptyInput("\nTitle:");
                    manualMetadata.Title = ConvertFirstLetterToUpperCase(manualMetadata.Title);

                    manualMetadata.Authors = ReadNonEmptyStringWithoutNumbers("\nAuthor/s (comma-separated if 2 or more):");
                    manualMetadata.Authors = ConvertFirstLetterToUpperCase(manualMetadata.Authors);

                    manualMetadata.Publisher = ReadNonEmptyInput("\nPublisher/Website:");
                    manualMetadata.Publisher = ConvertFirstLetterToUpperCase(manualMetadata.Publisher);

                    while (true)
                    {
                        Console.Write("\nPublication year: ");
                        if (int.TryParse(Console.ReadLine(), out int manualPublicationYear))
                        {
                            manualMetadata.PublicationYear = manualPublicationYear;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter a valid year.");
                        }
                    }

                    while (true)
                    {
                        Console.Write("Publication month (1-12): ");
                        if (int.TryParse(Console.ReadLine(), out int manualPublicationMonth) && manualPublicationMonth >= 1 && manualPublicationMonth <= 12)
                        {
                            manualMetadata.PublicationMonth = manualPublicationMonth;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter a valid month (1-12).");
                        }
                    }

                    while (true)
                    {
                        Console.Write("Publication day: ");
                        if (int.TryParse(Console.ReadLine(), out int manualPublicationDay) && manualPublicationDay >= 1 && manualPublicationDay <= 31)
                        {
                            manualMetadata.PublicationDay = manualPublicationDay;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter a valid day (1-31).");
                        }
                    }

                    while (true)
                    {
                        Console.Write("\nUrl: ");
                        string urlInput = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(urlInput))
                        {
                            manualMetadata.WebUrl = urlInput;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! URL cannot be blank.");
                        }
                    }
                    citations.Add(manualMetadata);
                    Console.WriteLine("\nCitation added successfully. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
        private static void DeleteCitation(CitationStyle style)
        {
            if (citations.Count == 0)
            {
                Console.WriteLine("No citations to delete. Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            while (true)
            {
                Console.Write("Enter the index of the citation to delete: ");
                if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= citations.Count)
                {
                    citations.RemoveAt(index - 1);

                    Console.WriteLine("Citation deleted successfully. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.WriteLine("Index not found.");
                }
            }
        }
        private static void DisplayCitations(CitationStyle style)
        {
            Console.Clear();

            Console.WriteLine("┌──────────────┐┌──────────────┐┌──────────────┐┌──────────────┐");
            Console.WriteLine("│   [A] ADD    ││  [B] DELETE  ||   [C] BACK   ||   [S] SAVE   |");
            Console.WriteLine("└──────────────┘└──────────────┘└──────────────┘└──────────────┘");

            List<string> wcitations = new List<string>();
            Console.WriteLine();
            Console.WriteLine($"\tWebpage References ({style}):");
            for (int i = 0; i < citations.Count; i++)
            {
                string wcitation;
                if (style == CitationStyle.IEEE)
                {
                    Console.WriteLine($"{i + 1}. [{i + 1}] {GenerateCitation(citations[i], style)}");
                    wcitation = $"[{i + 1}] {GenerateCitation(citations[i], style)}";

                }
                else
                {
                    Console.WriteLine($"{i + 1}. {GenerateCitation(citations[i], style)}");
                    wcitation = $"{GenerateCitation(citations[i], style)}";
                }
                wcitations.Add(wcitation);
            }

            try
            {
                Console.Write("\nSelect an option: ");
                char choice = char.ToUpper(Console.ReadLine().Trim()[0]);

                switch (choice)
                {
                    case 'A':
                        AddCitation(style);
                        break;
                    case 'B':
                        DeleteCitation(style);
                        break;
                    case 'S':
                        SaveReferencesToFile(wcitations);
                        SaveReferencesInputsToFile();
                        break;
                    case 'C':
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.Clear();
            }

        }
        private static string GenerateCitation(WebMetadata metadata, CitationStyle style)
        {
            switch (style)
            {
                case CitationStyle.APA:
                    return GenerateAPACitation(metadata);
                case CitationStyle.CMOS:
                    return GenerateCMOSCitation(metadata);
                case CitationStyle.IEEE:
                    return GenerateIEEECitation(metadata);
                case CitationStyle.MLA:
                    return GenerateMLACitation(metadata);
                default:
                    throw new ArgumentException("Invalid citation style");
            }
        }
        private static WebMetadata GetWebMetadata(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                string title = doc.DocumentNode.SelectSingleNode("//title")?.InnerText;
                string authors = doc.DocumentNode.SelectSingleNode("//meta[@name='author']")?.Attributes["content"]?.Value;
                string publicationDate = doc.DocumentNode.SelectSingleNode("//meta[@name='pubdate']")?.Attributes["content"]?.Value;
                string publisher = doc.DocumentNode.SelectSingleNode("//meta[@name='publisher']")?.Attributes["content"]?.Value;

                DateTime publicationDateTime = DateTime.MinValue;
                if (!string.IsNullOrWhiteSpace(publicationDate) && DateTime.TryParse(publicationDate, out publicationDateTime))
                {
                    return new WebMetadata
                    {
                        Title = title ?? "",
                        Authors = authors ?? "",
                        PublicationYear = publicationDateTime.Year,
                        PublicationMonth = publicationDateTime.Month,
                        PublicationDay = publicationDateTime.Day,
                        Publisher = publisher ?? "",
                        WebUrl = url
                    };
                }
                return new WebMetadata
                {
                    Title = title ?? "",
                    Authors = authors ?? "",
                    PublicationYear = DateTime.Now.Year,
                    Publisher = publisher ?? "",
                    WebUrl = url
                };
            }
            catch (HtmlWebException ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Error loading HTML content: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return null;
        }
        private static string GenerateAPACitation(WebMetadata metadata)
        {
            string[] authorNames = metadata.Authors.Split(',');

            if (authorNames.Length == 1)
            {
                return $"{FormatAPAName(authorNames[0].Trim())} ({GetFormattedPublicationDate(metadata)}). {metadata.Title}. {metadata.Publisher}. {metadata.WebUrl}";
            }
            else if (authorNames.Length == 2)
            {
                return $"{FormatAPAName(authorNames[0].Trim())} & {FormatAPAName(authorNames[1].Trim())} ({GetFormattedPublicationDate(metadata)}). {metadata.Title}. {metadata.Publisher}. {metadata.WebUrl}";
            }
            else
            {
                return $"{FormatAPAName(authorNames[0].Trim())}, et al. ({GetFormattedPublicationDate(metadata)}). {metadata.Title}. {metadata.Publisher}. {metadata.WebUrl}";
            }

        }
        private static string GenerateCMOSCitation(WebMetadata metadata)
        {
            string[] authorNames = metadata.Authors.Split(',');

            if (authorNames.Length == 1)
            {
                return $"{FormatCMOSName(authorNames[0].Trim())}. \"{metadata.Title}\". {metadata.Publisher}. {metadata.WebUrl}. {GetFormattedPublicationDate(metadata)}";
            }
            else if (authorNames.Length == 2)
            {
                return $"{FormatCMOSName(authorNames[0].Trim())} and {FormatCMOSName(authorNames[1].Trim())}. \"{metadata.Title}\". {metadata.Publisher}. {metadata.WebUrl}. {GetFormattedPublicationDate(metadata)}";
            }
            else
            {
                return $"{FormatCMOSName(authorNames[0].Trim())}, et al. \"{metadata.Title}\". {metadata.Publisher}. {metadata.WebUrl}. {GetFormattedPublicationDate(metadata)}";
            }


        }
        private static string GenerateIEEECitation(WebMetadata metadata)
        {
            string[] authorNames = metadata.Authors.Split(',');

            if (authorNames.Length == 1)
            {
                return $"{FormatIEEEName(authorNames[0].Trim())}. \"{metadata.Title}\". {metadata.Publisher}. {metadata.WebUrl}";
            }
            else if (authorNames.Length == 2)
            {
                return $"{FormatIEEEName(authorNames[0].Trim())} and {FormatIEEEName(authorNames[1].Trim())}. \"{metadata.Title}\". {metadata.Publisher}. {metadata.WebUrl}";
            }
            else
            {
                return $"{FormatIEEEName(authorNames[0].Trim())}, et al. \"{metadata.Title}\". {metadata.Publisher}. {metadata.WebUrl}";
            }
        }
        private static string GenerateMLACitation(WebMetadata metadata)
        {
            string[] authorNames = metadata.Authors.Split(',');

            if (authorNames.Length == 1)
            {
                return $"{FormatMLAName(authorNames[0].Trim())}. \"{metadata.Title}\". {metadata.Publisher}. {GetFormattedPublicationDate(metadata)}, {metadata.WebUrl}.";
            }
            else if (authorNames.Length == 2)
            {
                return $"{FormatMLAName(authorNames[0].Trim())} and {FormatMLAName(authorNames[1].Trim())}. \"{metadata.Title}\". {metadata.Publisher}. {GetFormattedPublicationDate(metadata)}, {metadata.WebUrl}.";
            }
            else
            {
                return $"{FormatMLAName(authorNames[0].Trim())}, et al. \"{metadata.Title}\". {metadata.Publisher}. {GetFormattedPublicationDate(metadata)}, {metadata.WebUrl}.";
            }
        }
        private static string GetFormattedPublicationDate(WebMetadata metadata)
        {
            if (metadata.PublicationDay > 0 && metadata.PublicationMonth > 0)
            {
                return $"{metadata.PublicationDay:D2} {GetMonthName(metadata.PublicationMonth)} {metadata.PublicationYear}";
            }
            else if (metadata.PublicationMonth > 0)
            {
                return $"{GetMonthName(metadata.PublicationMonth)} {metadata.PublicationYear}";
            }
            else if (metadata.PublicationYear > 0)
            {
                return metadata.PublicationYear.ToString();
            }
            else
            {
                return "Unknown Date";
            }
        }
        private static string GetMonthName(int month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }
        private static string FormatAPAName(string authorName)
        {
            string[] names = authorName.Split(' ');

            if (names.Length >= 2)
            {
                return $"{names[^1]}, {string.Join(" ", names.Take(names.Length - 1).Select(n => $"{n.Substring(0, 1)}. "))}";
            }
            return authorName;
        }
        private static string FormatCMOSName(string authorName)
        {
            string[] names = authorName.Split(' ');

            if (names.Length >= 2)
            {
                return $"{names[^1]}, {string.Join(" ", names.Take(names.Length - 1))}";
            }
            return authorName;
        }
        private static string FormatIEEEName(string authorName)
        {
            string[] names = authorName.Split(' ');

            if (names.Length >= 2)
            {
                return $"{names[0].Substring(0, 1)}. {names[^1]}";
            }

            return authorName;
        }
        private static string FormatMLAName(string authorName)
        {
            string[] names = authorName.Split(' ');

            if (names.Length >= 2)
            {
                return $"{names[^1]}, {string.Join(" ", names.Take(names.Length - 1))}";
            }
            return authorName;
        }
        private static string ReadNonEmptyInput(string fieldName)
        {
            string input;
            do
            {
                Console.Write($"{fieldName} ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input!");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
        private static string ReadNonEmptyStringWithoutNumbers(string fieldName)
        {
            string input;
            do
            {
                Console.Write($"{fieldName} ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (ContainsNumbers(input))
                {
                    Console.WriteLine("Invalid input!");
                }
            } while (string.IsNullOrWhiteSpace(input) || ContainsNumbers(input));

            return input;
        }
        private static bool ContainsNumbers(string input)
        {
            return input.Any(char.IsDigit);
        }
        private static string ConvertFirstLetterToUpperCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }
        private static void SaveReferencesToFile(List<string> wcitations)
        {
            try
            {
                string filePath = @"C:\Users\admin\OneDrive\Desktop\References\Webpage\References.txt";

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var wcitation in wcitations)
                    {
                        writer.WriteLine(wcitation);
                    }
                }
                Console.WriteLine("References saved.");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving references: {ex.Message}");
            }
        }
        private static string filePath = @"C:\Users\admin\OneDrive\Desktop\References\Webpage\Inputs.txt";
        private static void SaveReferencesInputsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var citation in citations)
                    {
                        writer.WriteLine($"{citation.Title},{citation.Authors},{citation.PublicationMonth},{citation.PublicationDay},{citation.PublicationYear},{citation.Publisher},{citation.WebUrl}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving references: {ex.Message}");
            }
        }
        static WebpageCitationManager()
        {
            LoadReferencesFromFile();
        }
        private static void LoadReferencesFromFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string[] fields = reader.ReadLine().Split(',');
                            if (fields.Length == 7)
                            {
                                WebMetadata metadata = new WebMetadata
                                {
                                    Title = fields[0],
                                    Authors = fields[1],
                                    PublicationMonth = int.Parse(fields[2]),
                                    PublicationDay = int.Parse(fields[3]),
                                    PublicationYear = int.Parse(fields[4]),
                                    Publisher = fields[5],
                                    WebUrl = fields[6]
                                };
                                citations.Add(metadata);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading references: {ex.Message}");
            }
        }
    }
}
