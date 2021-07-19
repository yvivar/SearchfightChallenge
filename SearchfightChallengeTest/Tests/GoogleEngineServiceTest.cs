using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchfightChallenge.Entities;
using SearchfightChallenge.Services;

namespace SearchfightChallengeTest.Tests
{
    [TestClass]
    public class GoogleEngineServiceTest
    {
        private GoogleEngineService googleEngineService = new GoogleEngineService();

        [TestMethod]
        public void getSearchWinnerWithoutResults(){
            var nameEngineService = googleEngineService.getSearchWinner();

            var nameEngineServiceExpected = Constants.MESSAGE_WITHOUT_RESULTS;

            Assert.AreEqual(nameEngineService, nameEngineServiceExpected);
        }

        [TestMethod]
        public void getNameSearchEngineIsDifferent() {
            var nameEngineService = googleEngineService.nameSearchEngine;

            var nameEngineServiceExpected = "Bing";

            Assert.AreNotEqual(nameEngineService, nameEngineServiceExpected);
        }

        [TestMethod]
        public void getNameSearchEngineIsEqual() {
            var nameEngineService = googleEngineService.nameSearchEngine;

            var nameEngineServiceExpected = "Google";

            Assert.AreEqual(nameEngineService, nameEngineServiceExpected);
        }
    }
}