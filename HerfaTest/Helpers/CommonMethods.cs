using Bytescout.Spreadsheet;
using HerfaTest.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerfaTest.Helpers
{
    public class CommonMethods
    {
        public static void NavigateToURL(string url)
        {
            // This method utilizes the web driver instance managed by the ManageDriver class 
            // to perform the navigation to the provided URL. 
            // It is critical for automated testing scenarios where accessing specific pages is necessary.
            ManageDriver.driver.Navigate().GoToUrl(url);
        }


        public static IWebElement WaitAndFindElement(By by) // By firstName = By.XPath("//div/input[@id='Fname']");
        {
            // Create a fluent wait that will check for the element's presence in the DOM
            var fluentWait = new DefaultWait<IWebDriver>(ManageDriver.driver)
            {
                // Set the maximum time to wait for the element
                Timeout = TimeSpan.FromSeconds(10),
                // Set the interval between each check for the element
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };

            // Ignore NoSuchElementException to allow for polling without immediate failure
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            // Wait until the element is found using the provided locator
            IWebElement element = fluentWait.Until(x => x.FindElement(by));

            // Return the found element
            return element;
        }



        public static void HighlightElement(IWebElement element)
        {
            // Cast the driver to IJavaScriptExecutor to execute JavaScript
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)ManageDriver.driver;

            // Change the element's background color to light pink for highlighting
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: lightpink !important')", element);

            // Scroll the element into view so it's visible on the screen
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            // Pause execution for a second to allow the highlight to be seen
            Thread.Sleep(1000);

            // Reset the element's background color back to default
            javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: none !important')", element);
        }


        public static Worksheet ReadExcel(string sheetName)
        {
            // Create a new instance of the Spreadsheet class
            Spreadsheet Excel = new Spreadsheet();

            // Load the Excel file from the specified path in GlobalConstants
            Excel.LoadFromFile(GlobalConstants.TestDataPath);

            // Retrieve the worksheet by its name from the loaded workbook
            Worksheet worksheet = Excel.Workbook.Worksheets.ByName(sheetName);

            // Return the retrieved worksheet
            return worksheet;
        }


        public static string TakeScreenShot()
        {
            // Cast the driver to ITakesScreenshot to enable screenshot functionality
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)ManageDriver.driver;

            // Capture the screenshot using the driver
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            // Define the path where the screenshot will be saved
            string path = "C:\\Users\\b.alhassoun.ext\\Documents\\HerfaTestReport\\ScreenShots";

            // Generate a unique image name using a GUID to avoid filename collisions
            string imageName = Guid.NewGuid().ToString() + "_image.png";

            // Combine the path and image name to create the full file path for the screenshot
            string fullPath = Path.Combine(path + $"\\{imageName}"); // E.g., C:\\Users\\b.alhassoun.ext\\Documents\\HerfaTestReport\\xxxxxxxxxxxxxxxxx_image.png

            // Save the screenshot to the specified path
            screenshot.SaveAsFile(fullPath);

            // Return the full path of the saved screenshot
            return fullPath;
        }

    }
}
