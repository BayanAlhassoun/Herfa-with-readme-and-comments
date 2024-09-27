using HerfaTest.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.POM
{
    public class UserRegisterPage
    {
        private IWebDriver _driver; // Instance variable to hold the WebDriver for browser interactions

        // Constructor to initialize the UserRegisterPage with the provided WebDriver
        public UserRegisterPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Define locators for each element on the registration page using XPath
        By firstName = By.XPath("//div/input[@id='Fname']");
        By lastName = By.XPath("//div/input[@id='Lname']");
        By male = By.XPath("//div/input[@value='M']");
        By female = By.XPath("//div/input[@value='F']");
        By birthdate = By.XPath("//div/input[@id='Dateofbirth']");
        By phonenumber = By.XPath("//div/input[@name='Phonenumber']");
        By email = By.XPath("//div/input[@name='Email']");
        By image = By.XPath("//div/input[@name='ImageFileUser']");
        By password = By.XPath("//div/input[@id='myPass']");
        By confirmPassword = By.XPath("//div/input[@id='myPass2']");
        By submitButton = By.XPath("//div/button[@type='submit']");
        By loginLink = By.XPath("//p/a[@href='/Auth/Login']");

        // Method to enter the user's first name
        public void EnterFirstName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(firstName); // Wait for the element and find it
            CommonMethods.HighlightElement(element); // Highlight the element for better visibility
            element.SendKeys(value); // Input the value into the first name field
        }

        // Method to enter the user's last name
        public void EnterLastName(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(lastName); // Wait for the element and find it
            CommonMethods.HighlightElement(element); // Highlight the element for better visibility
            element.SendKeys(value); // Input the value into the last name field
        }

        // Method to click the male gender radio button
        public void ClickMaleButton()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(male); // Wait for the element and find it
            CommonMethods.HighlightElement(element); // Highlight the element for better visibility
            element.Click(); // Click the male button
        }

        // Method to click the female gender radio button
        public void ClickFemaleButton()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(female); // Wait for the element and find it
            CommonMethods.HighlightElement(element); // Highlight the element for better visibility
            element.Click(); // Click the female button
        }

        // Method to enter the user's birthdate
        public void EnterBirthdate(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(birthdate); // Wait for the element and find it
            CommonMethods.HighlightElement(element); // Highlight the element for better visibility
            element.SendKeys(value); // Input the value into the birthdate field
        }

        // Method to enter the user's phone number
        public void EnterPhoneNumber(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(phonenumber); // Wait for the element and find it
            CommonMethods.HighlightElement(element); // Highlight the element for better visibility
            element.SendKeys(value); // Input the value into the phone number field
        }

        // Method to enter the user's email address
        public void EnterEmail(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(email); // Wait for the element and find it
            CommonMethods.HighlightElement(element); // Highlight the element for better visibility
            element.SendKeys(value); // Input the value into the email field
        }

        // Method to upload the user's image
        public void EnterImage(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(image); // Wait for the element and find it
            CommonMethods.HighlightElement(element); // Highlight the element for better visibility
            element.SendKeys(value); // Input the file path for the image upload
        }

        // Method to enter the user's password
        public void EnterPassword(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(password); // Wait for the element and find it
            CommonMethods.HighlightElement(element); // Highlight the element for better visibility
            element.SendKeys(value); // Input the value into the password field
        }

        // Method to enter the user's password confirmation
        public void EnterConfirmPassword(string value)
        {
            IWebElement element = CommonMethods.WaitAndFindElement(confirmPassword); // Wait for the element and find it
            CommonMethods.HighlightElement(element); // Highlight the element for better visibility
            element.SendKeys(value); // Input the value into the confirm password field
        }

        // Method to click the submit button for the registration form
        public void ClickSubmitButton()
        {
            CommonMethods.WaitAndFindElement(submitButton).Click(); // Wait for the submit button and click it
        }

        // Method to click the login link to navigate to the login page
        public void ClickLoginLink()
        {
            IWebElement element = CommonMethods.WaitAndFindElement(loginLink); // Wait for the element and find it
            CommonMethods.HighlightElement(element); // Highlight the element for better visibility
            element.Click(); // Click the login link
        }
    }
}
