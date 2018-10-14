using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Store.Helpers;

namespace Store.PageObjects
{
    public class CheckoutStep3Page 
    {
        private IWebDriver driver;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        public CheckoutStep3Page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            WaitForLoadedStep();
        }

        [FindsBy(How = How.CssSelector, Using = "div#collapse-shipping-address input")]
        private IWebElement step3Content { get; set; }

        #region Step 3: Delivery Details  

        [FindsBy(How = How.Id, Using = "button-shipping-address")]
        private IWebElement continue3Button { get; set; }

        virtual public CheckoutStep4Page FinishStep3()
        {
            continue3Button.Click();
            return new CheckoutStep4Page(driver);
        }

        virtual public void WaitForLoadedStep()
        {
            Wait.WaitForElementVisible(driver, step3Content);
        }

        #endregion Step 3: Delivery Details 
    }
}