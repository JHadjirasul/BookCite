using System;
using System.Numerics;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using static BOOKCITE.JournalCitationManager;
using static System.Net.Mime.MediaTypeNames;

namespace BOOKCITE
{
    public class ITBManager
    {
        public class BookMetadata
        {
            public string Title { get; set; }
            public List<string> Authors { get; set; } = new List<string>();
            public string PublicationYear { get; set; }
            public string City { get; set; }
            public string Publisher { get; set; }
            public int Page { get; set; }
            public string Text { get; set; }
        }
        public enum CitationStyle
        {
            APA,
            CMOS,
            IEEE,
            MLA
        }
        static List<BookMetadata> citations = new List<BookMetadata>();
        public static void ITBAPA()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tIn-text Citation and Bibliography (APA)\n");
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
                        ITB.Run();
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
        public static void ITBCMOS()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tIn-text Citation and Bibliography (CMOS)\n");
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
                        ITB.Run();
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
        public static void ITBIEEE()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tIn-text Citation and Bibliography (IEEE)\n");
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
                        ITB.Run();
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
        public static void ITBMLA()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tIn-text Citation and Bibliography (MLA)\n");
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
                        ITB.Run();
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
            try
            {
                string folderPath = @"C:\Users\admin\OneDrive\Desktop\BOOKS";

                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Folder not found. Exiting the program.");
                    Console.Clear();
                    return;
                }

                string[] txtFiles = Directory.GetFiles(folderPath, "*.txt");

                if (txtFiles.Length == 0)
                {
                    Console.WriteLine("No TXT files found in the specified folder. Exiting the program.");
                    Console.Clear();
                    return;
                }

                Console.WriteLine("Available TXT files in the folder:\n");
                for (int i = 0; i < txtFiles.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Path.GetFileName(txtFiles[i])}");
                }

