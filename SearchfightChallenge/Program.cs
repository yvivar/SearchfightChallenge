using System;
using SearchfightChallenge.Configuration;
using SearchfightChallenge.Contracts;
using SearchfightChallenge.Entities;

namespace SearchfightChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Boolean isValidWord = args != null ? (args.Length >= 1 ? true : false) : false;
            if (isValidWord)
            {
                ISearchEngineServiceFactory factory = new SearchEngineServiceConfiguration();
                var services = factory.getAvailableServices();
                foreach (var arg in args)
                {
                    Console.Write($"{arg}: ");
                    foreach (var service in services)
                        Console.Write($"{service.getResultOfEngine(arg)} ");
                    Console.Write("\n");
                }
                foreach (var service in services)
                {
                    Console.WriteLine(service.getWinner());
                }
                Console.WriteLine(factory.getOverWinner(services));
            }
            else
            {
                Console.WriteLine(Constants.MESSAGE_PLEASE_ENTER_A_WORD);
            }
            Console.ReadKey();
        }
    }
}
