using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UniversalMusicTestTaskProject.Drivers
{
    public class SeleniumDriver
    {
        private IWebDriver driver;
        private readonly ScenarioContext scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext) => scenarioContext = scenarioContext;

        public IWebDriver Setup()
        {

            driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
