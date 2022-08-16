using Bidscale.PageObjects;
using Bidscale.Utilities;
using OpenQA.Selenium;

namespace Bidscale.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver = Driver.GetInstance();
        protected Config config = Environments.Config;

        [SetUp]
        public void Setup()
        {
            driver = Driver.GetInstance();
            driver.Navigate().GoToUrl(config.Url);

            //Login
            var loginPage = new LoginPage(driver);
            loginPage.Login(config.Username, config.Password);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
