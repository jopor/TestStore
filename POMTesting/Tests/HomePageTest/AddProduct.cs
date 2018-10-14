using FluentAssertions;
using NUnit.Framework;

namespace Store.PageObjects
{
    class AddProduct : InitClass
    {
        [Test]
        public void ShouldBeOneProductOnCart()
        {
            HomePage home = new HomePage(driver);
            home.AddProductToChart();
            home.GetCartButtonMessage().Should().Contain("1 item(s)", "Invalid cart items amount");
        }
    }
}
