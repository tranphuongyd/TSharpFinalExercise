using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSharpFinalExercise.Common;

namespace TSharpFinalExercise.PageObjects
{
    public class CategoryPage : BasePage
    {
        IWebDriver _driver;
        By byFirstItem = By.CssSelector(".product_list > li:first-child h5[itemprop='name'] > a");
        By byItem = By.CssSelector(".product_list > li h5[itemprop='name'] > a");
        By bySearchTextBox = By.Id("search_query_top");
        By bySearchButton = By.CssSelector("button[name='submit_search'][type='submit']");
        public CategoryPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public string GetNameOfFirstItem()
        {
            WaitForElementVisible(byFirstItem, Constants.TimeDelay10Seconds);
            return _driver.FindElement(byFirstItem).Text.Trim();
        }

        public IEnumerable<IWebElement> Search(string keyword)
        {
            SendKeysToElement(bySearchTextBox, keyword);
            ClickToElement(bySearchButton);
            return GetElements(byItem);
        }
    }
}
