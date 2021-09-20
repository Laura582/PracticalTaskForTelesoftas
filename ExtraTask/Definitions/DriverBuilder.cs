using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ExtraTask.Definitions
{
    public class DriverBuilder
    {
        public static readonly int tutorialPagesCount = 4;

        private static readonly string appiumServer = "http://192.168.0.234:4723/wd/hub";
        private static readonly string deviceName = "emulator-5554";
        private static readonly string appFullPathInAppiumServer = "C:\\Users\\Laura\\Downloads\\PracticalTaskForTelesoftas-master\\PracticalTaskForTelesoftas-master\\ExtraTask\\debug.apk";
        private static TimeSpan defaultTimeout = TimeSpan.FromSeconds(15);

        public static AppiumDriver<AndroidElement> BuildDriver()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability("platformName", "Android");
            driverOptions.AddAdditionalCapability("app", appFullPathInAppiumServer);
            driverOptions.AddAdditionalCapability("deviceName", deviceName);
            driverOptions.AddAdditionalCapability("appWaitActivity", "com.example.newsapp.tutorial.TutorialActivity");
            driverOptions.AddAdditionalCapability("appWaitPackage", "com.example.newsapp");
            driverOptions.AddAdditionalCapability("chromedriverExecutable", "..\\..\\..\\..\\");

            var driver = new AndroidDriver<AndroidElement>(new Uri(appiumServer), driverOptions);
            driver.Manage().Timeouts().ImplicitWait = defaultTimeout;
            return driver;
        }
    }
}
