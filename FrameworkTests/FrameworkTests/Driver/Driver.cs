using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace FrameworkTests.Driver
{
    class Driver
    {
        private static IWebDriver driver;

        private Driver() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new FirefoxDriver();
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}

