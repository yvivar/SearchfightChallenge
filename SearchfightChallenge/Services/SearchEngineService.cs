using System;
using SearchfightChallenge.Contracts;

namespace SearchfightChallenge.Services
{
    public abstract class SearchEngineService
    {
        private Int64 countWinner = 0;
        private string resultSearchWinner = "Without results. Please contact the administrator.";
        public abstract string nameSearchEngine { get; }
        public abstract ISearchEngineService CreateEngineService();

        public string getWinner()
        {
            return $"{nameSearchEngine} winner : {resultSearchWinner}";
        }

        public string getSearchWinner()
        {
            return resultSearchWinner;
        }

        public string getResultOfEngine(string searchWord)
        {
            Int64 resultCountEngine = 0;
            try {
                resultCountEngine = CreateEngineService().searchTotalMatches(searchWord);
                setWinnerResult(searchWord, resultCountEngine);
                return nameSearchEngine + ": " + resultCountEngine;
            } catch (Exception ex) {
                resultCountEngine = 0;
                throw ex;
            }
        }

        private void setWinnerResult(string searchWord, Int64 resultEngine)
        {
            if (resultEngine > countWinner)
            {
                resultSearchWinner = searchWord;
                countWinner = resultEngine;
            }
        }
    }
}