using OpenQA.Selenium;
using OrangeHRM.Automation.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Pages
{
    internal class AuthenticatedPage:BasePage
    {
        private const string PageName = "AuthenticatedPage";

        public AuthenticatedPage(IWebDriver driver):base(driver)
        {
        }

        // ---- Actions ----
        public LoginPage Logout()
        {
            keyword.Click(GetLocator(PageName, "UserDropdown", "CSS"), "UserDropdown");
            keyword.Click(GetLocator(PageName, "Logout", "XPATH"), "Logout");

            return new LoginPage(driver);
        }
        public EmployeeListPage NavigateToPIM()
        {
            keyword.Click(GetLocator(PageName, "PIMMenu", "XPATH"), "PIMMenu");
            return new EmployeeListPage(driver);
        }
        public DashboardPage NavigateToDashboard()
        {
            keyword.Click(GetLocator(PageName, "DashboardMenu", "XPATH"), "DashboardMenu");
            return new DashboardPage(driver);
        }
        public AuthenticatedPage NavigateToLeave()
        {
            keyword.Click(GetLocator(PageName, "LeaveMenu", "XPATH"), "LeaveMenu");
            return this;
        }
        public AuthenticatedPage NavigateToAdmin()
        {
            keyword.Click(GetLocator(PageName, "AdminMenu", "XPATH"), "AdminMenu");
            return this;
        }
        public AuthenticatedPage NavigateToRecruitment()
        {
            keyword.Click(GetLocator(PageName, "RecruitmentMenu", "XPATH"), "RecruitmentMenu");
            return this;
        }

        // ---- Assertions ----

        public bool IsNavMenuVisible()
        {
            try
            {
                return keyword.IsDisplayed(GetLocator(PageName, "NavigationMenu", "XPATH"), "NavigationMenu");
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
