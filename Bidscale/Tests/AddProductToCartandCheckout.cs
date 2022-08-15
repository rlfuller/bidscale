using Bidscale.PageObjects;
using Bidscale.Utilities;

namespace Bidscale.Tests
{
    public class Test : BaseTest
    {
        [Test]
        public void HappyPathTest()
        {
            //verify we are on the products page after logging in 
            var productPage = new ProductsPage(driver);

            string expectedPageTitle = "PRODUCTS";
            string actualPageTitle = productPage.GetPageTitle();
            Assert.That(actualPageTitle, Is.EqualTo(expectedPageTitle), $"Page is not correct. Should be {expectedPageTitle}, but is {actualPageTitle}");

            //click the 'add to cart' button on the first item on the products page
            //productPage.ClickProductAddToCartButton(0);
            productPage.ClickRandomProductAddToCartButton();

            //confirm that item is in cart
            string expectedBadge = "1";
            string actualBadge = productPage.GetShoppingCartBadgeNumber();
            Assert.That(actualBadge, Is.EqualTo(expectedBadge), $"Cart Badge should show 1 item. Instead it shows {actualBadge}");

            //click shopping cart
            productPage.ShoppingCartButton.Click();

            //verify we are on the Shopping Cart Page
            var shoppingCartPage = new ShoppingCartPage(driver);

            expectedPageTitle = "YOUR CART";
            actualPageTitle = shoppingCartPage.GetPageTitle();
            Assert.That(actualPageTitle, Is.EqualTo(expectedPageTitle), $"Page is not correct. Should be {expectedPageTitle}, but is {actualPageTitle}");

            shoppingCartPage.CheckoutButton.Click();

            //verify we are on the Information Page
            var checkoutInformationPage = new CheckoutInformationPage(driver);

            expectedPageTitle = "CHECKOUT: YOUR INFORMATION";
            actualPageTitle = shoppingCartPage.GetPageTitle().Trim();
            Assert.That(actualPageTitle, Is.EqualTo(expectedPageTitle), $"Page is not correct. Should be {expectedPageTitle}, but is {actualPageTitle}");

            //fill out form
            checkoutInformationPage.FillOutInformation(
                Constants.CustomerFirstName,
                Constants.CustomerLastName,
                Constants.CustomerPostal);

            checkoutInformationPage.ContinueButton.Click();

            //verify we are on the checkout page
           
            var checkoutPage = new CheckoutPage(driver);

            expectedPageTitle = "CHECKOUT: OVERVIEW";
            actualPageTitle = checkoutPage.GetPageTitle().Trim();
            Assert.That(actualPageTitle, Is.EqualTo(expectedPageTitle), $"Page is not correct. Should be {expectedPageTitle}, but is {actualPageTitle}");

            checkoutPage.FinishButton.Click();

            expectedPageTitle = "CHECKOUT: COMPLETE!";
            actualPageTitle = checkoutPage.GetPageTitle().Trim();

            Assert.That(actualPageTitle, Is.EqualTo(expectedPageTitle), $"Page is not correct. Should be {expectedPageTitle}, but is {actualPageTitle}");

        }
    }
}