using NLog;
using OpenQA.Selenium;

namespace Store.PageObjects
{
    public class CheckoutStep2RegisterPage : CheckoutStep2Page
    {
        private IWebDriver driver;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        public CheckoutStep2RegisterPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        override public CheckoutStep3Page FinishStep2()
        {
            continueAsRegisterButton.Click();
            log.Info($"Click on Continue button on Checkout Step 2 as Register");
            return new CheckoutStep3RegisterPage(driver);
        }

        override public void TryToFinishStep2()
        {
            continueAsRegisterButton.Click();
            log.Info($"Check validation on Checkout Step 2 as Register by clicking on Checkout button");
            base.TryToFinishStep2();
        }
    }
}
