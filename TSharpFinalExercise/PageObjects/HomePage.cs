using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSharpFinalExercise.Common;

namespace TSharpFinalExercise.PageObjects
{
    public class HomePage : BasePage
    {
        IWebDriver _driver;
        By bySignInLink = By.CssSelector(".login");
        By byWomenMenuItem = By.XPath("//a[@title = 'Women']");
        By byTShirtSubMenuItem = By.XPath("//a[@title = 'T-shirts']");
        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public SignInPage OpenSignInPage()
        {
            WaitForElementVisible(bySignInLink, Constants.TimeDelay10Seconds);
            ClickToElement(bySignInLink);
            return new SignInPage(_driver);
        }

        public HomePage HoverWomanItem()
        {
            WaitForElementVisible(byWomenMenuItem, Constants.TimeDelay10Seconds);
            Actions action = new Actions(_driver);
            action.MoveToElement(_driver.FindElement(byWomenMenuItem)).Perform();

            return this;
        }

        public CategoryPage OpenTshirtPage()
        {
            WaitForElementVisible(byTShirtSubMenuItem, Constants.TimeDelay10Seconds);
            ClickToElement(byTShirtSubMenuItem);

            return new CategoryPage(_driver);
        }
    }
}
