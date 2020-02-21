﻿using System;
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
                Title = "Hack & Slash"
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
                        CastService.ShowCastMenu();
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