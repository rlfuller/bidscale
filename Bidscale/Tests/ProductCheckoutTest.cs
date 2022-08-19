using Bidscale.PageObjects;

namespace Bidscale.Tests
{
    public class ProductCheckoutTest : BaseTest
    {
        [Test]
        public void HappyPathTest()
        {
            //verify we are on the products page after logging in 
            var productPage = new ProductsPage(driver);

            CheckPageTitle("PRODUCTS", productPage);

            //click the 'add to cart' button on the first item on the products page
            //productPage.ClickProductAddToCartButton(0);
            productPage.ClickRandomProductAddToCartButton();

            string itemName = productPage.GetItemName();

            //confirm that item is in cart
            string expectedBadge = "1";
            string actualBadge = productPage.GetShoppingCartBadgeNumber();
            Assert.That(actualBadge, Is.EqualTo(expectedBadge), $"Cart Badge should show 1 item. Instead it shows {actualBadge}");

            //click shopping cart
            productPage.ShoppingCartButton.Click();

            //verify we are on the Shopping Cart Page
            var shoppingCartPage = new ShoppingCartPage(driver);

            CheckPageTitle("YOUR CART", shoppingCartPage);

            string actualItemInCart = shoppingCartPage.GetItem();
            //verify item is correct
            Assert.That(actualItemInCart, Is.EqualTo(itemName), $"Item in cart is not correct. Should be {itemName}, but is {actualItemInCart}");

            shoppingCartPage.CheckoutButton.Click();

            //verify we are on the Information Page
            var checkoutInformationPage = new CheckoutInformationPage(driver);

            CheckPageTitle("CHECKOUT: YOUR INFORMATION", checkoutInformationPage);

            //fill out form
            checkoutInformationPage.FillOutInformation(
                Constants.CustomerFirstName,
                Constants.CustomerLastName,
                Constants.CustomerPostal);

            checkoutInformationPage.ContinueButton.Click();

            //verify we are on the checkout page
           
            var checkoutPage = new CheckoutPage(driver);

            CheckPageTitle("CHECKOUT: OVERVIEW", checkoutPage);

            checkoutPage.FinishButton.Click();

            var confirmationPage = new ConfirmationPage(driver);
            CheckPageTitle("CHECKOUT: COMPLETE!", confirmationPage);
                        
            string actualOrderConfirmed = confirmationPage.GetConfirmationText().Trim();
            string expectedOrderConfirmed = "THANK YOU FOR YOUR ORDER";
            Assert.That(actualOrderConfirmed, Is.EqualTo(expectedOrderConfirmed), $"Confirmation Message is incorrect: was {actualOrderConfirmed}, but should be {expectedOrderConfirmed}");

        }

        public void CheckPageTitle(string expected, IPageTitle page)
        {
            string actualPageTitle = page.GetPageTitle().Trim();
            Assert.That(actualPageTitle, Is.EqualTo(expected), $"Page is not correct. Should be {expected}, but is {actualPageTitle}");
        }
    }
}