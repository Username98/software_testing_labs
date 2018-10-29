using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverTest
{
    [TestClass]
    public class OstrovokTests
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            this.Driver = new ChromeDriver(@"C:\Univer\4k\software_testing_labs\WebDriverTest\WebDriverTest\bin\Debug");
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));
        }

        [TestCleanup]
        public void TeardownTest()
        {
            this.Driver.Quit();
        }

        [TestMethod]
        public void SearchTicketWithoutAgreement()
        {
            OstrovokSearchFrom ticketForm = new OstrovokSearchFrom(this.Driver);
            ticketForm.ValidateResults(ticketForm.SearchAndClickElement());
        }
    }
}