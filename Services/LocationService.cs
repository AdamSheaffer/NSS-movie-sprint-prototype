using System;
using System.Linq;
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
            Pager<Location> pager = new Pager<Location>(movie.FilmingLocations);

            while (true)
            {

                pager.GetPage().ToList().ForEach(fl => Console.WriteLine($"{fl.Name}: {fl.DailyCost.ToString("C")} / day"));

                Console.WriteLine(pager.Description);
                Console.WriteLine("Press <p> to go to previous page, <n> to go to next page, or <Enter> to return to main menu");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.Clear();
                    break;
                }

                switch (input)
                {
                    case "p":
                        pager.CurrentPage = pager.IsFirstPage ? pager.CurrentPage : pager.CurrentPage - 1;
                        break;
                    case "n":
                        pager.CurrentPage = pager.IsLastPage ? pager.CurrentPage : pager.CurrentPage + 1;
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }

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