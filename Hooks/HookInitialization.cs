using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UniversalMusicTestTaskProject.Drivers;

namespace UniversalMusicTestTaskProject.Hooks
{
    [Binding]
    public sealed class HooksInitialization
    {
        private readonly ScenarioContext _scenarioContext;

        public HooksInitialization(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

        [BeforeScenario]
        public void BeforeScenario()
        {
            SeleniumDriver seleniumDriver = new SeleniumDriver(_scenarioContext);
            _scenarioContext.Set(seleniumDriver, "SeleniumDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            /*Console.WriteLine("Selenium webdriver quit");
            _scenarioContext.Get<IWebDriver>("WebDriver").Quit();*/
        }
    }
}