using MovieSprint.Interfaces;

namespace MovieSprint.Models
{
    public class CastMember : IExpenseItem
    {
        public string Name { get; set; }
        public decimal Expense { get; set; }
    }
}