                Console.Write("\nSelect the TXT file by entering the corresponding number: ");
                if (int.TryParse(Console.ReadLine(), out int fileIndex) && fileIndex >= 1 && fileIndex <= txtFiles.Length)
                {
                    string filePath = txtFiles[fileIndex - 1];
                    string content = ReadFile(filePath);

                    Console.Clear();
                    Console.WriteLine("Contents of the selected TXT file:\n");
                    Console.WriteLine(content);
                    Console.WriteLine("─────────────────────────────────────────────────────────────────");
                    Console.WriteLine("\tEXTRACTED INFORMATION");
                    GetBookMetadata(content);
                    Console.WriteLine("─────────────────────────────────────────────────────────────────");
                    try
                    {
                        Console.WriteLine("\nInput text to cite:");
                        string text = Console.ReadLine();

                        Console.Write("\nPage number: ");
                        int page = int.Parse(Console.ReadLine());

                        BookMetadata metadata = GetBookMetadata(content);
                        metadata.Page = page;
                        metadata.Text = text;

                        citations.Add(metadata);
                        Console.WriteLine("\nCitation added successfully. Press any key to continue.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("File not found.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("File not found!");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ReadKey();
                Console.Clear();
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

            Console.WriteLine();
            Console.WriteLine($"\tIn-Text Citations {style}: ");
            for (int i = 0; i < citations.Count; i++)
            {
                if (style == CitationStyle.IEEE)
                {
                    Console.WriteLine($"{GenerateInTextCitation(citations[i], style)} [{i + 1}]");
                }
                else
                {
                    Console.WriteLine($"{GenerateInTextCitation(citations[i], style)}");
                }
            }

            List<string> bcitations = new List<string>();
            Console.WriteLine($"\nBibliography:");
            for (int i = 0; i < citations.Count; i++)
            {
                string bcitation;
                if (style == CitationStyle.IEEE)
                {
                    Console.WriteLine($"{i + 1}. [{i + 1}] {GenerateCitation(citations[i], style)}");
                    bcitation = $"[{i + 1}] {GenerateCitation(citations[i], style)}";
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {GenerateCitation(citations[i], style)}");
                    bcitation = $"{GenerateCitation(citations[i], style)}";
                }
                bcitations.Add(bcitation);
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
                        SaveReferencesToFile(bcitations);
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
        private static BookMetadata GetBookMetadata(string content)
        {
            try
            {
                string titlePattern = @"Title: (.+)";
                string authorPattern = @"Author: (.+)";
                string releaseDatePattern = @"Release date: (.+?)\s*\[";
                string originalPublicationPattern = @"Original publication: (.+)";

                Match titleMatch = Regex.Match(content, titlePattern);
                Match authorMatch = Regex.Match(content, authorPattern);
                Match releaseDateMatch = Regex.Match(content, releaseDatePattern);
                Match originalPublicationMatch = Regex.Match(content, originalPublicationPattern);

                BookMetadata metadata = new BookMetadata();

                if (titleMatch.Success && authorMatch.Success && releaseDateMatch.Success && originalPublicationMatch.Success)
                {
                    metadata.Title = titleMatch.Groups[1].Value.Trim();

                    string authorInfo = authorMatch.Groups[1].Value.Trim();
                    string[] authors = authorInfo.Split(';');

                    foreach (var author in authors)
                    {
                        string[] nameParts = author.Trim().Split(' ');

                        if (nameParts.Length == 3)
                        {
                            metadata.Authors.Add($"{nameParts[0]} {nameParts[1][0]}. {nameParts[2]}");
                        }
                        else if (nameParts.Length == 2)
                        {
                            metadata.Authors.Add($"{nameParts[0]} {nameParts[1]}");
                        }
                        else
                        {
                            metadata.Authors.Add(author);
                        }
                    }
                    string rawReleaseDate = releaseDateMatch.Groups[1].Value.Trim();
                    if (DateTime.TryParse(rawReleaseDate, out DateTime parsedDate))
                    {
                        metadata.PublicationYear = parsedDate.ToString("yyyy");
                    }
                    string originalPublication = originalPublicationMatch.Groups[1].Value.Trim();
                    string[] cityPublisherParts = originalPublication.Split(':');

                    if (cityPublisherParts.Length == 2)
                    {
                        metadata.City = cityPublisherParts[0].Trim();
                        string[] publisherParts = cityPublisherParts[1].Split(',');
                        metadata.Publisher = publisherParts[0].Trim();
                    }
                    Console.WriteLine($"\nTitle: {metadata.Title}");
                    Console.WriteLine("Authors:");
                    foreach (var author in metadata.Authors)
                    {
                        Console.WriteLine($"  {author}");
                    }
                    Console.WriteLine($"Publication Year: {metadata.PublicationYear}");

                    if (!string.IsNullOrEmpty(metadata.City))
                    {
                        Console.WriteLine($"City: {metadata.City}");
                    }

                    if (!string.IsNullOrEmpty(metadata.Publisher))
                    {
                        Console.WriteLine($"Publisher: {metadata.Publisher}");
                    }
                }
                return metadata;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing book metadata: {ex.Message}");
                return null;
            }
        }
        private static string GenerateCitation(BookMetadata metadata, CitationStyle style)
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
        private static string GenerateInTextCitation(BookMetadata metadata, CitationStyle style)
        {
            switch (style)
            {
                case CitationStyle.APA:
                    return InTextFormatAPA(metadata.Authors, metadata.PublicationYear, metadata.Page, metadata.Text);
                case CitationStyle.CMOS:
                    return InTextFormatCMOS(metadata.Authors, metadata.PublicationYear, metadata.Page, metadata.Text);
                case CitationStyle.IEEE:
                    return InTextFormatIEEE(metadata.Authors, metadata.PublicationYear, metadata.Page, metadata.Text);
                case CitationStyle.MLA:
                    return InTextFormatMLA(metadata.Authors, metadata.PublicationYear, metadata.Page, metadata.Text);
                default:
                    throw new ArgumentException("Invalid citation style");
            }
        }
        private static string GenerateAPACitation(BookMetadata metadata)
        {
            string formattedAuthors = string.Join("; ", metadata.Authors.Select(FormatAPAName));
            return $"{formattedAuthors}. ({metadata.PublicationYear}). {metadata.Title}. {metadata.Publisher}";
        }
        private static string GenerateCMOSCitation(BookMetadata metadata)
        {
            string formattedAuthors = string.Join("; ", metadata.Authors.Select(FormatCMOSName));
            return $"{formattedAuthors}. {metadata.Title}. {metadata.City}: {metadata.Publisher}. {metadata.PublicationYear}.";
        }
        private static string GenerateIEEECitation(BookMetadata metadata)
        {
            string formattedAuthors = string.Join(", ", metadata.Authors.Select(FormatIEEEName));
            return $"{formattedAuthors}. {metadata.Title}. {metadata.City}: {metadata.Publisher}. {metadata.PublicationYear}.";
        }
        private static string GenerateMLACitation(BookMetadata metadata)
        {
            string formattedAuthors = string.Join(", ", metadata.Authors.Select(FormatMLAName));
            return $"{formattedAuthors}. {metadata.Title}. {metadata.Publisher}, {metadata.PublicationYear}.";
        }
        private static string InTextFormatAPA(List<string> authors, string year, int page, string text)
        {
            string formattedAuthors = string.Join("; ", authors.Select(FormatInTextAPAName));
            return $"{text}. ({formattedAuthors}, {year}, p. {page})";
        }
        private static string InTextFormatCMOS(List<string> authors, string year, int page, string text)
        {
            string formattedAuthors = string.Join("; ", authors.Select(FormatInTextCMOSName));
            return $"{text}. ({formattedAuthors} {year}, {page})";
        }
        private static string InTextFormatIEEE(List<string> authors, string year, int page, string text)
        {
            return $"{text}.";
        }
        private static string InTextFormatMLA(List<string> authors, string year, int page, string text)
        {
            string formattedAuthors = string.Join(", ", authors.Select(FormatInTextMLAName));
            return $"{text}. ({formattedAuthors} {page})";
        }
        private static string FormatInTextAPAName(string authorName)
        {
            string[] nameParts = authorName.Split(' ');
            return nameParts[2];
        }
        private static string FormatInTextCMOSName(string authorName)
        {
            string[] nameParts = authorName.Split(' ');
            return nameParts[2];
        }
        private static string FormatInTextIEEEName(string authorName)
        {
            return string.Empty;
        }
        private static string FormatInTextMLAName(string authorName)
        {
            string[] nameParts = authorName.Split(' ');
            return nameParts[2];
        }
        private static string FormatAPAName(string authorName)
        {
            string[] nameParts = authorName.Split(' ');

            if (nameParts.Length == 3)
            {
                return $"{nameParts[2]}, {nameParts[0]} {nameParts[1][0]}.";
            }
            else if (nameParts.Length == 2)
            {
                return $"{nameParts[1]}, {nameParts[0]}";
            }
            else
            {
                return authorName;
            }
        }
        private static string FormatCMOSName(string authorName)
        {
            return FormatAPAName(authorName);
        }
        private static string FormatIEEEName(string authorName)
        {
            string[] nameParts = authorName.Split(' ');

            if (nameParts.Length == 3)
            {
                return $"{nameParts[0][0]}. {nameParts[1][0]}. {nameParts[2]}";
            }
            else if (nameParts.Length == 2)
            {
                return $"{nameParts[0]} {nameParts[1]}";
            }
            else
            {
                return authorName;
            }
        }
        private static string FormatMLAName(string authorName)
        {
            string[] nameParts = authorName.Split(' ');

            if (nameParts.Length == 3)
            {
                return $"{nameParts[2]}, {nameParts[0]} {nameParts[1][0]}.";
            }
            else if (nameParts.Length == 2)
            {
                return $"{nameParts[1]}, {nameParts[0]}";
            }
            else
            {
                return authorName;
            }
        }
        private static string ReadFile(string filePath)
        {
            string content = "";
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    content = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }

            return content;
        }
        private static void SaveReferencesToFile(List<string> bcitations)
        {
            try
            {
                string filePath = @"C:\Users\admin\OneDrive\Desktop\References\Book\References.txt";

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var bcitation in bcitations)
                    {
                        writer.WriteLine(bcitation);
                    }
                }
                Console.WriteLine("References saved.");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving references: {ex.Message}");
                Console.Clear();
            }
        }


    }
}