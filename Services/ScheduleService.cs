using System;
using System.Collections.Generic;
using System.Linq;
using MovieSprint.Helpers;
using MovieSprint.Models;

namespace MovieSprint.Services
{
    public static class ScheduleService
    {
        public static void ShowScheduleMenu(Movie movie)
        {
            string[] options = {
                "Show Schedule",
                "Add Shoot"
            };

            int selection = MenuHelper.GetMenuSelection(options, true);

            bool goBack = selection == options.Length;

            if (goBack)
            {
                Console.Clear();
                return;
            }

            switch (selection)
            {
                case 0:
                    Console.Clear();
                    ShowSchedule(movie);
                    break;
                case 1:
                    Console.Clear();
                    AddShoot(movie);
                    break;
                default:
                    break;
            }
        }

        private static void ShowSchedule(Movie movie)
        {
            movie.Shoots
                .OrderBy(s => s.StartDate)
                .ToList()
                .ForEach(s =>
                {
                    Console.WriteLine(s.Name);
                    Console.WriteLine($"{s.StartDate.ToString("MMMM dd")} - {s.EndDate.ToString("MMMM dd")}");
                    Console.WriteLine(s.FilmingLocation.Name);
                    s.Cast.ForEach(cm => Console.WriteLine("-- " + cm.Name));
                    Console.WriteLine();
                });

            Console.WriteLine("Press <Enter> to return to the main menu");
            Console.ReadLine();
            Console.Clear();
        }

        private static void AddShoot(Movie movie)
        {
            Console.Write("Shoot name: ");
            string name = Console.ReadLine();
            Location location = GetLocation(movie);
            DateTime start = GetDate("Start Date (MM/DD/YYYY): ");
            DateTime end = GetDate("End Date (MM/DD/YYYY: ");

            if (start > end)
            {
                Console.Clear();
                Console.WriteLine("Start date must be before end date\n");
                AddShoot(movie);
                return;
            }

            ScheduleItem newShoot = new ScheduleItem
            {
                Name = name,
                FilmingLocation = location,
                StartDate = start,
                EndDate = end
            };

            bool canAfford = movie.CanAfford(newShoot);

            if (!canAfford)
            {
                Console.Clear();
                Console.WriteLine("Budget cannot afford this shoot\n");
                return;
            }

            Console.WriteLine("Add cast members");
            IEnumerable<CastMember> cast = GetCast(movie);

            newShoot.Cast = cast.ToList();

            movie.Shoots.Add(newShoot);

            Console.Clear();
            Console.WriteLine($"{newShoot.Name} added to the schedule\n");
        }

        private static Location GetLocation(Movie movie)
        {
            IEnumerable<string> options = movie.FilmingLocations.Select(l => l.Name);

            int selection = MenuHelper.GetMenuSelection(options);

            return movie.FilmingLocations.ElementAt(selection);
        }

        private static IEnumerable<CastMember> GetCast(Movie movie)
        {
            List<CastMember> cast = new List<CastMember>();

            while (true)
            {
                IEnumerable<string> options = movie.Cast.Select(l => l.Name);
                int selection = MenuHelper.GetMenuSelection(options, false, true);

                if (selection == -1)
                {
                    break;
                }

                CastMember member = movie.Cast.ElementAt(selection);

                if (cast.Contains(member))
                {
                    Console.Clear();
                    Console.WriteLine($"{member.Name} has already been added");
                }
                else
                {
                    cast.Add(member);
                    Console.Clear();
                    Console.WriteLine($"{member.Name} added to schedule");
                }

            }

            return cast;
        }

        private static DateTime GetDate(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            try
            {
                DateTime dt = DateTime.Parse(input);
                return dt;
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Invalid Date");
                return GetDate(prompt);
            }
        }
    }
}