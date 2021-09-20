using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using TechTalk.SpecFlow;

namespace ExtraTask.Definitions
{
    [Binding]
    public class ExtraTaskTestsSteps: ApplicationDomain
    {
        public string expectedTitleText;

        [Given(@"User skips tutorial")]
        public void GivenUserSkipsTutorial()
        {
            for (int i = 0; i < DriverBuilder.tutorialPagesCount; i++)
            {
                driver.FindElementById("com.example.newsapp:id/actionButton").Click();
            }
        }
        
        [When(@"The user goes to news source '(.*)'")]
        public void WhenTheUserGoesToNewsSource(string sourceListName)
        {
            GetSourceListElement(sourceListName).Click();
        }
        
        [When(@"Saves first article as a favorite")]
        public void WhenSavesFirstArticleAsAFavorite()
        {
            expectedTitleText = GetNewsTitles()[0].Text;
            GetNewsFavoriteCheckBoxes()[0].Click();
        }
        
        [Then(@"Favorite tab has the same article")]
        public void ThenFavoriteTabHasTheSameArticle()
        {
            GoToFavoritesList();
            var actualTitleText = GetNewsTitles()[0].Text;

            Assert.AreEqual(expectedTitleText, actualTitleText);
        }
    }
}
