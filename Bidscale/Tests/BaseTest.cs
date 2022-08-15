using Bidscale.PageObjects;
using Bidscale.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidscale.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver = Driver.GetInstance();
        protected Config config = Environments.Config;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("hello world - setup");

            driver = Driver.GetInstance();
            driver.Navigate().GoToUrl(config.Url);
            //Assert.Pass();

            //Login
            var loginPage = new LoginPage(driver);
            loginPage.Login(config.Username, config.Password);
        }

        //  [Test]
        //  public void DoTheNeedful()
        //  {
        //driver.Navigate().GoToUrl("https://www.google.com");
        //Assert.Pass();
        // }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
