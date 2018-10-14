using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Store.Helpers;
using System.Configuration;

namespace Store.PageObjects
{
    public class InitClass
    {
        protected IWebDriver driver { get; private set; }
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        [SetUp]
        public void Initialize()
        {
            SelectBrowser(ConfigurationManager.AppSettings["browser"]);
            driver.Manage().Window.Maximize();
            Actions.GoToUrl(driver, "route=common/home");
            log.Info($">> {TestContext.CurrentContext.Test.Name} test is run");
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                // TODO: 141018 - Add screenshot for failed tests
                log.Error($"{TestContext.CurrentContext.Test.Name} test failed");
            }

            log.Info($"> {TestContext.CurrentContext.Test.Name} test successfully finished");

            driver.Dispose();
        }

        private void SelectBrowser(string browserType)
        {
            switch (browserType)
            {
                // TODO: 141018 - Fix broken tests using Firefox browser
                case "Firefox": 
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                default:
                    ChromeOptions option = new ChromeOptions();
                    driver = new ChromeDriver(option);
                    break;
            }
        }
    }
}