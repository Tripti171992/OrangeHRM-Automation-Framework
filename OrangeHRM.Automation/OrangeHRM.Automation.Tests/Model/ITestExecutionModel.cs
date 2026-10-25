using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Model
{
    internal interface ITestExecutionModel
    {
        string Browser { get; }
        string Runmode { get; }
        string TestName { get; }

    }
}
