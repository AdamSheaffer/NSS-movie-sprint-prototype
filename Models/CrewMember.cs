using MovieSprint.Interfaces;

namespace MovieSprint.Models
{
    public class CrewMember : IExpenseItem
    {
        public string Name { get; set; }
        public decimal Expense { get; set; }
        public string Title { get; set; }
    }
}