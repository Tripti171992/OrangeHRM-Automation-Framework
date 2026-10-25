using System.Xml;

namespace OrangeHRM.Automation.Tests.Utilities
{
    internal static class XMLLocatorReader
    {
        public static string GetLocatorValue(string pageName, string elementName, string locatorType)
        {

            string locatorValue = null;
  

            //Load the XML File
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\locators.xml");

            //Get the root element
            XmlElement root = xmlDoc.DocumentElement;

            //Construct XPATH expression to select the specified element under the specified 
            //page with the given locator type
            string xpath = $"/locators/{pageName}/{elementName}[LocatorType='{locatorType}']/LocatorValue";


            //Select the locator value node
            XmlNode locatorValueNode = root.SelectSingleNode(xpath);


            if (locatorValueNode == null)
            {
                throw new ArgumentException(
                    $"Locator not found. Page: {pageName}, Element: {elementName}, Type: {locatorType}");
            }

            return locatorValueNode.InnerText;
        }
        }
}
