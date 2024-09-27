Data Folder
Purpose:
The Data folder is responsible for managing and organizing all data-related components used throughout the project. This includes models, constants, and any static or dynamic data needed for testing or application logic. The primary goal of this folder is to centralize data management and ensure a clean separation between the data layer and other components of the project.

Example: User model that contains fields like FirstName, LastName, Email, etc.
Example: GlobalConstants.cs may include constant values such as URLs, connection strings, and test configuration settings.

Why Use This Structure:
Modularity: This folder improves the modularity of the code by grouping all data-related components in one place, making it easy to update and maintain data across different parts of the application.
Separation of Concerns: Separating data from the business logic ensures that each component of the project focuses on a single responsibility, which aligns with best practices in clean coding and software architecture.
Reusability: The models and constants stored in this folder can be reused across various parts of the project, ensuring consistency and avoiding duplication of data.
Easy Maintenance: Centralized management of constants and models makes the project easier to scale and modify, allowing for easy updates in the future.'