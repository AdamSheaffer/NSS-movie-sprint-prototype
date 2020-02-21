using System;
using System.Collections.Generic;
using System.Linq;
using MovieSprint.Interfaces;

namespace MovieSprint.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public List<CastMember> Cast { get; set; } = new List<CastMember>();
        public List<CrewMember> Crew { get; set; } = new List<CrewMember>();
        public List<Producer> ExecutiveProducers { get; set; } = new List<Producer>();
        public decimal Budget { get; set; } = 1_000_000;

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

        public void AddExecutiveProducer(Producer producer)
        {
            ExecutiveProducers.Add(producer);
            Budget += producer.Contribution;
        }
    }
}