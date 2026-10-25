using OrangeHRM.Automation.Tests.Utilities;
using OrangeHRM.Automation.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation
{
    [SetUpFixture]
    public class SuiteSetUp
    {

        // Initializes the Extent Report once before any tests in the test suite run.
        [OneTimeSetUp]
        public void BeforeAll()
        {
            ReportManager.Initialize();
        }


        // Flushes the report to save the test execution results and releases shared resources
        // after all tests in the test suite have completed.
        [OneTimeTearDown]
        public void AfterAll()
        {
            ReportManager.Flush();

            BaseTest.Driver.Dispose();
            BaseTest.ExTest.Dispose();
        }
    }
}
