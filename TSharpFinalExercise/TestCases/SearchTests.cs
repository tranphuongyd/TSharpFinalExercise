using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSharpFinalExercise.Common;
using TSharpFinalExercise.PageObjects;

namespace TSharpFinalExercise.TestCases
{
    [TestFixture]
    class SearchTests
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = Helpers.CreateWebDriver(Settings.BrowserType.Chrome);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Constants.AutomationPracticeHomePageUrl);
        }
        [Test]
        public void TC01_SearchSuccessfully()
        {
            var homePage = new HomePage(_driver);
            homePage.HoverWomanItem();
            var categoryPage = homePage.OpenTshirtPage();
            var nameOfFirstItem = categoryPage.GetNameOfFirstItem();
            var result = categoryPage.Search(nameOfFirstItem);
            Assert.IsTrue(result.Count() > 0);
            Assert.IsTrue(result.FirstOrDefault(x => x.Text.Trim() == nameOfFirstItem) != null);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
