using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using UniversalMusicTestTaskProject.Drivers;


namespace UniversalMusicTestTaskProject.StepDefinitions
{
    [Binding]
    public class UniversalMusicTestSteps
    {
        IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public UniversalMusicTestSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            // Navigate to Url
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            driver.Url = "https://www.universalproductionmusic.com/en-us";
        }

        [When(@"I click Discover")]
        public void WhenIClickDiscover()
        {
            // Click discover button
            IWebElement DiscoverButton = driver.FindElement(By.CssSelector(".c-main-nav__item.ng-scope.c-main-nav__item--has-children"));
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(10));
            DiscoverButton.Click();
        }

        [When(@"I click Albums")]
        public void WhenIClickAlbums()
        {
            // locate Albums button
            IWebElement AlbumsButton = driver.FindElement(By.CssSelector("[href='/en-us/discover/albums']"));

            //Implicit wait
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(5));

            //Explicit wait
            /*WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("[href='/en-us/discover/albums']")));*/

            // click action for albums button with javacript
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", AlbumsButton);
        }

        [Then(@"the ""([^""]*)"" page is displayed")]
        public void ThenThePageIsDisplayed(string albums)
        {
            // Validate with the section title, I used this title as a variable in the feature file line 
            Assert.True(driver.FindElement(By.CssSelector(".c-section__head--large>h2:nth-child(1)")).Text.Contains(albums));

            // close the browser
            driver.Close();
        }

        [Given(@"I am on the Albums page")]
        public void GivenIAmOnTheAlbumsPage()
        {
            IWebElement AlbumsButton = driver.FindElement(By.CssSelector("[href='/en-us/discover/albums']"));

            //Implicit wait
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(10));

            // click Albums button with javacript
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", AlbumsButton);
        }

        [When(@"I click a random Album")]
        public void WhenIClickARandomAlbum()
        {
            // Select a random album (second one)
            IWebElement SecondAlbum = driver.FindElement(By.CssSelector("li.u-1-2_sm:nth-child(2)"));
            driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(5));
            SecondAlbum.Click();
        }

        [Then(@"the selected album is displayed")]
        public void ThenTheSelectedAlbumIsDisplayed()
        {
            // Validate that if the title is exist after openning a random album 
            Assert.True(driver.FindElement(By.CssSelector(".c-detailpage__title")).Displayed);

            // close the browser
            driver.Close();
        }
    }
}

