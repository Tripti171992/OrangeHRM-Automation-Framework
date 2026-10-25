using OpenQA.Selenium;
using OrangeHRM.Automation.Tests.Model;
using OrangeHRM.Automation.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Pages
{
    internal class AddEmployeePage: PIMNavigationComponent
    {
        private const string PageName = "AddEmployeePage";
        public AddEmployeePage(IWebDriver driver) : base(driver)
        {
            wait.WaitForUrlContains("/pim/addEmployee");
        }

        // ---- Actions ----

        public AddEmployeePage AddEmployee(EmployeeModel testdata)
        {
            keyword.Type(GetLocator(PageName, "FirstName", "XPATH"), "FirstName", testdata.FirstName);
            keyword.Type(GetLocator(PageName, "MiddleName", "XPATH"), "MiddleName", testdata.MiddleName);
            keyword.Type(GetLocator(PageName, "LastName", "XPATH"), "LastName", testdata.LastName);

            if (testdata.EmployeeId != "")
            {
                keyword.Clear(GetLocator(PageName, "EmployeeId", "XPATH"), "EmployeeId");
                keyword.Type(GetLocator(PageName, "EmployeeId", "XPATH"), "EmployeeId", testdata.EmployeeId);
            }

            wait.WaitForInvisibility(GetLocator(PageName, "LoaderSpinner", "XPATH"));
            keyword.Click(GetLocator(PageName, "SaveButton", "XPATH"), "SaveButton");

            return this;
        }

        public EmployeeListPage CancelAddEmployee(EmployeeModel testdata)
        {          
            keyword.Type(GetLocator(PageName, "FirstName", "XPATH"), "FirstName", testdata.FirstName);
            keyword.Type(GetLocator(PageName, "MiddleName", "XPATH"), "MiddleName", testdata.MiddleName);
            keyword.Type(GetLocator(PageName, "LastName", "XPATH"), "LastName", testdata.LastName);

            if (testdata.EmployeeId != "")
            {
                keyword.ClearAndType(GetLocator(PageName, "EmployeeId", "XPATH"), "EmployeeId", testdata.EmployeeId);
                
            }

            wait.WaitForInvisibility(GetLocator(PageName, "LoaderSpinner", "XPATH"));
            keyword.Click(GetLocator(PageName, "CancelButton", "XPATH"), "CancelButton");

            return new EmployeeListPage(driver);
        }
        public string GetSuccessMessage()
        {
            return keyword.GetText(GetLocator(PageName, "SuccessToast", "XPATH"), "SuccessToast");
        }

        // ---- Assertions ----
        public bool IsSuccessMessageDisplayed()
        {
            try
            {
                bool value = keyword.IsDisplayed(GetLocator(PageName, "SuccessToast", "XPATH"), "SuccessToast");                
                wait.WaitForInvisibility(GetLocator(PageName, "LoaderSpinner", "XPATH"));
                return value;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsFirstNameRequiredErrorDisplayed()
        {
            try
            {
                return keyword.IsDisplayed(GetLocator(PageName, "FirstNameError", "XPATH"), "FirstNameError");
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsLastNameRequiredErrorDisplayed()
        {
            try
            {
                return keyword.IsDisplayed(GetLocator(PageName, "LastNameError", "XPATH"), "LastNameError");
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsEmployeeIDExistErrorDisplayed()
        {
            try
            {
                return keyword.IsDisplayed(GetLocator(PageName, "EmployeeIDExistError", "XPATH"), "EmployeeIDExistError");
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
