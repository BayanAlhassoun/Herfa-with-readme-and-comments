using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter.Configuration;
using Bytescout.Spreadsheet;
using HerfaTest.Data;
using HerfaTest.Helpers;
using HerfaTest.POM;
using MongoDB.Driver.Core.Misc;
using MongoDB.Driver;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Model;
using Bytescout.Spreadsheet.COM;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

namespace HerfaTest.AssistantMethods
{
    public class UserRegister_AssistantMethods
    {
        public static void FillRegisterForm(User user)
        {
            // The method sequentially fills the form fields with the values from the User object.These fields include first name, last name, email, birthdate, phone number, password, and confirm password.

            //Using a User object as a parameter instead of passing individual fields offers significant advantages in terms of code readability, maintainability, and flexibility.It simplifies method signatures, making the code easier to understand and reducing the risk of errors that can arise from passing multiple parameters in the wrong order.Additionally, it promotes better adherence to object-oriented design principles, such as encapsulation and separation of concerns, allowing the User class to manage user data while keeping methods like FillRegisterForm focused on their specific tasks.This approach also enhances code reusability, as the User object can be passed across various parts of the application, and facilitates easier testing by working with a single, structured object. Overall, using a User object results in cleaner, more organized, and scalable code, aligning with best practices and making future enhancements more straightforward.

        // Create a new instance of the UserRegisterPage, passing in the web driver to interact with the registration form.
            UserRegisterPage userRegisterPage = new UserRegisterPage(ManageDriver.driver);

        // Populate the "First Name" field on the registration page with the user's first name.
            userRegisterPage.EnterFirstName(user.firstName);

            // Populate the "Last Name" field on the registration page with the user's last name.
            userRegisterPage.EnterLastName(user.lastName);

            // Populate the "Email" field on the registration page with the user's email.
            userRegisterPage.EnterEmail(user.email);

            // Populate the "Birthdate" field on the registration page with the user's birthdate.
            userRegisterPage.EnterBirthdate(user.Birthdate);

            // Populate the "Phone Number" field on the registration page with the user's phone number.
            userRegisterPage.EnterPhoneNumber(user.phoneNumber);

            // Check the user's gender and click the appropriate radio button on the form.
            if (user.gender == Gender.Male)
            {
                // If the user's gender is Male, click the male radio button.
                userRegisterPage.ClickMaleButton();
            }
            else if (user.gender == Gender.Female)
            {
                // If the user's gender is Female, click the female radio button.
                userRegisterPage.ClickFemaleButton();
            }

// Populate the "Password" field on the registration page with the user's password.
            userRegisterPage.EnterPassword(user.password);

            // Populate the "Confirm Password" field on the registration page with the user's confirmation password.
            userRegisterPage.EnterConfirmPassword(user.confirmPassword);

            // Click the submit button to complete the registration form.
            userRegisterPage.ClickSubmitButton();
        }
//Data-Driven Testing(DDT) is a software testing approach where test input and expected output are stored in external data sources like files(Excel, CSV, XML), databases, or spreadsheets.Instead of hardcoding the test data within test scripts, DDT pulls data from these sources and uses it to run multiple test iterations with different inputs.
//Key Features of DDT:
//Separation of Data and Logic: Test logic is written once, and the data is stored separately, making tests more flexible and maintainable.
//Multiple Test Scenarios: By running the same test case with various data sets, DDT increases test coverage and ensures the application behaves correctly for different inputs.
//Reusability: The same test script can be reused with different sets of data, reducing code duplication.

        public static User ReadRegisterDataFromExcel(int row)
        {
            // Create a new instance of the User object, which will be populated with data from the Excel sheet.
            User user = new User();

            // Read the worksheet named "Register" from the Excel file.
            Worksheet worksheet = CommonMethods.ReadExcel("Register");

            // Read and assign the data from each specific cell in the given row of the worksheet to the corresponding User fields.

            // Convert the value in column 2 (First Name) to a string and assign it to the user's first name.
            user.firstName = Convert.ToString(worksheet.Cell(row, 2).Value);

            // Read the value in column 3 (Last Name) and assign it directly to the user's last name (assumes it's a string).
            user.lastName = (string)worksheet.Cell(row, 3).Value;

    // Read the value in column 4 (Email) and assign it to the user's email.
            user.email = (string)worksheet.Cell(row, 4).Value;

    // Convert the value in column 5 (Phone Number) to a string and assign it to the user's phone number.
            user.phoneNumber = Convert.ToString(worksheet.Cell(row, 5).Value);

    // Parse the value in column 6 (Gender) as an Enum of type Gender and assign it to the user's gender field.
            user.gender = (Gender)Enum.Parse(typeof(Gender), (string)worksheet.Cell(row, 6).Value);

    // Convert the value in column 7 (Birthdate) to a string and assign it to the user's birthdate.
            user.Birthdate = Convert.ToString(worksheet.Cell(row, 7));

    // Convert the value in column 8 (Password) to a string and assign it to the user's password.
            user.password = Convert.ToString(worksheet.Cell(row, 8).Value);

    // Convert the value in column 9 (Confirm Password) to a string and assign it to the user's confirm password field.
            user.confirmPassword = Convert.ToString(worksheet.Cell(row, 9).Value);

    // Return the populated User object.
            return user;
}
public static bool CheckSuccessRegister(string email)
{
    // This variable will hold the result of the database check, indicating whether the email exists in the table or not.
            bool isDataExist = false;

    // SQL query to check if an email exists in the 'login_fp' table.
    // The ":value" is a parameter placeholder for the email.
            string query = "Select count(*) from login_fp where email = :value";

    // Establishing a connection to the Oracle database using the connection string.
            using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
            {
                // Open the connection to the database.
                connection.Open();

                // Create an Oracle command object with the SQL query and the open connection.
                OracleCommand command = new OracleCommand(query, connection);

                // Adding the email parameter to the SQL query.
                command.Parameters.Add(new OracleParameter(":value", email));

                // Execute the query and convert the result to an integer.
                // If the email exists, the result will be greater than 0.
                int result = Convert.ToInt32(command.ExecuteScalar());

                // If the result is greater than 0, it means the email exists in the database.
                isDataExist = result > 0;

                // Return whether the email exists (true) or not (false).
                return isDataExist;

            }
        }

    }
}
