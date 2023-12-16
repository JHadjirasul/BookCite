using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.IO;
using System.Globalization;


namespace BOOKCITE
{
    public class JournalCitationManager
    {
        public class JournalMetadata
        {
            public string Title { get; set; }
            public string Authors { get; set; }
            public int PublicationYear { get; set; }
            public string JournalUrl { get; set; }
        }
        public enum CitationStyle
        {
            APA,
            CMOS,
            IEEE,
            MLA
        }
        static List<JournalMetadata> citations = new List<JournalMetadata>();

        public static void JournalAPA()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tJournal Reference (APA)\n");
                Console.WriteLine("1. Add Citation");
                Console.WriteLine("2. Display Citation");
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
                        JournalCitation.Run();
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
        public static void JournalCMOS()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tJournal Referenece (CMOS)\n");
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
                        JournalCitation.Run();
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
        public static void JournalIEEE()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tJournal Referenece (IEEE)\n");
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
                        JournalCitation.Run();
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
        public static void JournalMLA()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tJournal Referenece (MLA)\n");
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
                        JournalCitation.Run();
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
                    Console.WriteLine("\nEnter the link to the journal:");
                    string journalUrl = Console.ReadLine();

                    JournalMetadata metadata = GetJournalMetadata(journalUrl);

                    if (metadata != null)
                    {
                        metadata.Title = ConvertFirstLetterToUpperCase(metadata.Title);
                        metadata.Authors = ConvertFirstLetterToUpperCase(metadata.Authors);

                        citations.Add(metadata);
                        Console.WriteLine("\nCitation added successfully. Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("\nUnable to fetch metadata from the provided link. Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;

                case "2":
                    Console.Clear();
                    JournalMetadata manualMetadata = new JournalMetadata();
                    manualMetadata.Title = ReadNonEmptyInput("\nTitle:");
                    manualMetadata.Title = ConvertFirstLetterToUpperCase(manualMetadata.Title);

                    manualMetadata.Authors = ReadNonEmptyStringWithoutNumbers("\nAuthor/s (comma-separated if 2 or more):");
                    manualMetadata.Authors = ConvertFirstLetterToUpperCase(manualMetadata.Authors);

                    while (true)
                    {
                        Console.Write("\nPublication year: ");
                        if (int.TryParse(Console.ReadLine(), out int manualPublicationYear)
                            && manualPublicationYear >= 1450
                            && manualPublicationYear <= 2023)
                        {
                            manualMetadata.PublicationYear = manualPublicationYear;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter a valid year between 1450 and 2023.");
                        }
                    }
                    while (true)
                    {
                        Console.Write("\nUrl: ");
                        string urlInput = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(urlInput))
                        {
                            manualMetadata.JournalUrl = urlInput;
                            break; // Break out of the loop if the URL is not blank
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

            List<string> jcitations = new List<string>();
            Console.WriteLine();
            Console.WriteLine($"\tJournal References ({style}):");
            for (int i = 0; i < citations.Count; i++)
            {
                string jcitation;
                if (style == CitationStyle.IEEE)
                {
                    Console.WriteLine($"{i + 1}. [{i + 1}] {GenerateCitation(citations[i], style)}");
                    jcitation = $"[{i + 1}] {GenerateCitation(citations[i], style)}";
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {GenerateCitation(citations[i], style)}");
                    jcitation = $"{GenerateCitation(citations[i], style)}";
                }
                jcitations.Add(jcitation);
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
                    case 'C':
                        Console.Clear();
                        return;
                    case 'S':
                        SaveReferencesToFile(jcitations);
                        SaveReferencesInputsToFile();
                        break;
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
        private static string GenerateCitation(JournalMetadata metadata, CitationStyle style)
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
        private static JournalMetadata GetJournalMetadata(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                string title = doc.DocumentNode.SelectSingleNode("//meta[@property='og:title']")?.Attributes["content"]?.Value;
                string authors = doc.DocumentNode.SelectSingleNode("//meta[@name='author']")?.Attributes["content"]?.Value;
                int publicationYear = ExtractYearFromUrl(url);

                // Check for null references before assigning values to properties
                if (title != null && authors != null)
                {
                    return new JournalMetadata
                    {
                        Title = title,
                        Authors = authors,
                        PublicationYear = publicationYear,
                        JournalUrl = url
                    };
                }
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
        private static int ExtractYearFromUrl(string url)
        {
            var match = Regex.Match(url, @"/(\d{4})/");

            if (match.Success)
            {
                return int.Parse(match.Groups[1].Value);
            }
            return 0;
        }
        private static string GenerateAPACitation(JournalMetadata metadata)
        {
            string[] authorNames = metadata.Authors.Split(',');

            if (authorNames.Length == 1)
            {
                return $"{FormatAPAName(authorNames[0].Trim())} ({metadata.PublicationYear}). {metadata.Title}. {metadata.JournalUrl}";
            }
            else if (authorNames.Length == 2)
            {
                return $"{FormatAPAName(authorNames[0].Trim())} & {FormatAPAName(authorNames[1].Trim())} ({metadata.PublicationYear}). {metadata.Title}. {metadata.JournalUrl}";
            }
            else
            {
                return $"{FormatAPAName(authorNames[0].Trim())}, et al. ({metadata.PublicationYear}). {metadata.Title}. {metadata.JournalUrl}";
            }
        }
        private static string GenerateCMOSCitation(JournalMetadata metadata)
        {
            string[] authorNames = metadata.Authors.Split(','); ;

            if (authorNames.Length == 1)
            {
                return $"{FormatCMOSName(authorNames[0].Trim())}. \"{metadata.Title}\". {metadata.PublicationYear}. {metadata.JournalUrl}";
            }
            else if (authorNames.Length == 2)
            {
                return $"{FormatCMOSName(authorNames[0].Trim())} and {FormatCMOSName(authorNames[1].Trim())}. \"{metadata.Title}\". {metadata.PublicationYear}. {metadata.JournalUrl}";
            }
            else
            {
                return $"{FormatCMOSName(authorNames[0].Trim())}, et al. \"{metadata.Title}\". {metadata.PublicationYear}. {metadata.JournalUrl}";
            }
        }
        private static string GenerateIEEECitation(JournalMetadata metadata)
        {
            string[] authorNames = metadata.Authors.Split(',');

            if (authorNames.Length == 1)
            {
                return $"{FormatIEEEName(authorNames[0].Trim())}. \"{metadata.Title}\". {metadata.PublicationYear}. {metadata.JournalUrl}.";
            }
            else if (authorNames.Length == 2)
            {
                return $"{FormatIEEEName(authorNames[0].Trim())} and {FormatIEEEName(authorNames[1].Trim())}. \"{metadata.Title}\". {metadata.PublicationYear}.  {metadata.JournalUrl}.";
            }
            else
            {
                return $"{FormatIEEEName(authorNames[0].Trim())}, et al. \"{metadata.Title}\". {metadata.PublicationYear}. {metadata.JournalUrl}.";
            }
        }
        private static string GenerateMLACitation(JournalMetadata metadata)
        {
            string[] authorNames = metadata.Authors.Split(',');

            if (authorNames.Length == 1)
            {
                return $"{FormatMLAName(authorNames[0].Trim())}. \"{metadata.Title},\" {metadata.PublicationYear}. {metadata.JournalUrl}.";
            }
            else if (authorNames.Length == 2)
            {
                return $"{FormatMLAName(authorNames[0].Trim())} and {FormatMLAName(authorNames[1].Trim())}. \"{metadata.Title},\" {metadata.PublicationYear}. {metadata.JournalUrl}.";
            }
            else
            {
                return $"{FormatMLAName(authorNames[0].Trim())}, et al. \"{metadata.Title},\" {metadata.PublicationYear}. {metadata.JournalUrl}.";
            }
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
        private static void SaveReferencesToFile(List<string> jcitations)
        {
            try
            {
                string filePath = @"C:\Users\admin\OneDrive\Desktop\References\Journal\References.txt";

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var jcitation in jcitations)
                    {
                        writer.WriteLine(jcitation);
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
        private static string filePath = @"C:\Users\admin\OneDrive\Desktop\References\Journal\Inputs.txt";
        private static void SaveReferencesInputsToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var citation in citations)
                    {
                        writer.WriteLine($"{citation.Title},{citation.Authors},{citation.PublicationYear},{citation.JournalUrl}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving references: {ex.Message}");
            }
        }
        static JournalCitationManager()
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
                            // Read each line from the file and create a JournalMetadata object
                            string[] fields = reader.ReadLine().Split(',');
                            if (fields.Length == 4)
                            {
                                JournalMetadata metadata = new JournalMetadata
                                {
                                    Title = fields[0],
                                    Authors = fields[1],
                                    PublicationYear = int.Parse(fields[2]),
                                    JournalUrl = fields[3]
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
