using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Swaglabs.Utilities
{
    public class Driver
    {
        private static IWebDriver webDriver { get; set; }

        public static IWebDriver GetInstance()
        {
            if (webDriver is not null)
            {
                return webDriver;
            }

            string? browser = Environment.GetEnvironmentVariable("AutomationBrowser");
            if (browser is null)
            {
                browser = "";
            }

            switch (browser.ToLower())
            {
                case "chrome":
                    webDriver = new ChromeDriver();
                    break;

                case "edge":
                    webDriver = new EdgeDriver();
                    break;

                default:
                    webDriver = new FirefoxDriver();
                    break;
            }

            return webDriver;
        }
    }
}
