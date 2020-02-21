using System;
using System.Collections.Generic;

namespace MovieSprint.Models
{
    public class Movie
    {
        public int Title { get; set; }
        public List<CastMember> Cast { get; set; }
        public List<CrewMember> Crew { get; set; }
        public int Budget { get; set; } = 1_000_000;

        public int CalculateExpenses()
        {
            throw new NotImplementedException();
        }
    }
}