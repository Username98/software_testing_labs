using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverTest
{
    [TestClass]
    public class OstrovokSearchFrom
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://ostrovok.ru/?tabs=aero&sid=14b52feb-4ba7-4912-866d-ef2ba31b8b16";
        // IWebDriver chrome = new ChromeDriver(@"C:\Univer\4k\software_testing_labs\WebDriverTest\WebDriverTest\bin\Debug");
        public OstrovokSearchFrom(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }
        [TestMethod]
        public bool SearchAndClickElement()
        {
            bool actual = false;
            try
            {
                driver.Navigate().GoToUrl(url);

                driver.FindElement(By.XPath(@"//*[@id=':0']/div/div/div[1]/div/div[3]/div/div/div/div[1]/div/div[1]/div[1]/div/div/div[2]/input")).SendKeys("Москва, Россия");

                driver.FindElement(By.XPath(@"//*[@id=':0']/div/div/div[1]/div/div[3]/div/div/div/div[1]/div/div[1]/div[3]/div/div/div[2]/input")).SendKeys("Санкт-Петербург, Россия");

                driver.FindElement(By.XPath(@"//*[@id=':0']/div/div/div[1]/div/div[3]/div/div/div/div[4]/div/label/div[1]")).Click();

                driver.FindElement(By.XPath(@"//*[@id=':0']/div/div/div[1]/div/div[3]/div/div/div/div[2]/div[2]/div[1]/button")).Click();

            }
            catch (Exception)
            {
               actual = true;
            }
            return actual;
                   }
        public void ValidateResults(bool actual)
        {
           Assert.IsTrue(actual);
        }
    }
}
