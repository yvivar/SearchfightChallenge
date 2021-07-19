using SearchfightChallenge.Contracts;
using SearchfightChallenge.Entities;

namespace SearchfightChallenge.Services
{
    public class GoogleEngineService: SearchEngineService
    {
        public override string nameSearchEngine => "Google";
        public override ISearchEngineService CreateEngineService()
        {
            return new GoogleEngine();
        }
    }
}