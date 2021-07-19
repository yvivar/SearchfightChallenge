using System;

namespace SearchfightChallenge.Contracts
{
    public interface ISearchEngineService
    {
        Int64 searchTotalMatches(string wordSearch);
    }
}