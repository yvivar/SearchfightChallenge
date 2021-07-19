using System.Collections.Generic;
using System.Linq;
using SearchfightChallenge.Contracts;
using SearchfightChallenge.Services;
using SearchfightChallenge.Entities;

namespace SearchfightChallenge.Configuration
{
    public class SearchEngineServiceConfiguration: ISearchEngineServiceFactory
    {
        public SearchEngineService[] getAvailableServices()
        {
            return new SearchEngineService[] {
                new GoogleEngineService(),
                new BingEngineService()
            };
        }

        public string getOverWinner(SearchEngineService[] services)
        {
            string resultOverWinner = string.Empty;
            var winners = new List<string>();
            if (services != null && services.Length > 0) {
                foreach (var service in services) {
                    winners.Add(service.getSearchWinner());
                }
                resultOverWinner = $"Total winner: { winners.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key }";
            } else {
                resultOverWinner = Constants.MESSAGE_ADMINISTRATOR;
            }
            return resultOverWinner;
        }
    }
}