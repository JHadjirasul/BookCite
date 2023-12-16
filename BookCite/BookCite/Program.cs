using System;

namespace BOOKCITE
{
    class Program
    {
        static void Main()
        {
            Introduction.DisplayLoading();
            Introduction.DisplayMessage("WELCOME TO BOOKCITE!");
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
            MainMenu.Run();
        }
    }
}