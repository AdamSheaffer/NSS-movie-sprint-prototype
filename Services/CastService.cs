using System;
using System.Collections.Generic;
using System.Linq;
using MovieSprint.Helpers;
using MovieSprint.Models;

namespace MovieSprint.Services
{
    public static class CastService
    {
        public static void ShowCastMenu(Movie movie)
        {
            string[] castOptions = {
                "Show Cast",
                "Hire Cast Member",
                "Fire Cast Member",
                "Search by Name"
            };

            int selectionIndex = MenuHelper.GetMenuSelection(castOptions, true);

            switch (selectionIndex)
            {
                case 0:
                    Console.Clear();
                    ShowCast(movie);
                    break;
                case 1:
                    Console.Clear();
                    HireCastMember(movie);
                    break;
                case 2:
                    Console.Clear();
                    FireCastMember(movie);
                    break;
                case 3:
                    Console.Clear();
                    SearchForCastMember(movie);
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }

        private static void ShowCast(Movie movie)
        {
            movie.Cast
                .OrderByDescending(cm => cm.Expense)
                .ToList()
                .ForEach(cm => Console.WriteLine(cm.Name));

            Console.WriteLine("\nPress <Enter> to return to main menu");
            Console.ReadLine();
            Console.Clear();
        }

        private static void HireCastMember(Movie movie)
        {
            Console.Write("Actor Name: ");
            string name = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Actor Cost: ");
            string expenseInput = Console.ReadLine();

            try
            {
                decimal expense = decimal.Parse(expenseInput);

                CastMember newMember = new CastMember
                {
                    Name = name,
                    Expense = expense
                };

                if (!movie.CanAfford(newMember))
                {
                    Console.Clear();
                    Console.WriteLine($"Budget cannot afford {name}\n");
                    return;
                }

                movie.Cast.Add(newMember);

                Console.Clear();
                Console.WriteLine($"{newMember.Name} has been added to cast\n");
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Invalid dollar input");
                HireCastMember(movie);
            }
        }

        private static void FireCastMember(Movie movie)
        {
            IEnumerable<string> options = movie.Cast.Select(cm => cm.Name);

            int selectionIndex = MenuHelper.GetMenuSelection(options, true);

            bool goBack = selectionIndex == options.Count(); // Last option

            if (goBack)
            {
                Console.Clear();
                return;
            }

            movie.Cast.RemoveAt(selectionIndex);

            Console.Clear();
        }

        private static void SearchForCastMember(Movie movie)
        {
            Console.Write("Search Cast: ");
            string q = Console.ReadLine();

            movie.Cast
                .Where(cm => cm.Name.ToLower().Contains(q.ToLower()))
                .ToList()
                .ForEach(cm =>
                {
                    Console.WriteLine($"{cm.Name}: {cm.Expense.ToString("C")}");
                });

            Console.WriteLine("\nPress <Enter> to return to main menu");
            Console.ReadLine();
            Console.Clear();
        }
    }
}