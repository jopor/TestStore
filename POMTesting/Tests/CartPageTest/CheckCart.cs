using FluentAssertions;
using NUnit.Framework;

namespace Store.PageObjects
{
    class CheckCart : InitClass
    {
        private HomePage home;
        private CartPage cart;

        [Test]
        public void ShouldDisplayWarningMessageDuringAttemptToCheckoutOneProduct()
        {
            home = new HomePage(driver);
            home.AddProductToChart();
            home.GetCartButtonMessage().Should().Contain("1 item(s)", "Invalid cart items amount");
            cart = home.GoToCartPage();
            cart.TryToCheckout();
            cart.GetMessage().Should().Contain("Minimum order amount for Test product 1 is 2!", "Invalid message");
        }
    }
}
