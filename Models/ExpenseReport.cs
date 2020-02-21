using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieSprint.Interfaces;

namespace MovieSprint.Models
{
    public class ExpenseReport
    {
        private decimal TotalBudget;
        private List<ExpenseReportLineItem> LineItems = new List<ExpenseReportLineItem>();

        public ExpenseReport(decimal budget)
        {
            TotalBudget = budget;
        }

        public void AddLineItem(string lineItemName, List<IExpenseItem> expenseItems)
        {
            decimal totalCost = expenseItems.Sum(i => i.Expense);

            LineItems.Add(new ExpenseReportLineItem
            {
                LineItem = lineItemName,
                    TotalCost = totalCost
            });
        }

        public string GetBreakdown()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"Total Budget: {TotalBudget.ToString("C")}");
            builder.AppendLine("-----------------------------");
            builder.AppendLine();
            builder.AppendLine("EXPENSES");
            builder.AppendLine();

            foreach (var item in LineItems)
            {
                builder.AppendLine($"{item.LineItem}: -{item.TotalCost.ToString("C")} ");
            }

            builder.AppendLine("-----------------------------");
            builder.AppendLine($"Remaining: {GetRemainingBudget().ToString("C")}");

            return builder.ToString();
        }

        private decimal GetRemainingBudget()
        {
            return TotalBudget - LineItems.Sum(li => li.TotalCost);
        }
    }

    public class ExpenseReportLineItem
    {
        public string LineItem { get; set; }
        public decimal TotalCost { get; set; }
    }
}