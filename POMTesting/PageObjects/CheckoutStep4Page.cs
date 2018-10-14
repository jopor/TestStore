using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Store.Helpers;

namespace Store.PageObjects
{
    public class CheckoutStep4Page
    {
        private IWebDriver driver;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        public CheckoutStep4Page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            Wait.WaitForElementVisible(driver, step4Content);
        }

        [FindsBy(How = How.CssSelector, Using = "div#collapse-shipping-method input")]
        private IWebElement step4Content { get; set; }

        #region Step 4: Delivery Method 

        [FindsBy(How = How.Id, Using = "button-shipping-method")]
        private IWebElement continue4Button { get; set; }

        public CheckoutStep5Page FinishStep4()
        {
            continue4Button.Click();
            log.Info($"Click on Continue button on Checkout Step 4");
            return new CheckoutStep5Page(driver);
        }

        #endregion Step 4: Delivery Method 
    }
}