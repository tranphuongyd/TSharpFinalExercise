using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using static TSharpFinalExercise.Common.Settings;

namespace TSharpFinalExercise.Common
{
    public static class Helpers
    {
        public static IWebDriver CreateWebDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new ChromeDriver();
                    break;
                case BrowserType.FireFox:
                    return new FirefoxDriver();
                    break;
                case BrowserType.Edge:
                    return new EdgeDriver();
                    break;
                default:
                    return new ChromeDriver();
                    break;
            }
        }

        public static string GenerateRandomEmailAddress()
        {
            var currentTime = DateTime.Now.ToString("ddMMyyyyhhmmssffff");
            return string.Format("myemail{0}@mail.com", currentTime);
        }
    }
}
