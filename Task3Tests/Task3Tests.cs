using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Task3
{
    class Task3Tests
    {
        TimeSpan defaultTimeout = TimeSpan.FromSeconds(15);

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("..\\..\\..\\..\\");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = defaultTimeout;
            driver.Url = "http://the-internet.herokuapp.com/dynamic_loading/2";
        }

        [Test]
        public void Task3_ExtractTextAfterLoading()
        {
            ClickStartButton();
            bool isElementDisplayed = GetLoadingElement().Displayed;
            IWebElement diplayText = GetFinishDisplayText();

            Assert.IsTrue(isElementDisplayed);
            Console.WriteLine(diplayText.Text);
        }

        public WebDriverWait getDefaultWait()
        {
            return new WebDriverWait(driver, defaultTimeout);
        }

        private IWebElement GetFinishDisplayText()
        {
            return driver.FindElement(By.Id("finish")).FindElement(By.TagName("h4"));
        }

        private IWebElement GetLoadingElement()
        {
            return driver.FindElement(By.Id("loading"));
        }

        private void ClickStartButton()
        {
            driver.FindElement(By.Id("start")).FindElement(By.TagName("button")).Click();
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}
