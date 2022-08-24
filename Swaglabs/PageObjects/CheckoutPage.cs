using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Swaglabs.PageObjects
{
    internal class CheckoutPage : IPageTitle
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "#header_container .title")]
        private IWebElement PageTitleBar { get; set; }

        [FindsBy(How = How.Id, Using = "finish")]
        public IWebElement FinishButton { get; set; }

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GetPageTitle()
        {
            return PageTitleBar.Text;
        }
        
    }
}


