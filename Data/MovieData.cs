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
                        Expense = 150_000
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
                new CastMember
                {
                    Name = "Hugo Weaving",
                        Expense = 60_000
                },
                new CastMember
                {
                    Name = "Fiona Johnson",
                        Expense = 10_000
                },
                new CastMember
                {
                    Name = "Joe Pantoliano",
                        Expense = 60_000
                },
                new CastMember
                {
                    Name = "Anthony Ray Parker",
                        Expense = 50_000
                },
                new CastMember
                {
                    Name = "Julian Arahanga",
                        Expense = 40_000
                },
                new CastMember
                {
                    Name = "Belinda McClory",
                        Expense = 40_000
                },
                new CastMember
                {
                    Name = "Robert Taylor",
                        Expense = 10_000
                },
                new CastMember
                {
                    Name = "Ada Nicodemou",
                        Expense = 5_000
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
                        Expense = 20_000,
                        Title = "Camera Operator"
                },
                new CrewMember
                {
                    Name = "Rose Wizotsky",
                        Expense = 20_000,
                        Title = "Lighting Operator"
                },
                new CrewMember
                {
                    Name = "Brenda Long",
                        Expense = 20_000,
                        Title = "Camera Operator"
                },
                new CrewMember
                {
                    Name = "Bobby Collins",
                        Expense = 20_000,
                        Title = "Camera Operator"
                },
                new CrewMember
                {
                    Name = "Madi Peper",
                        Expense = 20_000,
                        Title = "Lighting Operator"
                },
                new CrewMember
                {
                    Name = "Jisie David",
                        Expense = 20_000,
                        Title = "Camera Operator"
                },
            };
        }

        public static List<Location> StartingLocations()
        {
            return new List<Location>
            {
                new Location
                {
                    Name = "Nashville Software School",
                        DailyCost = 250
                },
                new Location
                {
                    Name = "Waffle House",
                        DailyCost = 700
                }
            };
        }
    }
}