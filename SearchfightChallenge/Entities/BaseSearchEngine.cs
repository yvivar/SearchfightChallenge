using System;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace SearchfightChallenge.Entities
{
    public class BaseSearchEngine
    {
        private HttpClient httpClient { get; set; }

        public BaseSearchEngine() {
            this.httpClient = new HttpClient();
        }
        public JObject getJsonResponse(string urlEngine) {
            var responseJson = String.Empty;
            JObject jsonObject = new JObject();
            try {
                responseJson = httpClient.GetStringAsync(urlEngine).Result;
                jsonObject = JObject.Parse(responseJson);
            } catch (Exception ex) {
                responseJson = null;
                jsonObject = null;
                Console.WriteLine("Error: " + ex);
                throw;
            }
            return jsonObject;
        }

        public void addHeader(string key, string value) {
            httpClient.DefaultRequestHeaders.Add(key, value);
        }

        public string getKeySearchEngine(string searchEngineName) {
            return getNodeSearchEngine(searchEngineName, Constants.KEY);
        }

        public string getUrlSearchEngine(string searchEngineName) {
            return getNodeSearchEngine(searchEngineName, Constants.URL);
        }

        private string getNodeSearchEngine(string searchEngineName, string nodeName) {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(Constants.SEARCH_ENGINE_JSON);
            var config = builder.Build();
            return config.GetSection(Constants.SEARCH_ENGINE).GetSection(searchEngineName).GetSection(nodeName).Value;
        }
    }
}