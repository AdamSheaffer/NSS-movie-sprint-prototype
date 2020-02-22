using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieSprint.Helpers
{
    public static class MenuHelper
    {
        public static int GetMenuSelection(IEnumerable<string> options, bool canGoBack = false, bool optional = false)
        {
            for (int i = 0; i < options.Count(); i++)
            {
                Console.WriteLine($"{i+1}. {options.ElementAt(i)}");
            }

            if (canGoBack)
            {
                Console.WriteLine($"{options.Count() + 1}. Go Back");
            }

            string userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput) && optional)
            {
                return -1;
            }

            try
            {
                int selection = int.Parse(userInput);
                int maxOption = canGoBack ? options.Count() + 1 : options.Count();

                if (selection < 1 || selection > maxOption)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Selection");
                    Console.WriteLine();
                    return GetMenuSelection(options, canGoBack, optional);
                }

                return selection - 1;
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Invalid Selection");
                Console.WriteLine();
                return GetMenuSelection(options, canGoBack, optional);
            }
        }
    }
}