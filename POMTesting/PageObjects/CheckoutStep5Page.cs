using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Store.Helpers;

namespace Store.PageObjects
{
    public class CheckoutStep5Page 
    {
        private IWebDriver driver;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        public CheckoutStep5Page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            Wait.WaitForElementVisible(driver, step5Content);
        }

        [FindsBy(How = How.CssSelector, Using = "div#collapse-payment-method input")]
        private IWebElement step5Content { get; set; }

        #region Step 5: Payment Method 

        [FindsBy(How = How.Name, Using = "agree")]
        private IWebElement agreeTermsCheckbox { get; set; }
        [FindsBy(How = How.Id, Using = "button-payment-method")]
        private IWebElement continue5Button { get; set; }

        public void AgreeTerms()
        {
            agreeTermsCheckbox.Click();
            log.Info($"Agree Terms and Conditions");
        }

        public CheckoutStep6Page FinishStep5()
        {
            continue5Button.Click();
            log.Info($"Click on Continue button on Checkout Step 5");
            return new CheckoutStep6Page(driver);
        }

        #endregion Step 5: Payment Method 
    }
}