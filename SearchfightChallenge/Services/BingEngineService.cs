using SearchfightChallenge.Contracts;
using SearchfightChallenge.Entities;

namespace SearchfightChallenge.Services
{
    public class BingEngineService : SearchEngineService
    {
        public override string nameSearchEngine => "MSN Search";
        public override ISearchEngineService CreateEngineService()
        {
            return new BingEngine();
        }
    }
}