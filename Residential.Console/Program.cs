using System;
using System.Threading.Tasks;
using ResidentialService;

namespace Residential.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service =
                new ResidenceService(new ResidenceCsvRepository(
                    "http://net-poland-interview-stretto.us-east-2.elasticbeanstalk.com/api/flats/csv"));
            var data = await service.GetAll();
            var iterator = 0;
            foreach (var residence in data)
            {
                System.Console.WriteLine($"Item {iterator}: {residence.Street}, {residence.City}. Price: {residence.Price}");
                iterator++;
            }

        }
    }
}