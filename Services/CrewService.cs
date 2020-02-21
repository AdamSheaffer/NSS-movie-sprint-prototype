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
                pager.GetPage().ToList().ForEach(cm => Console.WriteLine(cm.Name));

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
    }
}