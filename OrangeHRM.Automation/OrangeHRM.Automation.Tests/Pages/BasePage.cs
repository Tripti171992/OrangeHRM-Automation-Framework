using OpenQA.Selenium;
using OrangeHRM.Automation.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Pages
{
    internal class BasePage
    {
        public IWebDriver driver;
        protected readonly KeywordDriven keyword;
        protected readonly WaitUtility wait;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WaitUtility(driver,ConfigurationReader.ExplicitWait);
            keyword = new KeywordDriven(driver, wait);
        }

        protected string GetCurrentURL()
        {
            return driver.Url;
        }
        protected By GetLocator(string pageName,string elementName,string locatorType)
        {
            string locatorValue =XMLLocatorReader.GetLocatorValue(pageName,elementName,locatorType);

            switch (locatorType.Trim().ToUpperInvariant())
            {
                case "ID":
                    return By.Id(locatorValue);

                case "XPATH":
                    return By.XPath(locatorValue);

                case "CSS":
                case "CSSSELECTOR":
                    return By.CssSelector(locatorValue);

                case "NAME":
                    return By.Name(locatorValue);

                case "CLASSNAME":
                    return By.ClassName(locatorValue);

                case "LINKTEXT":
                    return By.LinkText(locatorValue);

                default:
                    throw new ArgumentException(
                        "Unsupported locator type: " + locatorType);
            }
        }
    }
}
