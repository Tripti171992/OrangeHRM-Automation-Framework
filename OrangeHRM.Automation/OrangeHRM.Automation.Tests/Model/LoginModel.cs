using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Model
{
    internal class LoginModel: ITestExecutionModel
    {
        public string Browser { get; set; }
        public string Runmode { get; set; }
        public string TestName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
