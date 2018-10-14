using NLog;
using OpenQA.Selenium;

namespace Store.PageObjects
{
    public class CheckoutStep3GuestPage : CheckoutStep3Page
    {
        private IWebDriver driver;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        public CheckoutStep3GuestPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        override public void WaitForLoadedStep()
        {
        }

        override public CheckoutStep4Page FinishStep3()
        {
            return new CheckoutStep4Page(driver);
        }
    }
}
