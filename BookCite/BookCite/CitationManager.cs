using System;
using System.Numerics;
using System.Collections.Generic;
using System.Globalization;

namespace BOOKCITE
{
    public class CitationManager
    {
        public enum CitationStyle
        {
            APA,
            CMOS,
            IEEE,
            MLA
        }
        static List<CitationStyles> citations = new List<CitationStyles>();
        public static void BookAPA()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tBook Reference (APA)\n");
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
                        BookCitation.Run();
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
        public static void BookCMOS()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tBook Referenece (CMOS)\n");
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
                        BookCitation.Run();
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
        public static void BookIEEE()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tBook Referenece (IEEE)\n");
                Console.WriteLine();
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
                        BookCitation.Run();
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
        public static void BookMLA()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("\tBook Referenece (MLA)\n");
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
                        BookCitation.Run();
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
            try
            {
                int numAuthors;
                while (true)
                {
                    Console.Clear();
                    Console.Write("\nNumber of authors: ");
                    if (int.TryParse(Console.ReadLine(), out numAuthors) && numAuthors > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please input a valid positive integer for the number of authors.");
                        Console.ReadKey();
                    }
                }

                Console.WriteLine();
                string[] firstNames = new string[numAuthors];
                string[] lastNames = new string[numAuthors];
                char[] middleInitials = new char[numAuthors];


                if (numAuthors >= 3)
                {
                    numAuthors = 1;
                }
                for (int i = 0; i < numAuthors; i++)
                {
                    Console.Write($"Author {i + 1}'s first name: ");
                    firstNames[i] = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(firstNames[i]) || ContainsNumbers(firstNames[i]))
                    {
                        if (ContainsNumbers(firstNames[i]))
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }

                        Console.Write($"Author {i + 1}'s first name: ");
                        firstNames[i] = Console.ReadLine();
                    }
                    firstNames[i] = ConvertFirstLetterToUpperCase(firstNames[i]);

                    Console.Write($"Author {i + 1}'s last name: ");
                    lastNames[i] = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(lastNames[i]) || ContainsNumbers(lastNames[i]))
                    {
                        if (ContainsNumbers(lastNames[i]))
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }

                        Console.Write($"Author {i + 1}'s last name: ");
                        lastNames[i] = Console.ReadLine();
                    }
                    lastNames[i] = ConvertFirstLetterToUpperCase(lastNames[i]);

                    while (true)
                    {
                        Console.Write($"Author {i + 1}'s middle initial: ");
                        string input = Console.ReadLine();

                        if (input.Length == 1 && (char.IsLetter(input[0]) || string.IsNullOrWhiteSpace(input)))
                        {
                            middleInitials[i] = string.IsNullOrWhiteSpace(input) ? '\0' : char.ToUpper(input[0]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please input a single character or leave it blank.");
                        }
                    }
                    Console.WriteLine();
                }

                Console.Write("Title: ");
                string title = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Invalid input!");
                    Console.Write("Title: ");
                    title = Console.ReadLine();
                }
                title = ConvertFirstLetterToUpperCase(title);

                Console.Write("Publisher: ");
                string publisher = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(publisher))
                {
                    Console.WriteLine("Invalid input!");
                    Console.Write("Publisher: ");
                    publisher = Console.ReadLine();
                }
                publisher = ConvertFirstLetterToUpperCase(publisher);

                Console.Write("City of Publication: ");
                string publisherAddress = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(publisherAddress))
                {
                    Console.WriteLine("Invalid input!");
                    Console.Write("City of Publication: ");
                    publisherAddress = Console.ReadLine();
                }
                publisherAddress = ConvertFirstLetterToUpperCase(publisherAddress);

                int yearPublished;
                while (true)
                {
                    Console.Write("Publication Year: ");
                    string inputYear = Console.ReadLine();

                    if (int.TryParse(inputYear, out yearPublished) && yearPublished >= 1450 && yearPublished <= 2023)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please input a valid year between 1450 and 2023.");
                    }
                }
                string text = null;
                int page = 0;

                APA apa = new APA(lastNames, firstNames, middleInitials, title, publisher, yearPublished, text, page);
                CMOS cmos = new CMOS(lastNames, firstNames, title, publisher, publisherAddress, yearPublished, text, page);
                IEEE ieee = new IEEE(lastNames, firstNames, title, publisher, publisherAddress, yearPublished, text, page);
                MLA mla = new MLA(lastNames, firstNames, title, publisher, yearPublished, text, page);

                switch (style)
                {
                    case CitationStyle.APA:
                        citations.Add(apa);
                        break;
                    case CitationStyle.CMOS:
                        citations.Add(cmos);
                        break;
                    case CitationStyle.IEEE:
                        citations.Add(ieee);
                        break;
                    case CitationStyle.MLA:
                        citations.Add(mla);
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Citation added successfully. Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
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
            List<string> bcitations = new List<string>();

            Console.WriteLine("┌──────────────┐┌──────────────┐┌──────────────┐┌──────────────┐");
            Console.WriteLine("│   [A] ADD    ││  [B] DELETE  ||   [C] BACK   ||   [S] SAVE   |");
            Console.WriteLine("└──────────────┘└──────────────┘└──────────────┘└──────────────┘");

            List<string> icitations = new List<string>();
            Console.WriteLine();
            Console.WriteLine($"\tBook References ({style}):");
            for (int i = 0; i < citations.Count; i++)
            {
                string bcitation;
                if (style == CitationStyle.IEEE)
                {
                    Console.WriteLine($"{i + 1}. [{i + 1}] {citations[i].CitationFormat()}");
                    bcitation = $"[{i + 1}] {citations[i].CitationFormat()}";

                }
                else
                {
                    Console.WriteLine($"{i + 1}. {citations[i].CitationFormat()}");
                    bcitation = $"{citations[i].CitationFormat()}";
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
        private static string ConvertFirstLetterToUpperCase(string input)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }
        private static bool ContainsNumbers(string input)
        {
            return input.Any(char.IsDigit);
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