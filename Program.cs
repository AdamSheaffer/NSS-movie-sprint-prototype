using System;
using MovieSprint.Data;
using MovieSprint.Helpers;
using MovieSprint.Models;
using MovieSprint.Services;

namespace MovieSprint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Movie movie = new Movie
            {
                Title = "Hack & Slash",
                Cast = MovieData.StartingCast(),
                Crew = MovieData.StartingCrew(),
                FilmingLocations = MovieData.StartingLocations()
            };

            while (true)
            {
                PrintWelcome(movie);

                string[] mainMenuOptions = {
                    "Manage Cast",
                    "Manage Crew",
                    "Manage Locations",
                    "Schedule",
                    "Add Producer",
                    "Expense Report",
                    "Exit"
                };

                int selectionIndex = MenuHelper.GetMenuSelection(mainMenuOptions);

                switch (selectionIndex)
                {
                    case 0:
                        Console.Clear();
                        CastService.ShowCastMenu(movie);
                        break;
                    case 1:
                        Console.Clear();
                        CrewService.ShowCrewMenu(movie);
                        break;
                    case 2:
                        Console.Clear();
                        LocationService.ShowLocationMenu(movie);
                        break;
                    case 4:
                        Console.Clear();
                        ProducerService.AddProducer(movie);
                        break;
                    case 5:
                        Console.Clear();
                        ReportService.ShowReport(movie);
                        break;
                    case 6:
                        return;
                    default:
                        break;
                }
            }
        }

        static void PrintWelcome(Movie movie)
        {
            Console.WriteLine(movie.Title);
            Console.WriteLine();
        }
    }
}