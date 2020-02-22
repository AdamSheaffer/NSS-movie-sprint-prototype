using System;
using MovieSprint.Helpers;
using MovieSprint.Models;

namespace MovieSprint.Services
{
    public static class LocationService
    {
        public static void ShowLocationMenu(Movie movie)
        {
            string[] options = {
                "Show All Locations",
                "Add Location"
            };

            int selectionIndex = MenuHelper.GetMenuSelection(options, true);

            bool goBack = selectionIndex == options.Length;

            if (goBack)
            {
                Console.Clear();
                return;
            }

            switch (selectionIndex)
            {
                case 0:
                    Console.Clear();
                    ShowAllLocations(movie);
                    break;
                case 1:
                    Console.Clear();
                    AddLocation(movie);
                    break;
                default:
                    break;
            }
        }

        private static void ShowAllLocations(Movie movie)
        {
            movie.FilmingLocations.ForEach(fl => Console.WriteLine($"{fl.Name}: {fl.DailyCost.ToString("C")} / day"));

            Console.WriteLine("Press <Enter> to return to main menu");
            Console.ReadLine();
            Console.Clear();
        }

        private static void AddLocation(Movie movie)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Daily Cost: ");
            string costInput = Console.ReadLine();

            try
            {
                decimal cost = decimal.Parse(costInput);

                Location newLocation = new Location
                {
                    Name = name,
                    DailyCost = cost
                };

                movie.FilmingLocations.Add(newLocation);

                Console.Clear();
                Console.WriteLine($"{newLocation.Name} added to filming locations");
            }
            catch (FormatException)
            {

                throw;
            }
        }
    }
}