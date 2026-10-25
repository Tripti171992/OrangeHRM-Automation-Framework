
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRM.Automation.Tests.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Linq;


namespace OrangeHRM.Automation.Tests.Utilities
{
    internal class KeywordDriven
    {
        private readonly IWebDriver driver;
        private readonly WaitUtility wait;

        // Initializes the keyword actions with the current browser driver and wait utility.
        public KeywordDriven(IWebDriver driver, WaitUtility wait)
        {
            this.driver = driver;
            this.wait = wait;
        }
        public void Click(By locator, string elementName)
        {
            wait.WaitForClickable(locator).Click();

            ReportManager.LogInfo("Clicking on an Element : " + elementName);
        }
        public void Clear(By locator, string elementName)
        {
            IWebElement element = wait.WaitForClickable(locator);

            element.Click();
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Backspace);

            ReportManager.LogInfo("Clearing an Element : " + elementName);
        }
        public void ClearAndType(By locator, string elementName, string text)
        {
            IWebElement element = wait.WaitForClickable(locator);

            element.Click();
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Backspace);

            element.SendKeys(text);
            ReportManager.LogInfo("Clearing and typing in an Element : " + elementName);
        }
        public string GetText(By locator, string elementName)
        {
            string text = wait.WaitForVisible(locator).Text;

            ReportManager.LogInfo("Getting the text of an Element : " + elementName);

            return text;
        }
        public void Type(By locator, string elementName, string text)
        {
            wait.WaitForClickable(locator).SendKeys(text);

            ReportManager.LogInfo("Typing in an Element : " + elementName + " value entered as : " + text);
        }
        public ReadOnlyCollection<IWebElement> FindElements(By locator, string elementName)
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);

            ReportManager.LogInfo("Finding Elements : " + elementName);

            return elements;
        }
        public int Count(By locator, string elementName)
        {
            int count = driver.FindElements(locator).Count();

            ReportManager.LogInfo("Counting the number of elements in:" + elementName);

            return count;
        }
        public void Select(By locator, string elementName, string value)
        {
            IWebElement element = wait.WaitForClickable(locator);

            SelectElement selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);

            ReportManager.LogInfo("Seleting an Element : " + elementName + " selected the value as : " + value);
        }

        public bool IsElementPresent(By locator, string elementName)
        {
            try
            {
                wait.WaitForPresent(locator);

                ReportManager.LogInfo("Finding an Element : " + elementName);

                return true;
            }
            catch (Exception ex)
            {
                ReportManager.LogInfo("Error while finding an Element : " + elementName);

                return false;
            }
        }

        public bool IsDisplayed(By locator, string elementName)
        {
            bool result = wait.WaitForVisible(locator).Displayed;

            ReportManager.LogInfo("Verifying the Element " + elementName + " is displayed or not. ");

            return result;
        }
    }
}
