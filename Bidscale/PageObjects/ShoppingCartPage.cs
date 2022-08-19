using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Bidscale.PageObjects
{
    internal class ShoppingCartPage : IPageTitle
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "#header_container .title")]
        private IWebElement PageTitleBar { get; set; }

        [FindsBy(How = How.Id, Using = "checkout")]
        public IWebElement CheckoutButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "inventory_item_name")]
        public IWebElement FirstInventoryItem { get; set; }

        public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GetPageTitle()
        {
            return PageTitleBar.Text;
        }

        public string GetItem()
        {
            return FirstInventoryItem.Text;
        }

    }
}
