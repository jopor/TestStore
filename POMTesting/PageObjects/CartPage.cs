using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Store.Helpers;

namespace Store.PageObjects
{
    public class CartPage
    {
        private IWebDriver driver;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            Wait.WaitForElementVisible(driver, cartConent);
        }

        [FindsBy(How = How.CssSelector, Using = ".buttons .pull-right a")]
        private IWebElement checkoutButton { get; set; }

        [FindsBy(How = How.Id, Using = "checkout-cart")]
        private IWebElement cartConent { get; set; }

        public CheckoutStep1Page ClickOnCheckoutButton()
        {
            checkoutButton.Click();
            log.Info($"Click on Checkout button on Cart page");
            return new CheckoutStep1Page(driver);
        }

        public void TryToCheckout()
        {
            checkoutButton.Click();
            log.Info($"Check validation on Cart page by clicking on Checkout button");
        }

        public string GetMessage()
        {
            log.Info($"Verify message on Cart page");
            return cartConent.Text.ToString();
        }
    }
}