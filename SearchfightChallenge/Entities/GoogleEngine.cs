using System;
using SearchfightChallenge.Contracts;

namespace SearchfightChallenge.Entities
{
    public class GoogleEngine : BaseSearchEngine, ISearchEngineService
    {
        public Int64 searchTotalMatches(string wordSearch) {
            var apiRest = "";
            Int64 totalMatches = 0;
            try {
                apiRest = getUrlSearchEngine(Constants.GOOGLE).Replace("{0}", getKeySearchEngine(Constants.GOOGLE)).Replace("{1}", wordSearch);
                addHeader(Constants.HEADER_ACCEPT, Constants.CONTENT_TYPE_JSON);
                var jsonResult = getJsonResponse(apiRest);
                totalMatches = Convert.ToInt64(jsonResult["queries"]["request"][0]["totalResults"]);
            } catch (Exception ex) {
                totalMatches = 0;
                throw ex;
            }
            return totalMatches;
        }
    }
}