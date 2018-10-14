using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Store.PageObjects
{
    public class CheckoutStep2GuestPage : CheckoutStep2Page
    {
        private IWebDriver driver;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        public CheckoutStep2GuestPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        [FindsBy(How = How.Id, Using = "button-guest")]
        private IWebElement continueAsGuestButton { get; set; }

        override public void SetPersonalDetails()
        {
            base.SetPersonalDetails();
        }

        override public void SetAddress()
        {
            base.SetAddress();
        }

        override public void CheckTheSameAddressForDeliveryAndBiling()
        {
            base.CheckTheSameAddressForDeliveryAndBiling();
        }

        override public CheckoutStep3Page FinishStep2()
        {
            continueAsGuestButton.Click();
            log.Info($"Click on Continue button on Checkout Step 2 as Guest");
            return new CheckoutStep3GuestPage(driver);
        }

        override public void TryToFinishStep2()
        {
            continueAsGuestButton.Click();
            log.Info($"Check validation on Checkout Step 2 as Guest by clicking on Checkout button");
            base.TryToFinishStep2();
        }
    }
}
