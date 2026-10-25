using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Utilities
{
    internal static class JSONReader
    {
        // Reads test data from a JSON file and converts it into a list of the specified model type.
        public static List<T> GetData<T>(string path)
        {
            using StreamReader reader = new StreamReader(path);
            var json = reader.ReadToEnd();
            List<T> objectList = JsonConvert.DeserializeObject<List<T>>(json);
            return objectList;
        }
    }
}

