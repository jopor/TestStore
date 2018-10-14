using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Store.PageObjects
{
    public class SuccessPage
    {
        private IWebDriver driver;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        public SuccessPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#common-success")));
        }

        [FindsBy(How = How.Id, Using = "content")]
        private IWebElement messageContent { get; set; }

        public string GetMessage()
        {
            return messageContent.Text.ToString();
        }
    }
}