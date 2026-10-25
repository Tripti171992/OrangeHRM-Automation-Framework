using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace OrangeHRM.Automation.Tests.Utilities
{
    internal static class DriverFactory
    {
        // Creates and returns a WebDriver instance for the specified browser.
        internal static IWebDriver CreateDriver(string browser)
        {

            switch (browser.Trim().ToLower())
            {
                case "chrome":

                    ChromeOptions chromeOptions = new ChromeOptions();

                    // Configures Chrome to run without a visible browser window.
                    if (ConfigurationReader.Headless)
                    {
                        chromeOptions.AddArgument("--headless=new");
                        chromeOptions.AddArgument("--window-size=1920,1080");
                    }

                    return new ChromeDriver(chromeOptions);

                case "firefox":

                    FirefoxOptions firefoxOptions = new FirefoxOptions();

                    // Configures Firefox to run without a visible browser window.
                    if (ConfigurationReader.Headless)
                    {
                        firefoxOptions.AddArgument("-headless");
                        firefoxOptions.AddArgument("--window-size=1920,1080");
                    }

                    return new FirefoxDriver(firefoxOptions);

                case "edge":

                    EdgeOptions edgeOptions = new EdgeOptions();

                    // Configures Microsoft Edge to run without a visible browser window.
                    if (ConfigurationReader.Headless)
                    {
                        edgeOptions.AddArgument("--headless=new");
                        edgeOptions.AddArgument("--window-size=1920,1080");
                    }

                    return new EdgeDriver(edgeOptions);

                default:
                    throw new ArgumentException(
                        $"Unsupported browser: {browser}");
            }
        }
    }
}
