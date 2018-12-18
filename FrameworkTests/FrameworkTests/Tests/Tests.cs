using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Linq;

namespace FrameworkTests.Test
{
    [TestFixture]
    public class Test
    {
        public IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            driver = Driver.Driver.GetInstance();
        }
        [Test]
        public void invaidEmail()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.GoToThisUrl();
            mainPage.inputEmail("asdfasdf");
            Assert.AreEqual(mainPage.GetIncorrectFormatError(), "Неверный формат");
        }

        [Test]
        public void IdenticalCityToTest()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.GoToThisUrl();
            mainPage.SetMainData("Minsk", "Minsk");
            mainPage.ClickSearchButton();
            mainPage.SwitchToActiveTab();
            Assert.AreEqual(mainPage.GetBadSearchParams(), "Упс, что-то пошло не так :-(");
        }

        [Test]
        public void UnsetAgreeCheckBox()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.GoToThisUrl();
            mainPage.SetMainData("Moscow", "Minsk");
            mainPage.ClickAgreeCheckBox();
            Assert.True(mainPage.IsDisabledSearchBox());
        }

        [Test]
        public void EmptyCity()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.GoToThisUrl();
            Assert.True(mainPage.EqualTabs());
        }

        [Test]
        public void ChangeLanguage()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.GoToThisUrl();
            mainPage.ChooseEnglish();
            Assert.AreEqual(mainPage.GetCurrentLanguage(), "Search");
        }

        [TearDown]
        public void TeardownTest()
        {
            Driver.Driver.CloseBrowser();
        }
    }
}
