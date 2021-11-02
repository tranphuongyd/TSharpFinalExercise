using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSharpFinalExercise.Common;

namespace TSharpFinalExercise.PageObjects
{
    public class SignInPage : BasePage
    {
        IWebDriver _driver;
        By byEmailAddressTextBox = By.Id("email_create");
        By bySubmitButton = By.Id("SubmitCreate");
        public SignInPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public CreateAccountPage SubmitCreateAccount(string emailAddress)
        {
            WaitForElementVisible(byEmailAddressTextBox, Constants.TimeDelay10Seconds);
            SendKeysToElement(byEmailAddressTextBox, emailAddress);

            ClickToElement(bySubmitButton);
            return new CreateAccountPage(_driver);
        }

    }
}
