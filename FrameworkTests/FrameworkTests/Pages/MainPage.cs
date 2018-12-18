using System;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Linq;


namespace FrameworkTests.Pages
{
    class MainPage
    {
        private readonly IWebDriver driver;

        private readonly WebDriverWait wait;
        private readonly string mainUrl = "https://ostrovok.ru/?tabs=aero&sid=495b0856-1ed2-443b-ae9a-bbc4d36e5f34";

        [FindsBy(How = How.XPath, Using = @"//*[@id=':0']/div/div/div[1]/div/div[3]/div/div/div/div[1]/div/div[1]/div[1]/div/div/div[2]/input")]
        private IWebElement cityFrom;

        [FindsBy(How = How.XPath, Using = @"//*[@id=':0']/div/div/div[1]/div/div[3]/div/div/div/div[1]/div/div[1]/div[3]/div/div/div[2]/input")]
        private IWebElement cityTo;

        [FindsBy(How = How.XPath, Using = @"/html/body/div[1]/div[2]/div/div/div[4]/div/div[2]/div[2]/div[2]/div/div[2]/div/div/form/div[1]/div[1]/label/div[2]")]
        private IWebElement loginError;

        [FindsBy(How = How.XPath, Using = @"/html/body/div[1]/div[2]/div/div/div[4]/div/div")]
        private IWebElement accountButton;

        [FindsBy(How = How.XPath, Using = @"/html/body/div[1]/div[2]/div/div/div[4]/div/div[2]/div[2]/div[2]/div/div[2]/div/div/form/div[1]/div[1]/label/input")]
        private IWebElement emailField;

        [FindsBy(How = How.XPath, Using = @"/html/body/div[1]/div[2]/div/div/div[4]/div/div[2]/div[2]/div[2]/div/div[2]/div/div/form/div[2]/button[1]")]
        private IWebElement loginButton;
                
        [FindsBy(How = How.XPath, Using = @"/html/body/div[1]/div[2]/div/div/div[2]/div[1]/div/div/div[2]/div[3]/select")]
        private IWebElement languageList;

        [FindsBy(How = How.XPath, Using = @"//*[@id=':0']/div/div/div[1]/div/div[3]/div/div/div/div[2]/div[2]/div[1]/button")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.XPath, Using = @"//*[@id=':0']/div/div/div[1]/div/div[3]/div/div/div/div[4]/div/label/div[1]")]
        private IWebElement agreeCheckBox;

        [FindsBy(How = How.XPath, Using = @"/html/body/div[1]/div/div[3]/div[1]/div[1]/div[2]/div/div[10]/div[2]/div[5]/div[2]/div[5]/div/div[1]")]
        private IWebElement badSearchParams;

        public MainPage(IWebDriver Browser)
        {
            this.driver = Browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Window.Size = new System.Drawing.Size(driver.Manage().Window.Size.Width, driver.Manage().Window.Size.Height);
            PageFactory.InitElements(Browser, this);
        }

        public void inputEmail(string email)
        {
            accountButton.Click();
            emailField.SendKeys(email);
            loginButton.Click();
        }
        public string GetIncorrectFormatError()
        {
            return loginError.Text;
        }

        public void ChooseEnglish()
        {
            languageList.SendKeys(Keys.Down + Keys.Enter);
        }

        public string GetCurrentLanguage()
        {
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.ElementToBeClickable(buttonSearch));
            return buttonSearch.Text;
        }

        public string GetBadSearchParams()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"/html/body/div[1]/div/div[3]/div[1]/div[1]/div[2]/div/div[10]/div[2]/div[5]/div[2]/div[5]/div/div[1]")));
            return badSearchParams.Text;
        }

        public void SwitchToActiveTab()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public void GoToThisUrl()
        {
            driver.Navigate().GoToUrl(this.mainUrl);
        }

        public void ClickAgreeCheckBox()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(agreeCheckBox));
            agreeCheckBox.Click();
        }

        public void ClickSearchButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(buttonSearch));
            buttonSearch.Click();
        }

        public bool IsDisabledSearchBox()
        {
            return buttonSearch.Enabled ? false : true;
        }

        public bool EqualTabs()
        {
            return driver.WindowHandles.Last() == driver.WindowHandles.First() ? true : false;
        }

        public void SetMainData(string CityFrom, string CityTo)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(cityFrom));
            cityFrom.SendKeys(CityFrom);
            Thread.Sleep(3000);
            cityFrom.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            cityTo.SendKeys(CityTo);
            Thread.Sleep(3000);
            cityTo.SendKeys(Keys.Enter);
        }
    }
}

