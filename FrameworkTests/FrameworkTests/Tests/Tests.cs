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
        public void SetReturnsDateEmpty()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.GoToThisUrl();
            mainPage.SetMainData("Minsk", "Moscow");
            mainPage.ClickSearchButton();
            mainPage.SwitchToActiveTab();
            mainPage.ClearReturnsDate();
            Assert.AreEqual(mainPage.GetReturnsDate(), "");
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
        public void ChangeLanguageToEnglish()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.GoToThisUrl();
            mainPage.ChooseEnglish();
            Assert.AreEqual(mainPage.GetCurrentLanguage(), "Search");
        }

        [Test]
        public void ChangeLanguageToEspanol()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.GoToThisUrl();
            mainPage.ChooseDeutsch();
            Assert.AreEqual(mainPage.GetCurrentLanguage(), "Buscar");
        }

        [Test]
        public void ChangeLanguageToDeutsch()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.GoToThisUrl();
            mainPage.ChooseEspanol();
            Assert.AreEqual(mainPage.GetCurrentLanguage(), "Suchen");
        }

        [Test]
        public void ChangeLanguageToItaliano()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.GoToThisUrl();
            mainPage.ChooseItaliano();
            Assert.AreEqual(mainPage.GetCurrentLanguage(), "Cercs");
        }

        [TearDown]
        public void TeardownTest()
        {
            Driver.Driver.CloseBrowser();
        }
    }
}
