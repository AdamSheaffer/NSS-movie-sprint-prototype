using System.Collections.Generic;
using System.Linq;

namespace MovieSprint.Helpers
{
    public class Pager<T>
    {
        public int CurrentPage { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 5;
        public int ItemsOffset { get => ItemsPerPage * (CurrentPage - 1); }
        public bool IsFirstPage { get => CurrentPage == 1; }
        public bool IsLastPage { get => (CurrentPage * ItemsPerPage) >= Items.Count(); }
        public string Description
        {
            get
            {
                int firstIndex = ItemsOffset + 1;
                int lastIndex = IsLastPage ? Items.Count() : ItemsOffset + ItemsPerPage;
                return $"Showing items {firstIndex} - {lastIndex} of {Items.Count()}";
            }
        }
        public IEnumerable<T> Items { get; set; }
        public Pager(IEnumerable<T> items)
        {
            Items = items;
        }

        public IEnumerable<T> GetPage()
        {
            return Items.Skip(ItemsOffset).Take(ItemsPerPage);
        }
    }
}