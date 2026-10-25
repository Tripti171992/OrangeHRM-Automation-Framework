using OpenQA.Selenium;
using OrangeHRM.Automation.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Pages
{
    internal class PIMNavigationComponent:BasePage
    {
        private const string PageName = "PIMNavigation";
        public PIMNavigationComponent(IWebDriver driver):base(driver)
        {
        }
        public EmployeeListPage NavigateToEmployeeList()
        {
            wait.WaitForInvisibility(GetLocator(PageName, "LoaderSpinner", "XPATH"));
            keyword.Click(GetLocator(PageName, "EmployeeListTab", "XPATH"), "EmployeeListTab");
            return new EmployeeListPage(driver);
        }
        public AddEmployeePage NavigateToAddEmployee()
        {
            keyword.Click(GetLocator(PageName, "AddEmployeeTab", "XPATH"), "AddEmployeeTab");
            return new AddEmployeePage(driver);
        }
        public PIMNavigationComponent NavigateToConfiguration()
        {
            keyword.Click(GetLocator(PageName, "ConfigurationTab", "XPATH"), "ConfigurationTab");
            return this;
        }
        public PIMNavigationComponent NavigateToReports()
        {
            keyword.Click(GetLocator(PageName, "ReportsTab", "XPATH"), "ReportsTab");
            return this;
        }
    }

    }
