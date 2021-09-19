using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace ExtraTask
{
    public class ExtraTaskTest
    {
        private readonly string appiumServer = "http://192.168.0.234:4723/wd/hub";
        private readonly string deviceName = "emulator-5554";
        private readonly string appFullPathInAppiumServer = "your apk full path in appium server machine";
        private readonly int tutorialPagesCount = 4;
        TimeSpan defaultTimeout = TimeSpan.FromSeconds(15);

        private AppiumDriver<AndroidElement> driver;

        [SetUp]
        public void Setup()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability("platformName", "Android");
            driverOptions.AddAdditionalCapability("app", appFullPathInAppiumServer);
            driverOptions.AddAdditionalCapability("deviceName", deviceName);
            driverOptions.AddAdditionalCapability("appWaitActivity", "com.example.newsapp.tutorial.TutorialActivity");
            driverOptions.AddAdditionalCapability("appWaitPackage", "com.example.newsapp");
            driverOptions.AddAdditionalCapability("chromedriverExecutable", "..\\..\\..\\..\\");

            driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), driverOptions);
            driver.Manage().Timeouts().ImplicitWait = defaultTimeout;

            SkipTutorial();
        }

        [Test]
        public void ExtraTask_TestSavedFavorinteNewsShowsCorrectFavorites()
        {
            var sourceListName = "ABC News";

            GetSourceListElement(sourceListName).Click();

            var expectedTitleText = GetNewsTitles()[0].Text;

            GetNewsFavoriteCheckBoxes()[0].Click();

            GoToFavoritesList();

            var actualTitleText = GetNewsTitles()[0].Text;

            Assert.AreEqual(expectedTitleText, actualTitleText);

        }

        private void SkipTutorial()
        {
            for (int i = 0; i < tutorialPagesCount; i++)
            {
                driver.FindElementById("com.example.newsapp:id/actionButton").Click();
            }
        }

        private System.Collections.ObjectModel.ReadOnlyCollection<AndroidElement> GetNewsTitles()
        {
            return driver.FindElementsByXPath("//*[@resource-id='com.example.newsapp:id/nameTextView']");
        }

        private void GoToFavoritesList()
        {
            driver.FindElementByXPath("//android.widget.FrameLayout[@content-desc='Favorites']/android.widget.ImageView").Click();
        }

        private System.Collections.ObjectModel.ReadOnlyCollection<AndroidElement> GetNewsFavoriteCheckBoxes()
        {
            return driver.FindElementsByXPath("//*[@resource-id='com.example.newsapp:id/favoriteCheckBox']");
        }

        private AndroidElement GetSourceListElement(string name)
        {
            return driver.FindElementByXPath($"//*[@text='{name}']");
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }
    }
}