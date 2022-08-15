using Bidscale.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidscale.PageObjects
{
    internal class ProductsPage
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



        public string GetShoppingCartBadgeNumber()
        {
            return ShoppingCartBadge.GetAttribute("textContent");
        }
        
    }
}


