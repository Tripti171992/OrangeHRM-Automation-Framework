using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRM.Automation.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrangeHRM.Automation.Tests.Pages
{
    internal class EmployeeListPage : PIMNavigationComponent
    {
        private const string PageName = "EmployeeListPage";
        public EmployeeListPage(IWebDriver driver) : base(driver)
        {
            wait.WaitForInvisibility(GetLocator(PageName, "LoaderSpinner", "XPATH"));
            wait.WaitForUrlContains("/pim/viewEmployeeList");
        }

        // ---- Actions ----

        public AddEmployeePage ClickAdd()
        {
            keyword.Click(GetLocator(PageName, "AddButton", "XPATH"), "AddButton");
            return new AddEmployeePage(driver);
        }

        public void SearchEmployeeByName(string employeeName)
        {
            keyword.Type(GetLocator(PageName, "EmployeeName", "XPATH"), "EmployeeName", employeeName);
            keyword.Click(GetLocator(PageName, "SearchButton", "XPATH"), "SearchButton");
            Thread.Sleep(500);
            wait.WaitForInvisibility(GetLocator(PageName, "LoaderSpinner", "XPATH"));
        }
        public void SearchByEmployeeId(string employeeId)
        {
            keyword.Type(GetLocator(PageName, "EmployeeId", "XPATH"), "EmployeeId", employeeId);
            keyword.Click(GetLocator(PageName, "SearchButton", "XPATH"), "SearchButton");
            Thread.Sleep(500);
            wait.WaitForInvisibility(GetLocator(PageName, "LoaderSpinner", "XPATH"));
        }


        // ---- Assertions ----

        public bool IsNoRecordsFoundDisplayed()
        {
            try
            {
                return keyword.IsDisplayed(GetLocator(PageName, "NoRecordFoundMessage", "XPATH"), "NoRecordFoundMessage");
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsOnEmployeeList()
        {
            return wait.WaitForUrlContains("/viewEmployeeList");
        }

        public bool IsOnViewPersonalDetails()
        {
            return wait.WaitForUrlContains("/viewPersonalDetails");
        }
        public int GetRecordCount()
        {
            return keyword.Count(GetLocator(PageName, "Record", "XPATH"), "Record");
        }

    }

}
