using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace OrangeHRM.Automation.Tests.Utilities
{
    internal class WaitUtility
    {
        private readonly WebDriverWait wait;

        public WaitUtility(IWebDriver driver, int timeoutInSeconds)
        {

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
        }
        public IWebElement WaitForClickable(By locator)
        {
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));            
        }
        public IWebElement WaitForVisible(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        public IWebElement WaitForPresent(By locator)
        {
            return wait.Until(ExpectedConditions.ElementExists(locator));
        }
        public bool WaitForInvisibility(By locator)
        {
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
        public bool WaitForUrlContains(string text)
        {
            return wait.Until(ExpectedConditions.UrlContains(text));
        }
    }
}
