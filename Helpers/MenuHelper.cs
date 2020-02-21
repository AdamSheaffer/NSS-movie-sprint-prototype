using System;

namespace MovieSprint.Helpers
{
    public static class MenuHelper
    {
        public static int GetMenuSelection(string[] options, bool canGoBack = false)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i+1}. {options[i]}");
            }

            if (canGoBack)
            {
                Console.WriteLine($"{options.Length + 1}. Go Back");
            }

            string userInput = Console.ReadLine();

            try
            {
                int selection = int.Parse(userInput);
                int maxOption = canGoBack ? options.Length + 1 : options.Length;

                if (selection < 1 || selection > maxOption)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Selection");
                    Console.WriteLine();
                    return GetMenuSelection(options, canGoBack);
                }

                return selection - 1;
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Invalid Selection");
                Console.WriteLine();
                return GetMenuSelection(options, canGoBack);
            }
        }
    }
}