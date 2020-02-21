using System;
using MovieSprint.Helpers;

namespace MovieSprint.Services
{
    public static class CastService
    {
        public static void ShowCastMenu()
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
                    Console.WriteLine("Selected show cast");
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
    }
}