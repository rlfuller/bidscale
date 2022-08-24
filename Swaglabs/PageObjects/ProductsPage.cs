using Swaglabs.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Swaglabs.PageObjects
{
    internal class ProductsPage : IPageTitle
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "#header_container .title")]
        private IWebElement PageTitleBar { get; set; }

        [FindsBy(How = How.ClassName, Using = "inventory_item")]
        private IList<IWebElement> AllProducts { get; set; }

        [FindsBy(How = How.ClassName, Using = "shopping_cart_badge")]
        private IWebElement ShoppingCartBadge { get; set; }

        [FindsBy(How = How.ClassName, Using = "shopping_cart_link")]
        public IWebElement ShoppingCartButton { get; set; }

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GetPageTitle()
        {
            return PageTitleBar.Text;
        }

        public ProductsPage ClickProductAddToCartButton(int idx)
        {
            if (idx < 0 || idx >= AllProducts.Count)
            {
                throw new ArgumentOutOfRangeException($"Index must be a positive integer, and less than the number of available products ({AllProducts.Count})");
            }

            AllProducts[idx].FindElement(By.CssSelector(".pricebar > .btn_inventory")).Click();
            return this;
        }

        public ProductsPage ClickRandomProductAddToCartButton()
        {
            int randomIndex = Common.GetRandom(0, AllProducts.Count);
            return ClickProductAddToCartButton(randomIndex);
        }

        public string GetItemName()
        {
            int index = Common.GetRandom(0, AllProducts.Count);
            return AllProducts[index].FindElement(By.ClassName("inventory_item_name")).Text;
        }

        public string GetShoppingCartBadgeNumber()
        {
            return ShoppingCartBadge.GetAttribute("textContent");
        }
        
    }
}


