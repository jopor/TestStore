using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Store.Helpers;

namespace Store.PageObjects
{
    public class CheckoutStep6Page 
    {
        private IWebDriver driver;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        public CheckoutStep6Page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            Wait.WaitForElementVisible(driver, step6Content);
        }

        [FindsBy(How = How.CssSelector, Using = "div#collapse-checkout-confirm input")]
        private IWebElement step6Content { get; set; }

        #region Step 6: Confirm Order 

        [FindsBy(How = How.Id, Using = "button-confirm")]
        private IWebElement confirmOrderButton { get; set; }

        public SuccessPage ConfirmOrder()
        {
            confirmOrderButton.Click();
            log.Info($"Click on Confirm button on Checkout Step 6");
            return new SuccessPage(driver);
        }

        #endregion Step 6: Confirm Order 
    }
}