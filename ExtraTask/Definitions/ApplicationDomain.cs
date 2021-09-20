using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ExtraTask.Definitions
{
    public class ApplicationDomain
    {
        protected AppiumDriver<AndroidElement> driver;

        [BeforeScenario]
        public void Setup()
        {
            driver = DriverBuilder.BuildDriver();
        }

        [AfterScenario]
        public void CloseDriver()
        {
            this.driver.Quit();
        }

        public AndroidElement GetSourceListElement(string name)
        {
            return this.driver.FindElementByXPath($"//*[@text='{name}']");
        }
        public System.Collections.ObjectModel.ReadOnlyCollection<AndroidElement> GetNewsTitles()
        {
            return this.driver.FindElementsByXPath("//*[@resource-id='com.example.newsapp:id/nameTextView']");
        }
        public System.Collections.ObjectModel.ReadOnlyCollection<AndroidElement> GetNewsFavoriteCheckBoxes()
        {
            return this.driver.FindElementsByXPath("//*[@resource-id='com.example.newsapp:id/favoriteCheckBox']");
        }
        public void GoToFavoritesList()
        {
            this.driver.FindElementByXPath("//android.widget.FrameLayout[@content-desc='Favorites']/android.widget.ImageView").Click();
        }

    }
}
