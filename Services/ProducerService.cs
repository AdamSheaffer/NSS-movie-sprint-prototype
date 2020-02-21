using System;
using MovieSprint.Models;

namespace MovieSprint.Services
{
    public static class ProducerService
    {
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