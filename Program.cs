using System;
using MovieSprint.Models;

namespace MovieSprint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Movie movie = new Movie
            {
                Title = "What's Hackening?"
            };

            PrintWelcome(movie);

            string[] mainMenuOptions = {
                "Manage Cast",
                "Manage Crew",
                "Manage Locations",
                "Schedule",
                "Add Producer",
                "Expense Report"
            };

            int selection = MenuHelper.GetMenuSelection(mainMenuOptions);

            Console.WriteLine($"Selected {mainMenuOptions[selection]}");
        }

        static void PrintWelcome(Movie movie)
        {
            Console.WriteLine(movie.Title);
        }
    }
}