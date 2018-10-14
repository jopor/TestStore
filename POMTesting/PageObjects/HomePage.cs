using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Store.Helpers;

namespace Store.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            Wait.WaitForLoadedPage(driver);
        }

        [FindsBy(How = How.CssSelector, Using = ".product-thumb button>i.fa-shopping-cart")]
        private IWebElement addToCartButton { get; set; }
        [FindsBy(How = How.Id, Using = "cart-total")]
        private IWebElement cartButton { get; set; }

        public void AddProductToChart()
        {
            addToCartButton.Click();
            log.Info($"Added product to cart on Home page");
        }

        public CartPage GoToCartPage()
        {
            Actions.GoToUrl(driver, "route=checkout/cart");
            log.Info($"Go to Cart page from Home page");
            return new CartPage(driver);
        }

        public string GetCartButtonMessage()
        {
            Wait.WaitForElementVisible(driver, cartButton);
            log.Info($"Verify message from Cart button on Home page");
            return cartButton.Text.ToString();
        }
    }
}