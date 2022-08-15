using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Bidscale.PageObjects
{
    internal class LoginPage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement LoginButton { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }


        public void Login(string user, string pass)
        {
            Username.SendKeys(user);
            Password.SendKeys(pass);
            LoginButton.Click();

        }

    }
}
