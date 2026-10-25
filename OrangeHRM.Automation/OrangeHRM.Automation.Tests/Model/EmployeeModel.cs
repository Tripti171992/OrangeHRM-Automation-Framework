using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Model
{
    internal class EmployeeModel: ITestExecutionModel
    {
        public string Browser { get; set; }
        public string Runmode { get; set; }
        public string TestName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public string EmploymentStatus { get; set; }
        public string SupervisorName { get; set; }
        public string JobTitle { get; set; }
        public string SubUnit { get; set; }
    }
}
