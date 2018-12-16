using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace WebDriverTest
{
    
     [TestClass]
    public class UnitTest1
    {
        IWebDriver chrome = new ChromeDriver(@"C:\Univer\4k\software_testing_labs\WebDriverTest\WebDriverTest\bin\Debug");

        [TestMethod]
        public void TestMethod1()
        {
            
            chrome.Navigate().GoToUrl("https://ostrovok.ru/?tabs=aero&sid=14b52feb-4ba7-4912-866d-ef2ba31b8b16");
           
            chrome.FindElement(By.XPath(@"//*[@id=':0']/div/div/div[1]/div/div[3]/div/div/div/div[1]/div/div[1]/div[1]/div/div/div[2]/input")).SendKeys("Москва, Россия");
            
            chrome.FindElement(By.XPath(@"//*[@id=':0']/div/div/div[1]/div/div[3]/div/div/div/div[1]/div/div[1]/div[3]/div/div/div[2]/input")).SendKeys("Москва, Россия");

            chrome.FindElement(By.XPath(@"//*[@id=':0']/div/div/div[1]/div/div[3]/div/div/div/div[2]/div[2]/div[1]/button")).Click();

           
            bool actual = false;
            Thread.Sleep(500);
            try
            {
               // WebDriverWait _wait = new WebDriverWait(chrome, new TimeSpan(0, 0, 20));
                //_wait.Timeout = 500;
                chrome.FindElement(By.XPath("/html/body/div[1]/div/div[3]/div[1]/div[1]/div[2]/div/div[10]/div[2]/div[5]/div[2]/div[9]/div[1]/div[3]/div[2]"));
                //    chrome.FindElement(By.ClassName("ticket-scroll-container"));
               // _wait.Until(d => d.FindElement(By.ClassName("ticket-scroll-container")));
            }
            catch (Exception)
            {
                actual = true;               
            }
     
             Assert.AreEqual(true,actual);
          
        }
       [TestCleanup]
        public void TearDown()
        {
            chrome.Quit();
        }
    }
}
