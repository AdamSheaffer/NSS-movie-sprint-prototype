using System;
using System.Collections.Generic;
using System.Linq;
using MovieSprint.Interfaces;

namespace MovieSprint.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public List<CastMember> Cast { get; set; }
        public List<CrewMember> Crew { get; set; }
        public int Budget { get; set; } = 1_000_000;

        public decimal CalculateExpenses()
        {
            List<IExpenseItem> expenseItems = new List<IExpenseItem>();
            expenseItems.AddRange(Cast);
            expenseItems.AddRange(Crew);

            return expenseItems.Sum(i => i.Expense);
        }

        public bool CanAfford(IExpenseItem item)
        {
            decimal totalExpenses = CalculateExpenses();
            return (Budget - totalExpenses) > item.Expense;
        }
    }
}