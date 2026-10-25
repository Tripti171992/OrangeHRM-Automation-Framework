using AventStack.ExtentReports.Reporter.Config;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrangeHRM.Automation.Tests.Base;

namespace OrangeHRM.Automation.Tests.Utilities
{
    public static class ReportManager
    {
        // Holds the shared ExtentReports instance 
        private static ExtentReports extent;

        // Initializes the HTML report
        public static void Initialize()
        {

            if (extent != null)
            {
               //ExtentReports has already been initialized.
                return;
            }

            // Defines the directory where HTML reports will be stored
            string reportDirectory = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, ConfigurationReader.ReportsFolder);

            // Creates the Reports directory if it does not already exist.
            Directory.CreateDirectory(reportDirectory);

            string fileName = $"Report_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.html";
            string reportPath = Path.Combine(reportDirectory, fileName);

            // Configures the HTML report's appearance and metadata.
            var reporter = new ExtentSparkReporter(reportPath);
            reporter.Config.Theme = Theme.Standard;
            reporter.Config.DocumentTitle = ConfigurationReader.ReportTitle;
            reporter.Config.ReportName = ConfigurationReader.ReportName;
            reporter.Config.Encoding = "utf-8";

            // Creates the ExtentReports instance and attaches the HTML reporter.
            extent = new ExtentReports();
            extent.AttachReporter(reporter);

            // Adds application details to the report's system information section.
            extent.AddSystemInfo("Application", ConfigurationReader.Name);
            extent.AddSystemInfo("Automation Tester", "Tript");
            extent.AddSystemInfo("Environment", ConfigurationReader.Env);
        }


        // Creates and returns a report entry for an individual test case.
        public static ExtentTest CreateTest(string testName)
        {
            return extent.CreateTest(testName);
        }


        // Writes pending report information to the HTML report file.
        public static void Flush()
        {
            if (extent != null)
            {
                extent.Flush();
            }
        }

        // Retrieves the report entry associated with the current test thread.
        public static ExtentTest GetTest()
        {
            return BaseTest.ExTest.Value;
        }


        // Records an informational message in the current test's report entry.
        public static void LogInfo(string message)
        {
            GetTest().Info(message);
        }


        // Records a passed step in the current test's report entry.
        public static void LogPass(string message)
        {
            GetTest().Pass(message);
        }


        // Records a failed step in the current test's report entry.
        public static void LogFail(string message)
        {
            GetTest().Fail(message);
        }


        // Records a skipped test or step in the current test's report entry.
        public static void LogSkip(string message)
        {
            GetTest().Skip(message);
        }
    }
}
