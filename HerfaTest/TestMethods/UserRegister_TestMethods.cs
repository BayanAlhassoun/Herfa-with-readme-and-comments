using HerfaTest.Helpers;
using HerfaTest.POM;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerfaTest.Data;
using HerfaTest.AssistantMethods;
using Bytescout.Spreadsheet;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;

namespace HerfaTest.TestMethods
{
    [TestClass] //Any class that contains test methods must be decorated with this attribute.
    public class UserRegister_TestMethods
    {
        // Create an instance of ExtentReports to generate the test report
        public static ExtentReports extentReports = new ExtentReports();

        // Create an instance of ExtentHtmlReporter to specify the location for the HTML report
        public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("C:\\Users\\b.alhassoun.ext\\Documents\\HerfaTestReport\\");

        // This method is called once before any test methods in the class run.
        // It attaches the HTML reporter to the ExtentReports instance and maximizes the browser window.
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            // Attach the HTML reporter to the extent reports
            extentReports.AttachReporter(reporter);

            // Maximize the browser window for all tests in this class
            ManageDriver.MaximizeDriver();
        }

        // This method is called once after all test methods in the class have finished.
        // It flushes the reports to the specified file and closes the browser driver.
        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Write all test results to the report file
            extentReports.Flush();

            // Close the browser driver to free up resources
            ManageDriver.CloseDriver();
        }


        [TestMethod] //Each method with TestMethod attribute is treated as a separate test case that will be executed by the test framework.
        public void TestSuccessRegister()
        {
            // Create a test entry in the report for tracking test results
            var test = extentReports.CreateTest("TestSuccessRegister", "verify that on passing valid data to register form, the data added correctly");
            //CreateTest: This method is used to start a new test and add it to the report. It returns an object (usually of type ExtentTest), which is stored in the test variable.
            //CreateTest: This method allows you to log steps, statuses(pass / fail), and additional details like screenshots for the specific test.
            try
            {
                // Navigate to the registration URL
                CommonMethods.NavigateToURL("https://localhost:44349/Auth/RegisterUser");

                // Read user registration data from the Excel sheet (row 2)
                User user1 = UserRegister_AssistantMethods.ReadRegisterDataFromExcel(2);

                // Fill the registration form with the retrieved user data
                UserRegister_AssistantMethods.FillRegisterForm(user1);

                // Pause for 2 seconds to allow the form to process (consider using explicit waits instead)
                Thread.Sleep(2000);

                // Check if the registration was successful by verifying if the email exists in the database
                Assert.IsTrue(UserRegister_AssistantMethods.CheckSuccessRegister(user1.email));

                // Define the expected URL after successful registration
                var expectedURL = "https://localhost:44349/Auth/Login";

                // Get the actual URL of the current page
                var actualURL = ManageDriver.driver.Url;

                // Assert that the actual URL matches the expected URL
                Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC3");

                // Log success message in the console
                Console.WriteLine("TC3 Completed Successfully");

                // Mark the test as passed in the report
                test.Pass("Registered Successfully");
            }
            catch (Exception ex)
            {
                // If any exception occurs, mark the test as failed in the report
                test.Fail(ex.Message);

                // Take a screenshot of the failure
                string screenShotPath = CommonMethods.TakeScreenShot();

                // Add the screenshot to the test report for reference
                test.AddScreenCaptureFromPath(screenShotPath);
            }
        }



        [TestMethod]
        public void TestFailedRegister_invalidEmail()
        {
            // Create a test entry in the report for tracking this specific test
            var test = extentReports.CreateTest("TestFailedRegister_invalidEmail", "TestFailedRegister_invalidEmail");

            // Loop through specific rows in the Excel sheet (3 to 5) to test invalid email scenarios
            for (int i = 3; i <= 5; i++)
            {
                try
                {
                    // Navigate to the registration URL
                    CommonMethods.NavigateToURL("https://localhost:44349/Auth/RegisterUser");
                    test.Log(Status.Info, "Navigate to register page done successfully");

                    // Read user registration data from the Excel sheet for the current iteration
                    User user1 = UserRegister_AssistantMethods.ReadRegisterDataFromExcel(i);

                    // Fill the registration form with the retrieved user data
                    UserRegister_AssistantMethods.FillRegisterForm(user1);

                    // Pause for 2 seconds to allow the form to process (consider using explicit waits instead)
                    Thread.Sleep(2000);

                    // Define the expected URL after attempting to register with invalid email
                    var expectedURL = "https://localhost:44349/Auth/RegisterUser";

                    // Get the actual URL of the current page
                    var actualURL = ManageDriver.driver.Url;

                    // Assert that the actual URL matches the expected URL, indicating the registration failed
                    Assert.AreEqual(expectedURL, actualURL, "Actual URL not equal the expected URL_TC2");

                    // Log success message in the console for this test case
                    Console.WriteLine("TC2 Completed Successfully");

                    // Mark the test as passed in the report
                    test.Pass($"TC{i} Passed");
                }
                catch (Exception ex)
                {
                    // If any exception occurs, mark the test as failed in the report
                    test.Fail(ex.Message);

                    // Take a screenshot of the failure
                    string screenShotPath = CommonMethods.TakeScreenShot();

                    // Add the screenshot to the test report for reference
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
            }
        }



        [TestMethod]
        public void TestFaildRegister_InvalidBirthdate()
        {
            // Read the "Register" sheet from the Excel file to access test data
            Worksheet worksheet = CommonMethods.ReadExcel("Register");

            // Create a test entry in the report for tracking this specific test
            var test = extentReports.CreateTest("TestFaildRegister_InvalidBirthdate", "TestFaildRegister_InvalidBirthdate");

            // Loop through specific rows in the Excel sheet (6 to 8) to test invalid birthdate scenarios
            for (int i = 6; i <= 8; i++)
            {
                try
                {
                    // Navigate to the registration URL
                    CommonMethods.NavigateToURL("https://localhost:44349/Auth/RegisterUser");

                    // Read user registration data from the Excel sheet for the current iteration
                    User user1 = UserRegister_AssistantMethods.ReadRegisterDataFromExcel(i);

                    // Fill the registration form with the retrieved user data
                    UserRegister_AssistantMethods.FillRegisterForm(user1);

                    // Pause for 2 seconds to allow the form to process (consider using explicit waits instead)
                    Thread.Sleep(2000);

                    // Evaluate test scenarios based on the current iteration (i)
                    switch (i)
                    {
                        case 6:
                            // Expected URL after registration attempt
                            var expectedResult1 = "https://localhost:44349/Auth/RegisterUser";
                            var actualResult1 = ManageDriver.driver.Url;

                            // Assert that the actual URL matches the expected URL
                            Assert.AreEqual(expectedResult1, actualResult1, "The actual result not equal the expected_TC3");
                            test.Log(Status.Info, "First Assert Passed");

                            // Expected validation message from the Excel sheet
                            var expectedValidation = (string)worksheet.Cell(i, 11).Value;
                            // Actual validation message displayed on the page
                            var actualValidation = ManageDriver.driver.FindElement(By.XPath("//Ul/li[.='Age under the legal age']")).Text;

                            // Assert that the actual validation message matches the expected message
                            Assert.AreEqual(expectedValidation, actualValidation);

                            // Mark the test as passed in the report
                            test.Pass($"TC{i} Passed");
                            Console.WriteLine($"TC{i} completed successfully");
                            break;

                        case 7:
                            // Expected validation message for the second test case
                            var expectedValidation2 = "Age under the legal age";
                            // Actual validation message displayed on the page
                            var actualValidation2 = ManageDriver.driver.FindElement(By.XPath("//Ul/li[.='Age under the legal age']")).Text;

                            // Assert that the actual validation message matches the expected message
                            Assert.AreEqual(expectedValidation2, actualValidation2);

                            // Mark the test as passed in the report
                            test.Pass($"TC{i} Passed");
                            Console.WriteLine($"TC{i} completed successfully");
                            break;

                        case 8:
                            // Expected URL after registration attempt
                            var expectedResult = "https://localhost:44349/Auth/RegisterUser";
                            var actualResult = ManageDriver.driver.Url;

                            // Assert that the actual URL matches the expected URL
                            Assert.AreEqual(expectedResult, actualResult, "The actual result not equal the expected_TC3");

                            // Mark the test as passed in the report
                            test.Pass($"TC{i} Passed");
                            Console.WriteLine($"TC{i} completed successfully");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // If any exception occurs, mark the test as failed in the report
                    test.Fail(ex.Message);

                    // Take a screenshot of the failure
                    string screenShotPath = CommonMethods.TakeScreenShot();

                    // Add the screenshot to the test report for reference
                    test.AddScreenCaptureFromPath(screenShotPath);
                }
            }
        }




    }
}
