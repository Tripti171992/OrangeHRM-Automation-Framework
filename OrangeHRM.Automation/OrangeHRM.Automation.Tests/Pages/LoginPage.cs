using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRM.Automation.Tests.Utilities;


namespace OrangeHRM.Automation.Tests.Pages
{
    internal class LoginPage:BasePage
    {
        private const string PageName = "LoginPage";
        public LoginPage(IWebDriver driver):base(driver)
        {
            wait.WaitForUrlContains("/auth/login");
        }
        public DashboardPage Login(string userName, string password)
        {
            keyword.Type(GetLocator(PageName, "Username", "XPATH"), "Username", userName);
            keyword.Type(GetLocator(PageName, "Password", "XPATH"), "Password", password);
            keyword.Click(GetLocator(PageName, "LoginButton", "XPATH"), "LoginButton");

            return new DashboardPage(driver);
        }

        public void InvalidLogin(string userName, string password)
        {
            keyword.Type(GetLocator(PageName, "Username", "XPATH"), "Username", userName);
            keyword.Type(GetLocator(PageName, "Password", "XPATH"), "Password", password);
            keyword.Click(GetLocator(PageName, "LoginButton", "XPATH"), "LoginButton");
        }
        public LoginPage ClickForgotPassword()
        {
            keyword.Click(GetLocator(PageName, "ForgotPassword", "XPATH"), "ForgotPassword");
            wait.WaitForUrlContains("/auth/requestPasswordResetCode");
            return this;
        }


        // ---- Assertions ----
        public bool IsOnLoginPage()
        {
            return GetCurrentURL().Contains("/auth/login");
        }
        public bool IsInvalidCredentialsDisplayed()
        {
            try
            {
                return keyword.IsDisplayed(GetLocator(PageName, "InvalidCredentialsMessage", "XPATH"), "InvalidCredentialsMessage");
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsUsernameRequiredDisplayed()
        {
            try
            {
                return keyword.IsDisplayed(GetLocator(PageName, "UsernameRequiredErrorMessage", "XPATH"), "UsernameRequiredErrorMessage");
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsPasswordRequiredDisplayed()
        {
            try
            {
                return keyword.IsDisplayed(GetLocator(PageName, "PasswordRequiredErrorMessage", "XPATH"), "PasswordRequiredErrorMessage");
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
        public bool IsOnForgotPasswordPage()
        {
            return GetCurrentURL().Contains("/auth/requestPasswordResetCode");
             
        }

    }
}
