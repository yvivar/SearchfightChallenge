using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchfightChallenge.Configuration;
using SearchfightChallenge.Contracts;
using SearchfightChallenge.Entities;
using SearchfightChallenge.Services;

namespace SearchfightChallengeTest.Tests
{
    [TestClass]
    public class SearchEngineServiceConfigurationTest
    {
        private ISearchEngineServiceFactory factory = new SearchEngineServiceConfiguration();

        [TestMethod]
        public void getAvailableServicesIsValid() {
            var services = factory.getAvailableServices();
            SearchEngineService[] serviceExpected = new SearchEngineService[] {
                new GoogleEngineService(),
                new BingEngineService()
            };
            Assert.IsTrue(services.Length == 2);
        }

        [TestMethod]
        public void getAvailableServicesQuantityOfEnginesIsDifferent() {
            var services = factory.getAvailableServices();
            SearchEngineService[] serviceExpected = new SearchEngineService[] {
                new BingEngineService()
            };
            Assert.AreNotEqual(services, serviceExpected);
        }

        [TestMethod]
        public void getOverWinnerIsFailed() {
            var services = factory.getOverWinner(new SearchEngineService[] {
                new BingEngineService()
            });

            var servicesExpected = factory.getOverWinner(new SearchEngineService[] { });
            
            Assert.AreNotEqual(services, Constants.MESSAGE_ADMINISTRATOR);

            Assert.AreEqual(servicesExpected, Constants.MESSAGE_ADMINISTRATOR);
        }


        
    }
}