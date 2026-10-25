using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OrangeHRM.Automation.Tests.Model;
using OrangeHRM.Automation.Tests.Pages;
using OrangeHRM.Automation.Tests.Utilities;


namespace OrangeHRM.Automation.Tests.Base
{
    internal abstract class BaseTest
    {
        // Stores WebDriver and ExtentTest instances separately for each thread
        // to support parallel test execution.
        public static readonly ThreadLocal<IWebDriver> Driver = new();
        public static readonly ThreadLocal<ExtentTest> ExTest = new();


        // Returns the WebDriver instance associated with the current thread.
        // Throws an exception if the browser has not been initialized.
        public static IWebDriver GetDriver()
        {
            if (Driver.Value == null)
            {
                throw new InvalidOperationException(
                    "WebDriver has not been initialized for this thread.");
            }
            return Driver.Value;
        }


        // Returns the ExtentTest instance associated with the current thread.
        // Throws an exception if the test report has not been initialized.
        public static ExtentTest GetExtentTest()
        {
            if (ExTest.Value == null)
            {
                throw new InvalidOperationException(
                    "ExtentTest has not been initialized for this thread.");
            }
            return ExTest.Value;
        }

        // Runs before each test 

        [SetUp]
        public void SetUp()
        {
            ITestExecutionModel testdata = (ITestExecutionModel)TestContext.CurrentContext.Test.Arguments[0];

            ExTest.Value = ReportManager.CreateTest("Testcase: " + testdata.TestName);

            // Skips the test when its Runmode is set to N in the test data.
            if (testdata.Runmode.ToUpperInvariant() == "N")
            {
                Assert.Ignore("Test skipped because Runmode is N");
            }

            // Initializes the browser specified in the test data.
            SetUpBrowser(testdata.Browser);
        }



        // Runs after every test 

        [TearDown]
        public void TearDown()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;

            if (testStatus == TestStatus.Passed)
            {
                ReportManager.LogPass("Test case Passed");
            }
            else if (testStatus == TestStatus.Skipped)
            {
                ReportManager.LogSkip(TestContext.CurrentContext.Result.Message);
            }

            // Records the failure details and attaches a screenshot.
            else if (testStatus == TestStatus.Failed)
            {
                ReportManager.LogFail(TestContext.CurrentContext.Result.Message);
                if (GetDriver() != null)
                {
                    string screenshotPath = CaptureScreenshot();

                    // Attaches the screenshot to the failed test in the report.
                    GetExtentTest().Fail("<b><font color=red>  Screenshot of failure </font></b><br>", MediaEntityBuilder.CreateScreenCaptureFromPath("..\\Screenshots\\" + Path.GetFileName(screenshotPath)).Build());
                }
            }

            // Closes the browser and clears the current thread's driver reference.
            if (Driver.Value != null)
            {
                GetDriver().Quit();
                Driver.Value = null;
            }

        }


        // Creates the requested browser, configures its window,
        // and navigates to the application's base URL.
        protected void SetUpBrowser(string browser)
        {
            Driver.Value = DriverFactory.CreateDriver(browser);
            if (!ConfigurationReader.Headless)
            {
                GetDriver().Manage().Window.Maximize();
            }
            GetDriver().Navigate().GoToUrl(ConfigurationReader.BaseUrl);
        }


        // Logs in with the configured admin credentials
        protected DashboardPage LoginAsAdmin()
        {
            LoginPage loginPage = new LoginPage(GetDriver());

            DashboardPage dashboardPage = loginPage.Login(ConfigurationReader.Username, ConfigurationReader.Password);

            Assert.That(dashboardPage.IsOnDashboard(), Is.True, "Login failed. Dashboard was not displayed.");

            ReportManager.LogInfo("Logged in successfully!");
            return dashboardPage;

        }


        // Captures the current browser screen and saves it
        // in the project's Screenshots folder with a unique filename.
        private string CaptureScreenshot()
        {
            Random random = new Random();

            DateTime currentTime = DateTime.Now;
            string fileName = currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + random.Next(1, 500) + ".jpg";

            string screenshotFolder = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, ConfigurationReader.ScreenshotsFolder);

            // Creates the screenshot folder if it does not already exist.
            Directory.CreateDirectory(screenshotFolder);

            string screenshotPath = Path.Combine(screenshotFolder, fileName);

            Screenshot screenshot = ((ITakesScreenshot)GetDriver()).GetScreenshot();

            // Saves the screenshot and returns its full file path.
            screenshot.SaveAsFile(screenshotPath);
            return screenshotPath;

        }
    }
}
