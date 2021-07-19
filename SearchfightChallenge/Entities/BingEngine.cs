using System;
using SearchfightChallenge.Contracts;

namespace SearchfightChallenge.Entities
{
    public class BingEngine: BaseSearchEngine, ISearchEngineService
    {
        public Int64 searchTotalMatches(string wordSearch) {
            var apiRest = "";
            Int64 totalMatches = 0;
            try {
                apiRest = getUrlSearchEngine(Constants.BING).Replace("{0}", wordSearch);
                addHeader(Constants.HEADER_BING, getKeySearchEngine(Constants.BING));
                var jsonResult = getJsonResponse(apiRest);
                totalMatches = Convert.ToInt64(jsonResult["webPages"]["totalEstimatedMatches"]);
            } catch(Exception ex) {
                totalMatches = 0;
                throw ex;
            }
            return totalMatches;
            
        }
    }
}