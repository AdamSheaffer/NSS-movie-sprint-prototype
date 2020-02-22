using System;
using System.Collections.Generic;
using System.Linq;
using MovieSprint.Interfaces;
using MovieSprint.Models;

namespace MovieSprint.Services
{
    public static class ReportService
    {
        public static void ShowReport(Movie movie)
        {
            ExpenseReport report = new ExpenseReport(movie.Budget);

            // possibly less confusing than using LINQ Cast method
            List<IExpenseItem> cast = new List<IExpenseItem>();
            cast.AddRange(movie.Cast);
            report.AddLineItem("Cast", cast);

            var groups = movie.Crew.GroupBy(cm => cm.Title);

            foreach (var group in groups)
            {
                List<IExpenseItem> crewGroup = new List<IExpenseItem>();
                crewGroup.AddRange(group);
                report.AddLineItem(group.Key, crewGroup);
            }

            List<IExpenseItem> shoots = new List<IExpenseItem>();
            shoots.AddRange(movie.Shoots);
            report.AddLineItem("Filming Locations", shoots);

            Console.WriteLine(report.GetBreakdown());

            Console.WriteLine("\nPress <Enter> to return to main menu");
            Console.ReadLine();
            Console.Clear();
        }
    }
}