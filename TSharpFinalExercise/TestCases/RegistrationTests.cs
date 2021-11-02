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
    class RegistrationTests
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
        public void TC01_RegisterSuccessfully()
        {
            var home = new HomePage(_driver);         
            var signInPage = home.OpenSignInPage();

            // put unique email address and submit
            var createAccountPage = signInPage.SubmitCreateAccount(Helpers.GenerateRandomEmailAddress());

            var registerUser = new RegisterModel
            {
                FirstName = "First",
                LastName = "Last",
                Password = "121212",
                Gender = Gender.Mr,
                DateOfBith = DateTime.Parse("02/02/1990"),
                Address1 = "123, 345",
                City = "Hanoi",
                State = "Hawaii",
                Postcode = "12345",
                Phone = "0123456789",
                AddressAlias = "Address alias"
            };
            // put details information and submit
            var profile = createAccountPage.RegisterUser(registerUser);

            // validate user has created
            string expectedFullName = string.Format("{0} {1}", registerUser.FirstName, registerUser.LastName);
            Assert.AreEqual(expectedFullName, profile.GetFullName());
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
