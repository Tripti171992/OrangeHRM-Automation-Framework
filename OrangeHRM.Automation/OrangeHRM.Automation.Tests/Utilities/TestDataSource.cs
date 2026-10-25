using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Utilities
{
    public static class TestDataSource
    {
        // Reads test data from a JSON file and provides each record as a separate NUnit test case.
        public static IEnumerable<TestCaseData> GetTestData<T>(string fileName)
        {
            // Builds the full path to the JSON file inside the TestData folder.
            string filePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "TestData", fileName);

            // Reads and deserializes the JSON records into a list of the specified model type.
            List<T> data = JSONReader.GetData<T>(filePath);

            // Yields each data record as an individual NUnit test case.
            foreach (T item in data)
            {
                yield return new TestCaseData(item);
            }
        }
    }
}
