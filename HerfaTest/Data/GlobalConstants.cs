using AventStack.ExtentReports.Gherkin.Model;
using MongoDB.Driver.Core.Misc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
using static System.Net.Mime.MediaTypeNames;

namespace HerfaTest.Data
{
    // The GlobalConstants class is a static class that contains constant values 
    // used throughout the application. These constants ensure that key configuration 
    // details like URLs, file paths, and database connection strings are centralized 
    // and easily accessible, making the code more maintainable and reducing duplication.

    public class GlobalConstants
    {
        // URL for the user registration page.
        public static readonly string registerLink = "https://localhost:44349/Auth/RegisterUser";

        // URL for the login page.
        public static readonly string loginLink = "https://localhost:44349/Auth/Login";

        // Path to the Excel file containing test data. This path can be used to load test data during automated tests.
        public static readonly string TestDataPath = "C:\\Users\\b.alhassoun.ext\\Documents\\HerfaTestData.xlsx";

        // Connection string for the Oracle database used in the project. This includes the database location, user ID, and password for connecting to the database.
        public static readonly string connectionString = "Data Source=localhost:1521/xe;User Id=C##FIRSTPROJECTQA;Password=Bayan12345;";
        //Centralized Constants: The GlobalConstants class serves as a central location to store configuration values that are used across different parts of the application.This makes the code more maintainable since any updates (like URL changes) need to be made in only one place.
        //Readonly Fields: The use of readonly ensures that these values can only be assigned once(at the time of initialization) and cannot be changed during runtime.This ensures that sensitive or important configuration values like URLs and connection strings remain constant throughout the application's lifecycle.
        //Static members for GlobalConstants effectively centralizes important configuration values such as URLs, file paths, and database connection strings, making them easily accessible throughout the application.This design approach enhances memory efficiency by ensuring that these constants are stored in a single location, reducing redundancy.By allowing direct access to these constants without the need for instantiation, the code remains cleaner and more organized.Overall, adopting a static class for global constants is a best practice that promotes clarity, maintainability, and consistency within the application's architecture.
    }

}
