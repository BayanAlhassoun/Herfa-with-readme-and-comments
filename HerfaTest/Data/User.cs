using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.Data
{
    // The User class represents a user in the application, encapsulating all relevant 
    // information about the user, such as personal details, contact information, and 
    // authentication credentials. This class is used to manage user data consistently 
    // throughout the application.

    public class User
    {
        // Default constructor for the User class. It allows for the creation of a User object 
        // without initializing any properties. 
        public User() { }

        // Parameterized constructor for the User class. It allows for the creation of a User 
        // object with specific values for all its properties, facilitating object initialization 
        // during user registration or data loading.
        public User(string firstName, string lastName, string email, string phoneNumber,
                    string password, string confirmPassword, Gender gender,
                    string birthdate, string image = null)
        {
            // Assigning parameter values to the corresponding properties of the User class.
            this.firstName = firstName;               // User's first name.
            this.lastName = lastName;                 // User's last name.
            this.email = email;                       // User's email address.
            this.phoneNumber = phoneNumber;           // User's phone number.
            this.image = image;                       // Optional user image (profile picture).
            this.password = password;                 // User's password for authentication.
            this.confirmPassword = confirmPassword;   // Confirmation of the user's password.
            this.gender = gender;                     // User's gender (Male or Female).
            Birthdate = birthdate;                   // User's date of birth.
        }

        // Properties of the User class.
        public string firstName { get; set; }        // Gets or sets the user's first name.
        public string lastName { get; set; }         // Gets or sets the user's last name.
        public string email { get; set; }            // Gets or sets the user's email address.
        public string phoneNumber { get; set; }      // Gets or sets the user's phone number.
        public string image { get; set; }            // Gets or sets the user's profile image (optional).
        public string password { get; set; }         // Gets or sets the user's password.
        public string confirmPassword { get; set; }  // Gets or sets the user's password confirmation.
        public Gender gender { get; set; }           // Gets or sets the user's gender (represented by the Gender enum).
        public string Birthdate { get; set; }        // Gets or sets the user's date of birth.
    }

}
