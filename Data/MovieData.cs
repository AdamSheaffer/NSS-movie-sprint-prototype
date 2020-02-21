// Starter data for sprint

using System;
using System.Collections.Generic;
using MovieSprint.Models;

namespace MovieSprint.Data
{
    public static class MovieData
    {
        public static List<CastMember> StartingCast()
        {
            return new List<CastMember>
            {
                new CastMember
                {
                    Name = "Keanu Reeves",
                        Expense = 250_000
                },
                new CastMember
                {
                    Name = "Laurence Fishburne",
                        Expense = 100_000
                },
                new CastMember
                {
                    Name = "Carrie Ann Moss",
                        Expense = 150_000
                },
            };
        }

        public static List<CrewMember> StartingCrew()
        {
            return new List<CrewMember>
            {
                new CrewMember
                {
                    Name = "Adam Sheaffer",
                        Expense = 20_000
                },
                new CrewMember
                {
                    Name = "Rose Wizotsky",
                        Expense = 20_000
                },
                new CrewMember
                {
                    Name = "Brenda Long",
                        Expense = 20_000
                }
            };
        }
    }
}