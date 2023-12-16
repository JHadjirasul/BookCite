using System;

namespace BOOKCITE
{
    public class Book
    {
        public static void Run()
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine("\tBook Citation Generator\n");
                    Console.WriteLine("1. Reference");
                    Console.WriteLine("2. In-text citation and Bibliography");
                    Console.WriteLine("3. Main Menu");

                    Console.Write("\nSelect an option: ");
                    string opt = Console.ReadLine();

                    switch (opt)
                    {
                        case "1":
                            {
                                BookCitation.Run();
                                break;
                            }
                        case "2":
                            {
                                ITB.Run();
                                break;
                            }
                        case "3":
                            {
                                MainMenu.Run();
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
