using System;
using System.Collections.Generic;
using System.Linq;
using MovieSprint.Helpers;
using MovieSprint.Models;

namespace MovieSprint.Services
{
    public static class CrewService
    {
        public static void ShowCrewMenu(Movie movie)
        {
            string[] options = {
                "Show Crew",
                "Hire Crew Member",
                "Fire Crew Member"
            };

            int selectionIndex = MenuHelper.GetMenuSelection(options, true);

            bool goBack = selectionIndex == options.Length; // go back is last option

            if (goBack)
            {
                Console.Clear();
                return;
            }

            switch (selectionIndex)
            {
                case 0:
                    Console.Clear();
                    ShowCrew(movie);
                    break;
                case 1:
                    Console.Clear();
                    HireCrewMember(movie);
                    break;
                case 2:
                    Console.Clear();
                    FireCrewMember(movie);
                    break;
                default:
                    break;
            }
        }

        private static void ShowCrew(Movie movie)
        {
            IEnumerable<CrewMember> crew = movie.Crew
                .OrderByDescending(cm => cm.Expense);

            Pager<CrewMember> pager = new Pager<CrewMember>(crew);

            while (true)
            {
                pager.GetPage().ToList().ForEach(cm => Console.WriteLine($"{cm.Name} - {cm.Title}"));

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

        private static void HireCrewMember(Movie movie)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Cost: ");
            string costInput = Console.ReadLine();

            try
            {
                decimal cost = decimal.Parse(costInput);

                CrewMember newMember = new CrewMember
                {
                    Name = name,
                    Title = title,
                    Expense = cost
                };

                bool canAfford = movie.CanAfford(newMember);

                if (!canAfford)
                {
                    Console.Clear();
                    Console.WriteLine("Budget cannot afford this crew member");
                    return;
                }

                movie.Crew.Add(newMember);

            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Invalid dollar amount");
                HireCrewMember(movie);
            }
        }

        private static void FireCrewMember(Movie movie)
        {
            IEnumerable<string> options = movie.Crew.Select(cm => cm.Name);

            int selection = MenuHelper.GetMenuSelection(options, true);

            bool goBack = selection == options.Count();

            if (goBack)
            {
                Console.Clear();
                return;
            }

            movie.Crew.RemoveAt(selection);

            Console.Clear();
        }
    }
}