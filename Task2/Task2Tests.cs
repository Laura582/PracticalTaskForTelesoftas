using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace Task2
{
    public class Task2Tests
    {
        TimeSpan defaultTimeout = TimeSpan.FromSeconds(15);

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("..\\..\\..\\..\\");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = defaultTimeout;
            driver.Url = "https://www.globalsqa.com/demo-site/frames-and-windows/#iFrame";
        }

        [Test]
        public void Task2_CountIframeAndTestSearch()
        {
            CloseInformationalDialog();

            SwitchToIframe("globalSqa");

            int actualCountOfCoverImages = GetPortfolioItems().Count();
            int expectedCountOfCoverImages = 9;
            Assert.AreEqual(expectedCountOfCoverImages, actualCountOfCoverImages);

            ReturnToMainPage();

            string searchInput = "1";
            SearchFor(searchInput);

            string actualSerchResult = GetPageHeading().Text;
            string expectedSearchResult = $"Search results for: {searchInput}";
            Assert.AreEqual(expectedSearchResult, actualSerchResult);

        }

        public WebDriverWait getDefaultWait()
        {
            return new WebDriverWait(driver, defaultTimeout);
        }

        private IWebElement GetPageHeading()
        {
            return getDefaultWait().Until(ExpectedConditions.ElementIsVisible(By.ClassName("page_heading")));
        }

        // Returns to main page from other context, as example iframe
        private void ReturnToMainPage()
        {
            driver.SwitchTo().DefaultContent();
        }

        private void SearchFor(string input)
        {
            var searchBox = driver.FindElement(By.Id("s"));
            searchBox.SendKeys(input);
            searchBox.SendKeys(Keys.Enter);
        }

        private ReadOnlyCollection<IWebElement> GetPortfolioItems()
        {
            return getDefaultWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='portfolio_items']/div")));
        }

        private void SwitchToIframe(String iframeName)
        {
            getDefaultWait().Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(iframeName));
        }

        private void CloseInformationalDialog()
        {
            getDefaultWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@rel-title='iFrame']/div/a"))).Click();
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}