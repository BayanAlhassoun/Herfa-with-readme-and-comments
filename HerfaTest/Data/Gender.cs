using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Model;
using MongoDB.Driver.Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HerfaTest.Data
{
    // The Gender enum represents a set of predefined constant values for gender.
    // It can be used to specify or categorize a user's gender in the application.

    public enum Gender
    {
        // Represents a male gender option.
        Male,

        // Represents a female gender option.
        Female
    }
//Enums: Enums are used to define a set of named constants, making the code more readable and reducing the chance of errors when dealing with predefined options.
//Usage: In this case, the Gender enum is used to represent two possible values: Male and Female.These can be used, for example, when capturing user input or storing user details in a more structured way.It ensures that only valid values for gender are used throughout the code.

}
