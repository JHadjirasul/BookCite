using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BOOKCITE
{
    public class Introduction
    {
        public static void DisplayLoading()
        {
            Console.Clear();

            string loadingMessage = " ";
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;
            int loadingMessageLeft = (windowWidth - loadingMessage.Length) / 2;
            int loadingMessageTop = windowHeight / 2;

            Console.SetCursorPosition(loadingMessageLeft, loadingMessageTop);
            Console.Write(loadingMessage);

            for (int i = 1; i <= 100; i++)
            {
                Console.SetCursorPosition(loadingMessageLeft + loadingMessage.Length, Console.CursorTop);
                Console.Write($"{i}%");
                Thread.Sleep(10); // Adjust the sleep time if needed
                Console.SetCursorPosition(loadingMessageLeft + loadingMessage.Length, Console.CursorTop);
            }

            Console.Clear();
        }
        public static void DisplayMessage(string welcomeMessage)
        {
            Console.Clear();
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            int welcomeLeft = (windowWidth - welcomeMessage.Length) / 2;
            int welcomeTop = windowHeight / 2 - 2;

            Console.SetCursorPosition(welcomeLeft, welcomeTop);

            foreach (char c in welcomeMessage)
            {
                Console.Write(c);
                Thread.Sleep(50); // Adjust the sleep time for the speed of the animation
            }
        }
    }
}
