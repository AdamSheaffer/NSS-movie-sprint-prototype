﻿using System;
using System.Linq;
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
                Cast = MovieData.StartingCast,
                Crew = MovieData.StartingCrew,
                FilmingLocations = MovieData.StartingLocations,
                Shoots = MovieData.StartingScheduleItems
            };

            PrintWelcome(movie);

            while (true)
            {

                string[] mainMenuOptions = {
                    "Manage Cast",
                    "Manage Crew",
                    "Manage Locations",
                    "Schedule",
                    "Add Producer",
                    "Show Producers",
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
                    case 3:
                        Console.Clear();
                        ScheduleService.ShowScheduleMenu(movie);
                        break;
                    case 4:
                        Console.Clear();
                        ProducerService.AddProducer(movie);
                        break;
                    case 5:
                        Console.Clear();
                        ProducerService.ShowProducer(movie);
                        break;
                    case 6:
                        Console.Clear();
                        ReportService.ShowReport(movie);
                        break;
                    case 7:
                        return;
                    default:
                        break;
                }
            }
        }

        static void PrintWelcome(Movie movie)
        {
            Console.WriteLine(movie.Title);
            Console.WriteLine("-------------");
            Console.WriteLine("Starring:");

            movie.Cast.OrderByDescending(c => c.Expense)
                .Take(2)
                .ToList()
                .ForEach(c => Console.WriteLine("-- " + c.Name));

            Console.WriteLine();
            if (movie.ExecutiveProducers.Count > 0)
            {
                Console.WriteLine("Produced By:");
                movie.ExecutiveProducers.ForEach(p => Console.WriteLine("-- " + p.Name));

                Console.WriteLine();
            }

        }
    }
}