using System;
using System.Collections.Generic;
using MovieSprint.Interfaces;

namespace MovieSprint.Models
{
    public class ScheduleItem : IExpenseItem
    {
        public decimal Expense
        {
            get
            {
                TimeSpan shootingTime = EndDate - StartDate;
                return FilmingLocation.DailyCost * (shootingTime.Days + 1);
            }
        }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Location FilmingLocation { get; set; }
        public List<CastMember> Cast { get; set; }
    }
}