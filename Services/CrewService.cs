using System;
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
                    break;
                default:
                    break;
            }
        }
    }
}