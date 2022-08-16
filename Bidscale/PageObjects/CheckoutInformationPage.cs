using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Bidscale.PageObjects
{
    internal class CheckoutInformationPage : IPageTitle
    {
        IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "#header_container .title")]
        private IWebElement PageTitleBar { get; set; }

        [FindsBy(How = How.Id, Using = "first-name")]
        private IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "last-name")]
        private IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "postal-code")]
        private IWebElement ZipCode { get; set; }

        [FindsBy(How = How.Id, Using = "continue")]
        public IWebElement ContinueButton { get; set; }

        public CheckoutInformationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string GetPageTitle()
        {
            return PageTitleBar.Text;
        }


        public CheckoutInformationPage FillOutInformation(string firstName, string lastName, string zipCode)
        {
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            ZipCode.SendKeys(zipCode);

            return this;
        }

    }
}


