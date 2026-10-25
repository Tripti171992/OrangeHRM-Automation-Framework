using OrangeHRM.Automation.Tests.Base;
using OrangeHRM.Automation.Tests.Model;
using OrangeHRM.Automation.Tests.Pages;
using OrangeHRM.Automation.Tests.Utilities;

namespace OrangeHRM.Automation.Tests.Tests
{
    [TestFixture]
    [Parallelizable]
    internal class PIMTest : BaseTest
    {
        [Parallelizable(ParallelScope.Children)]
        [TestCaseSource(nameof(GetEmployeeData))]
        public void AddEmployee(EmployeeModel testdata)
        {
            DashboardPage dashboardPage = LoginAsAdmin();
            EmployeeListPage employeeListPage = dashboardPage.NavigateToPIM();
            AddEmployeePage newEmployee = employeeListPage.ClickAdd();
            newEmployee.AddEmployee(testdata);
            Assert.That(newEmployee.IsSuccessMessageDisplayed(), Is.True, "Success notification should appear after saving employee");
            ReportManager.LogInfo("Employee added.");
        }

        [TestCaseSource(nameof(GetEmployeeWithIdData))]
        public void AddEmployeeWithID(EmployeeModel testdata)
        {
            testdata.EmployeeId = "Emp" + GenerateUniqueEmployeeId();

            DashboardPage dashboardPage = LoginAsAdmin();
            EmployeeListPage employeeListPage = dashboardPage.NavigateToPIM();
            AddEmployeePage newEmployee = employeeListPage.ClickAdd();
            newEmployee.AddEmployee(testdata);
            Assert.That(newEmployee.IsSuccessMessageDisplayed(), Is.True, "Success notification should appear after saving employee");
            ReportManager.LogInfo("Employee with Id added.");
        }

        [Parallelizable(ParallelScope.Children)]
        [TestCaseSource(nameof(GetEmployeeDataToSearchByName))]
        public void SearchEmployeeByName(EmployeeModel testdata)
        {
            string employeeName = $"{testdata.FirstName} {testdata.MiddleName} {testdata.LastName}";

            DashboardPage dashboardPage = LoginAsAdmin();
            EmployeeListPage employeeListPage = dashboardPage.NavigateToPIM();

            AddEmployeePage newEmployee = employeeListPage.ClickAdd();
            newEmployee.AddEmployee(testdata);

            Assert.That(newEmployee.IsSuccessMessageDisplayed(), Is.True, "Success notification should appear after saving employee");

            newEmployee.NavigateToEmployeeList();

            employeeListPage.SearchEmployeeByName(employeeName);
            Assert.That(employeeListPage.GetRecordCount(), Is.GreaterThanOrEqualTo(1), "No record found, employee search by employee name failed.");
            ReportManager.LogInfo("Record with provided name exist, verified!!");
        }

        [TestCaseSource(nameof(GetEmployeeDataToSearchById))]
        public void SearchByEmployeeId(EmployeeModel testdata)

        {
            testdata.EmployeeId = "Emp" + GenerateUniqueEmployeeId();

            DashboardPage dashboardPage = LoginAsAdmin();
            EmployeeListPage employeeListPage = dashboardPage.NavigateToPIM();

            AddEmployeePage newEmployee = employeeListPage.ClickAdd();
            newEmployee.AddEmployee(testdata);
            Assert.That(newEmployee.IsSuccessMessageDisplayed(), Is.True, "Success notification should appear after saving employee");

            newEmployee.NavigateToEmployeeList();

            employeeListPage.SearchByEmployeeId(testdata.EmployeeId);
            Assert.That(employeeListPage.GetRecordCount(), Is.GreaterThanOrEqualTo(1), "No record found, employee search by employee id failed.");
            ReportManager.LogInfo("Record with provided employee id exist, verified!!");
        }

        [TestCaseSource(nameof(GetNonExistentEmployeeData))]
        public void SearchNonExistantEmployee(TestExecutionModel testData)
        {
            string employeeName = "NonExistent" + GenerateUniqueEmployeeId();

            DashboardPage dashboardPage = LoginAsAdmin();
            EmployeeListPage employeeListPage = dashboardPage.NavigateToPIM();
            employeeListPage.SearchEmployeeByName(employeeName);
            Assert.That(employeeListPage.GetRecordCount(), Is.EqualTo(0), "No record should be found on searching by non-existing employee name.");
            Assert.That(employeeListPage.IsNoRecordsFoundDisplayed(), Is.True, "No records found message shoud be displayed.");

            ReportManager.LogInfo("Test passed,no record exists verified.");
        }

        [TestCaseSource(nameof(GetEmployeeDataToCancel))]
        public void CancelAddEmployee(EmployeeModel testdata)
        {
            DashboardPage dashboardPage = LoginAsAdmin();
            EmployeeListPage employeeListPage = dashboardPage.NavigateToPIM();
            AddEmployeePage newEmployee = employeeListPage.ClickAdd();
            newEmployee.CancelAddEmployee(testdata);
            Assert.That(employeeListPage.IsOnEmployeeList(), Is.True, "User should navigate to the employee list page on cancelation.");
            ReportManager.LogInfo("Adding an employee cancelled successfully.");
        }

        private static IEnumerable<TestCaseData> GetEmployeeData()
        {

            return TestDataSource.GetTestData<EmployeeModel>("AddEmployeeData.json");
        }
        private static IEnumerable<TestCaseData> GetEmployeeWithIdData()
        {

            return TestDataSource.GetTestData<EmployeeModel>("AddEmployeeWithIdData.json");

        }
        private static IEnumerable<TestCaseData> GetEmployeeDataToCancel()
        {

            return TestDataSource.GetTestData<EmployeeModel>("CancelAddEmployeeData.json");

        }
        private static IEnumerable<TestCaseData> GetEmployeeDataToSearchByName()
        {

            return TestDataSource.GetTestData<EmployeeModel>("SearchEmployeeData.json");

        }
        private static IEnumerable<TestCaseData> GetEmployeeDataToSearchById()
        {

            return TestDataSource.GetTestData<EmployeeModel>("SearchEmployeeByIdData.json");

        }
        public static IEnumerable<TestCaseData> GetNonExistentEmployeeData()
        {
            return TestDataSource.GetTestData<TestExecutionModel>("SearchNonExistantEmployeeData.json");
        }
        private int GenerateUniqueEmployeeId()
        {
            return Random.Shared.Next(10000, 99999);
        }
    }
}
