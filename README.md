# OrangeHRM UI Automation Framework

## Overview

This project is a UI test automation framework developed using C#, Selenium WebDriver and NUnit to automate selected workflows in the OrangeHRM demo application.

The framework combines the Page Object Model (POM), Keyword-Driven and Data-Driven testing approaches to promote code reusability, maintainability and structured test execution.

It demonstrates my practical understanding of automation framework design, test data management, reusable browser interactions, synchronisation, and test reporting.

**Application Under Test:** [OrangeHRM Open-Source Demo](https://opensource-demo.orangehrmlive.com/web/index.php/auth/login)

## Technology Stack

- **Programming Language:** C#
- **Framework:** .NET
- **UI Automation:** Selenium WebDriver
- **Test Framework:** NUnit
- **Design Pattern:** Page Object Model (POM)
- **Automation Approach:** Keyword-Driven and Data-Driven Testing
- **Test Data Management:** JSON
- **Locator Management:** XML
- **Reporting:** ExtentReports
- **Test Execution:** NUnit Test Execution and Parallelisation

## Framework Features

### 1. Page Object Model (POM)

- Separates page-specific locators and interactions from test cases.
- Promotes code reuse and maintainability.
- Organises application pages into dedicated page classes.

### 2. Keyword-Driven Approach

- Uses reusable methods for common browser interactions.
- Encapsulates actions such as clicking elements, entering text and interacting with web elements.
- Reduces duplication across page objects and test cases.

### 3. Data-Driven Approach

- Stores test data externally in JSON files.
- Uses strongly typed C# models to represent test data.
- Supports executing test scenarios with multiple sets of input data through NUnit.

### 4. Centralised Locator Management

- Maintains UI element locators in an external XML file.
- Uses reusable locator-reading functionality to retrieve locators.
- Helps separate locator definitions from automation logic.

### 5. Browser and Configuration Management

- Centralises application URL, browser settings and timeout configuration.
- Uses reusable setup and teardown methods to manage browser lifecycle.
- Supports browser-specific execution based on the configured test data.

### 6. Explicit Waits and Synchronisation

- Uses explicit waits to synchronise automation actions with web application behaviour.
- Handles dynamic element visibility and clickability.
- Improves test reliability by reducing dependence on fixed delays.

### 7. Test Reporting and Logging

- Integrates ExtentReports to generate HTML test execution reports.
- Records test outcomes and meaningful execution logs.
- Captures screenshots on test failures where configured.

### 8. Parallel Test Execution

- Uses NUnit parallelisation and thread-specific WebDriver and reporting contexts where configured.
- Aims to support independent test execution while isolating browser sessions and test results.

## Automated Test Scenarios

### Login

- Valid login
- Invalid login
- Forgot password
- Logout

### PIM — Personnel Information Management

- Add employee
- Cancel employee creation
- Search for employees
- Validate behaviour for unsuccessful searches


## Project Structure

```text
OrangeHRM-Automation-Framework/
│
└── OrangeHRM.Automation/                    # Solution
    │
    └── OrangeHRM.Automation.Tests/           # Test Project
        │
        ├── Base/
        │   ├── BaseTest.cs                   # Common setup and teardown for each test
        │   └── SuiteSetUp.cs                 # Suite-level setup and teardown
        │
        ├── Models/
        │   ├── EmployeeModel.cs               # Employee test data model
        │   ├── ITestExecutionModel.cs         # Test execution model interface
        │   ├── LoginModel.cs                  # Login test data model
        │   └── TestExecutionModel.cs          # Common test execution data
        │
        ├── Pages/
        │   ├── AddEmployeePage.cs             # Add employee page actions
        │   ├── AuthenticatedPage.cs           # Common functionality for authenticated pages
        │   ├── BasePage.cs                    # Shared page functionality
        │   ├── DashboardPage.cs                # Dashboard page actions
        │   ├── EmployeeListPage.cs             # Employee list and search actions
        │   ├── LoginPage.cs                    # Login page actions
        │   └── PIMNavigationComponent.cs       # PIM navigation actions
        │
        ├── Tests/
        │   ├── LoginTests.cs                  # Login-related test cases
        │   └── PIMTest.cs                     # PIM-related test cases
        │
        ├── Utilities/
        │   ├── ConfigurationReader.cs         # Reads application configuration
        │   ├── DriverFactory.cs                # Creates WebDriver instances
        │   ├── JSONReader.cs                   # Reads JSON test data
        │   ├── KeywordDriven.cs                # Reusable UI interaction keywords
        │   ├── ReportManager.cs                # ExtentReports management and logging
        │   ├── TestDataSource.cs               # Supplies data-driven NUnit test cases
        │   ├── WaitUtility.cs                  # Reusable explicit wait methods
        │   └── XMLLocatorReader.cs              # Reads element locators from XML
        │
        ├── Resources/
        │   ├── appsettings.json                # Framework configuration
        │   └── locators.xml                    # UI element locators
        │
        ├── TestData/
        │   ├── AddEmployeeData.json
        │   ├── AddEmployeeWithIdData.json
        │   ├── CancelAddEmployeeData.json
        │   ├── ForgotPasswordData.json
        │   ├── InvalidLoginData.json
        │   ├── SearchEmployeeByIdData.json
        │   ├── SearchEmployeeData.json
        │   ├── SearchNonExistantEmployeeData.json
        │   └── ValidLoginData.json
        │
        ├── Reports/                            # Generated test reports (gitignored)
        ├── Screenshots/                        # Captured screenshots (gitignored)
        │
        └── AssemblyInfo.cs                     # Assembly-level configuration
```

## Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or another compatible .NET IDE
- Google Chrome, Mozilla Firefox, or Microsoft Edge installed
- Internet access to the OrangeHRM demo application

## How to Run the Tests

1. Clone or download this repository.
2. Open the solution in Visual Studio.
3. Restore the required NuGet packages.
4. Review the application URL, browser settings, and timeout configurations.
5. Ensure the test data and XML locator files are available.
6. Build the solution.
7. Execute the tests using Visual Studio Test Explorer or the .NET CLI.

Example command:

```bash
dotnet test
```

Run the command from the directory containing the relevant test project or solution.

## Test Reporting

The framework integrates ExtentReports to present test execution results in an HTML report.

Depending on the configuration, the report includes test outcomes, execution logs and screenshots for failed tests.

## Project Scope

This is an independently developed portfolio project created to demonstrate my C# UI automation skills and understanding of reusable test automation framework design.

The project uses the publicly available OrangeHRM demo application and is intended for learning, demonstration and technical discussion.

## Author

QA / Software Test Automation

GitHub: [[Add your GitHub profile URL](https://github.com/Tripti171992/OrangeHRM-Automation-Framework.git)]
