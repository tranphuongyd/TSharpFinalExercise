using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSharpFinalExercise.Common;

namespace TSharpFinalExercise.PageObjects
{
    public class ProfilePage : BasePage    
    {
        IWebDriver _driver;
        By byFullNameSpan = By.CssSelector(".account > span");
        public ProfilePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public string GetFullName()
        {
            WaitForElementVisible(byFullNameSpan, Constants.TimeDelay10Seconds);
            return _driver.FindElement(byFullNameSpan).Text;
        }
    }
}
