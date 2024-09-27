Page Object Model (POM) Folder
The POM folder contains the implementation of the Page Object Model (POM) design pattern used in this project. This pattern helps to organize the code in a more maintainable and scalable way by separating the representation of the web pages from the test logic.

Examples:
-LoginPage.cs
This class represents the login page of the application. It encapsulates all the interactions that can be performed on the login page, such as entering user credentials and clicking the login button.

-UserRegisterPage.cs
This class represents the user registration process, providing methods to enter user details such as first name, last name, email, and password. It ensures that all necessary interactions required for user registration are defined.

Benefits of Using POM
Modularity: Each page class is responsible for its own interactions, making it easier to manage and update.
Reusability: Common methods across different test cases can be reused, reducing code duplication.
Readability: Tests are cleaner and more readable, as the logic for interacting with the UI is abstracted away in the page classes.
Maintenance: Changes to the UI require minimal changes in the test code, as the tests only need to interact with the page objects.

Usage
To use the page objects, instantiate the corresponding class in your test and call the methods defined in these classes to interact with the UI. 