using SearchfightChallenge.Services;

namespace SearchfightChallenge.Contracts
{
    public interface ISearchEngineServiceFactory
    {
        SearchEngineService[] getAvailableServices();

        string getOverWinner(SearchEngineService[] services);
    }
}