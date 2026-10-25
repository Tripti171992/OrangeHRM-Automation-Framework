using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Automation.Tests.Utilities
{
    internal static class ConfigurationReader
    {
        // Stores the application configuration loaded from appsettings.json.
        private static readonly IConfiguration configuration;


        // Loads appsettings.json once when ConfigurationReader is first accessed.
        static ConfigurationReader()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Resources\\")
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();
        }


        // Application environment and application details.
        public static string Env => configuration["Env"];
        public static string Name => configuration["Application:Name"];
        public static string BaseUrl => configuration["Application:BaseUrl"];


        // Browser execution settings.
        public static bool Headless => bool.Parse(configuration["Browser:Headless"]);


        // Credentials used to authenticate with the application.
        public static string Username => configuration["Credentials:Username"];
        public static string Password => configuration["Credentials:Password"];


        // Wait durations, used by the automation framework.
        public static int ExplicitWait => int.Parse(configuration["Timeouts:ExplicitWait"]);
        public static int PageLoadTimeout => int.Parse(configuration["Timeouts:PageLoadTimeout"]);
        public static int ImplicitWait => int.Parse(configuration["Timeouts:ImplicitWait"]);


        // Folders used to save screenshots and reports.
        public static string ScreenshotsFolder => configuration["Screenshots:ScreenshotsFolder"];
        public static string ReportsFolder => configuration["Reports:ReportsFolder"];


        // Report title and report name displayed in Extent Reports.
        public static string ReportTitle => configuration["Reports:ReportTitle"];
        public static string ReportName => configuration["Reports:ReportName"];
    }
}
