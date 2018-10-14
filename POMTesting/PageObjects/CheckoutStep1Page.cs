using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Store.Helpers;

namespace Store.PageObjects
{
    public class CheckoutStep1Page
    {
        private IWebDriver driver;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        public CheckoutStep1Page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            Wait.WaitForElementVisible(driver, step1Content);
        }

        [FindsBy(How = How.CssSelector, Using = "div#collapse-checkout-option input")]
        private IWebElement step1Content { get; set; }

        #region Step 1: Checkout Options 

        [FindsBy(How = How.CssSelector, Using = "input[value=guest]")]
        protected IWebElement guestRadioButton { get; set; }
        [FindsBy(How = How.CssSelector, Using = "input[value=register]")]
        protected IWebElement registerRadioButton { get; set; }
        [FindsBy(How = How.Id, Using = "button-account")]
        protected IWebElement continueButton { get; set; }

        public void CheckRegister()
        {
            registerRadioButton.Click();
            log.Info($"Check Register Account radio-button on Checkout Step 1");
        }

        public void CheckGuest()
        {
            guestRadioButton.Click();
            log.Info($"Check Guest radio-button on Checkout Step 1");
        }

        public CheckoutStep2Page FinishStep1(bool isGuest = false)
        {
            continueButton.Click();
            log.Info($"Click on Continue button on Checkout Step 1");
            if (isGuest)
                return new CheckoutStep2GuestPage(driver);
            else
            {
                return new CheckoutStep2RegisterPage(driver);
            }
        }

        #endregion Checkout Options 
    }
}