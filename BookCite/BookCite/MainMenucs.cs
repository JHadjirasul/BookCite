using System;
using System.Net;

namespace BOOKCITE
{
    public class MainMenu
    {
        public static void Run()
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine("\tCitation Generator\n");
                    Console.WriteLine("1. Book");
                    Console.WriteLine("2. Webpage");
                    Console.WriteLine("3. Journal/Article");
                    Console.WriteLine("4. Exit");

                    Console.Write("\nSelect an option: ");
                    int opt = Convert.ToInt32(Console.ReadLine());

                    switch (opt)
                    {
                        case 1:
                            {
                                Book.Run();
                                break;
                            }
                        case 2:
                            {
                                WebpageCitation.Run();
                                break;
                            }
                        case 3:
                            {
                                JournalCitation.Run();
                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                Environment.Exit(1);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid choice. Please select a valid option.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                }
                catch (OverflowException)
                {
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    Console.Clear();
                }
            }
        }
    }
}
