using OpenQA.Selenium;
using OrangeHRM.Automation.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrangeHRM.Automation.Tests.Pages
{
    internal class DashboardPage: AuthenticatedPage
    {
        public DashboardPage(IWebDriver driver):base(driver)
        {
            wait.WaitForUrlContains("/dashboard");
        }


        // ---- Assertions ----
        public bool IsOnDashboard()
        {
            return GetCurrentURL().Contains("/dashboard");
        }

    }
}
