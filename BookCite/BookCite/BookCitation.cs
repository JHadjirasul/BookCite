using System;

namespace BOOKCITE
{
    public class BookCitation
    {
        public static void Run()
        {
            Console.Clear();
            while (true)
            {
                int choice;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("\tBook Reference Generator\n");

                    Console.WriteLine("1. APA   :   American Psychological Association");
                    Console.WriteLine("2. CMOS  :   Chicago Manual of Style");
                    Console.WriteLine("3. IEEE  :   Institute of Electrical and Electronics Engineers");
                    Console.WriteLine("4. MLA   :   Modern Languange Association");
                    Console.WriteLine("5. Main Menu");

                    Console.Write("\nSelect an option: ");
                    if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please input a number between 1 and 5.");
                        Console.ReadKey();
                    }
                }
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        {
                            CitationManager.BookAPA();
                            break;
                        }
                    case 2:
                        {
                            CitationManager.BookCMOS();
                            break;
                        }
                    case 3:
                        {
                            CitationManager.BookIEEE();
                            break;
                        }
                    case 4:
                        {
                            CitationManager.BookMLA();
                            break;
                        }
                    case 5:
                        {
                            MainMenu.Run();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                        }
                }
            }
        }
    }
}
