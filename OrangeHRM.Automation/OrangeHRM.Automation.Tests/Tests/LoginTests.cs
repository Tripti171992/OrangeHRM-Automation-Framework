using NUnit.Framework.Interfaces;
using OrangeHRM.Automation.Tests.Base;
using OrangeHRM.Automation.Tests.Model;
using OrangeHRM.Automation.Tests.Pages;
using OrangeHRM.Automation.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Tests
{

    [TestFixture]
    [Parallelizable]
    internal class LoginTests : BaseTest
    {
        [Parallelizable(ParallelScope.Children)]
        [TestCaseSource(nameof(GetLoginData))]
        public void LoginWithValidCredentials(LoginModel testData)
        {
            LoginPage loginPage = new LoginPage(GetDriver());

            DashboardPage dashboardPage = loginPage.Login(testData.Username, testData.Password);

            Assert.That(dashboardPage.IsOnDashboard(), Is.True, "Login failed. Dashboard was not displayed.");

            ReportManager.LogInfo("User logged in successfully!!");
        }

        [Parallelizable(ParallelScope.Children)]
        [TestCaseSource(nameof(GetInvalidLoginData))]
        public void LoginWithInvalidCredentials(LoginModel testData)
        {
            LoginPage loginPage = new LoginPage(GetDriver());
            loginPage.InvalidLogin(testData.Username, testData.Password);
            if (testData.Username == "" || testData.Password == "")
            {
                if (testData.Username == "")
                {
                    Assert.That(loginPage.IsUsernameRequiredDisplayed(), Is.True, "Required error message should be displayed for username");
                    ReportManager.LogInfo("Username required message verified.");
                }
                if (testData.Password == "")
                {
                    Assert.That(loginPage.IsPasswordRequiredDisplayed(), Is.True, "Required error message should be displayed for password");
                    ReportManager.LogInfo("Password required message verified.");
                }
            }
            else
            {
                Assert.That(loginPage.IsInvalidCredentialsDisplayed(), Is.True, "Invalid Credentials error message should be displayed for logging in with wrong credentials");
                ReportManager.LogInfo("Invalid credentials error message verified.");
            }
        }

        [TestCaseSource(nameof(GetForgotPasswordData))]
        public void ForgotPassword(TestExecutionModel testData)
        {
            LoginPage loginPage = new LoginPage(GetDriver());
            loginPage.ClickForgotPassword();
            Assert.That(loginPage.IsOnForgotPasswordPage(),Is.True, "Should navigate to forgot password page");
            ReportManager.LogInfo("User moved to forgot your password page successfully!!");

        }

        [TestCaseSource(nameof(GetLoginData))]
        public void LogOut(LoginModel testData)
        {
            LoginPage loginPage = new LoginPage(GetDriver());

            DashboardPage dashboardPage = loginPage.Login(testData.Username, testData.Password);

            Assert.That(dashboardPage.IsOnDashboard(), Is.True, "Login failed. Dashboard was not displayed.");

            ReportManager.LogInfo("User logged in successfully!!");

            dashboardPage.Logout();
            Assert.That(loginPage.IsOnLoginPage(), Is.True, "User should be redirected to login page after logout");
            ReportManager.LogInfo("User logged out successfully!!");

        }

        public static IEnumerable<TestCaseData> GetInvalidLoginData()
        {
            return TestDataSource.GetTestData<LoginModel>("InvalidLoginData.json");
        }
        public static IEnumerable<TestCaseData> GetLoginData()
        {
            return TestDataSource.GetTestData<LoginModel>("ValidLoginData.json");
        }
        public static IEnumerable<TestCaseData> GetForgotPasswordData()
        {
            return TestDataSource.GetTestData<TestExecutionModel>("ForgotPasswordData.json");
        }
    }
}
