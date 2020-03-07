using System;
using System.Linq;
using MovieSprint.Helpers;
using MovieSprint.Models;

namespace MovieSprint.Services
{
    public static class ProducerService
    {
        public static void ShowProducer(Movie movie)
        {
            Pager<Producer> pager = new Pager<Producer>(movie.ExecutiveProducers);

            while (true)
            {

                pager.GetPage().ToList().ForEach(p => Console.WriteLine($"{p.Name}: {p.Contribution.ToString("C")}"));

                Console.WriteLine(pager.Description);
                Console.WriteLine("Press <p> to go to previous page, <n> to go to next page, or <Enter> to return to main menu");

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.Clear();
                    break;
                }

                switch (input)
                {
                    case "p":
                        pager.CurrentPage = pager.IsFirstPage ? pager.CurrentPage : pager.CurrentPage - 1;
                        break;
                    case "n":
                        pager.CurrentPage = pager.IsLastPage ? pager.CurrentPage : pager.CurrentPage + 1;
                        break;
                    default:
                        break;
                }

                Console.Clear();
            }
        }

        public static void AddProducer(Movie movie)
        {
            Console.Write("Producer Name: ");
            string name = Console.ReadLine();

            Console.Write("Contribution: ");
            string contributionInput = Console.ReadLine();

            try
            {
                decimal contribution = decimal.Parse(contributionInput);
                Producer newProducer = new Producer
                {
                    Name = name,
                    Contribution = contribution
                };

                movie.AddExecutiveProducer(newProducer);

                Console.Clear();
                Console.WriteLine($"{newProducer.Name} successfully added to producers");
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Invalid dollar amount");
                AddProducer(movie);
            }
        }
    }
}