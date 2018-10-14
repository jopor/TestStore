using NLog;
using OpenQA.Selenium;

namespace Store.PageObjects
{
    class CheckoutStep3RegisterPage : CheckoutStep3Page
    {
        private IWebDriver driver;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        public CheckoutStep3RegisterPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        override public CheckoutStep4Page FinishStep3()
        {
            base.FinishStep3();
            log.Info($"Click on Continue button on Checkout Step 3 as Register");
            return new CheckoutStep4Page(driver);
        }

        override public void WaitForLoadedStep()
        {
            base.WaitForLoadedStep();
        }
    }
}
