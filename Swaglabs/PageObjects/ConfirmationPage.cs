using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Swaglabs.PageObjects
{
    internal class ConfirmationPage : IPageTitle
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "#header_container .title")]
        private IWebElement PageTitleBar { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#checkout_complete_container > .complete-header")]
        public IWebElement OrderConfirmed { get; set; }

        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GetPageTitle()
        {
            return PageTitleBar.Text;
        }

        public string GetConfirmationText()
        {
            return OrderConfirmed.Text;
        }
        
    }
}


