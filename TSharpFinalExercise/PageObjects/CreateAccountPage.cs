using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSharpFinalExercise.Common;

namespace TSharpFinalExercise.PageObjects
{
    public class CreateAccountPage : BasePage
    {
        IWebDriver _driver;
        By byFirstNameCTextBox = By.Id("customer_firstname");
        By byLastNameCTextBox = By.Id("customer_lastname");
        By byPasswordCTextBox = By.Id("passwd");
        By byAddress1TextBox = By.Id("address1");
        By byCityTextBox = By.Id("city");
        By byStateSelect = By.CssSelector("#id_state > option:nth-child(4)");
        By byPostcodeTextBox = By.Id("postcode");
        By byPhoneMobileTextBox = By.Id("phone_mobile");
        By byAddressAliasTextBox = By.Id("alias");
        By bySubmitButton = By.Id("submitAccount");
        public CreateAccountPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public ProfilePage RegisterUser(RegisterModel model)
        {
            WaitForElementVisible(bySubmitButton, Constants.TimeDelay15Seconds);
            ClickToElement(GenerateGenderLocator((int)model.Gender));
            SendKeysToElement(byFirstNameCTextBox, model.FirstName);
            SendKeysToElement(byLastNameCTextBox, model.LastName);
            SendKeysToElement(byPasswordCTextBox, model.Password);
            ClickToElement(GenerateDateLocator("days", model.DateOfBith.Day));
            ClickToElement(GenerateDateLocator("months", model.DateOfBith.Month));
            ClickToElement(GenerateDateLocator("years", model.DateOfBith.Year));
            SendKeysToElement(byAddress1TextBox, model.Address1);
            SendKeysToElement(byCityTextBox, model.City);
            ClickToElement(GenerateStateLocator(model.State));
            SendKeysToElement(byPostcodeTextBox, model.Postcode);
            SendKeysToElement(byPhoneMobileTextBox, model.Phone);
            SendKeysToElement(byAddressAliasTextBox, model.AddressAlias);
            ClickToElement(bySubmitButton);

            return new ProfilePage(_driver);
        }

        private By GenerateGenderLocator(int value)
        {
            return By.CssSelector(string.Format("input[name='id_gender'][value='{0}']", value));
        }

        private By GenerateDateLocator(string elementId, int value)
        {
            return By.CssSelector(string.Format("#{0} > option[value='{1}']", elementId, value));
        }

        private By GenerateStateLocator(string value)
        {
            return By.XPath(string.Format("//select[@id = 'id_state']/option[contains(text(), '{0}')]", value));
        }
    }
}
