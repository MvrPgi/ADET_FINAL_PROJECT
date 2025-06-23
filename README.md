# BuLAKLAK
An inventory system designed for our imaginary flower and alcohol shop. Its purpose is to efficiently manage stock for products catering to various customer needs, whether for celebration or contemplation. This system is the final output of four students from the Polytechnic University of the Philippines (PUP) for the course **Application Development**.

# BuLAKLAK Inventory System Installation Guide (Windows / macOS / Linux)

The BuLAKLAK Inventory System is a .NET application that leverages .NET 8 and can be developed using Visual Studio 2022 (Windows only) or Visual Studio Code (cross-platform). Choose your preferred setup below.

## Prerequisites

| Requirement       | Windows | macOS | Linux |
| :---------------- | :------ | :---- | :---- |
| .NET SDK 8+       | ✅      | ✅    | ✅    |
| SQL Server (Developer Edition) or [Azure SQL] | ✅      | ✅    | ✅    |
| Visual Studio 2022 | ✅      | ❌    | ❌    |
| Visual Studio Code | ✅      | ✅    | ✅    |
| EF Core CLI       | ✅      | ✅    | ✅    |
| Git               | ✅      | ✅    | ✅    |

## Installation Using Visual Studio 2022 (Windows Only)

### 1. Install Visual Studio 2022
* Download and install Visual Studio 2022.
* During installation, ensure you choose the **`ASP.NET and web development`** workload.

### 2. Clone the Project
* Open Git Bash or your preferred terminal.
* Navigate to the directory where you want to clone the project.
* Execute the following commands:
    ```bash
    git clone [https://github.com/MvrPgi/ADET_FINAL_PROJECT.git](https://github.com/MvrPgi/ADET_FINAL_PROJECT.git)
    cd ADET_FINAL_PROJECT
    ```

### 3. Open .sln File
* Open the `ADET_FINAL_PROJECT.sln` solution file in Visual Studio 2022.

### 4. Configure Database Connection
* Open `appsettings.json` in the project's root or `ADET_FINAL_PROJECT` folder.
* Edit the `ConnectionStrings` section to point to your SQL Server instance and desired database name (e.g., `BuLAKLAKInventoryDB`). Ensure SQL Server is running.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BuLAKLAKInventoryDB;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    ```
    * **Note:** For an external SQL Server, replace `(localdb)\\mssqllocaldb` with your server name/IP, and adjust authentication (e.g., `User Id=youruser;Password=yourpass;`).

### 5. Run Migrations
* BuLAKLAK uses Entity Framework Core Migrations to manage its database schema.
* In Visual Studio, open the **Package Manager Console** (Go to `Tools` > `NuGet Package Manager` > `Package Manager Console`).
* Ensure the default project selected in the console is `ADET_FINAL_PROJECT`.
* Execute the following command to apply all pending migrations and create the database schema (including `User_Table`, `Item_Table`, `Item_Category`):
    ```powershell
    Update-Database
    ```

### 6. Run the Application
* Press `F5` or click the green "Start Debugging" button in Visual Studio.
* The application should build and launch in your default web browser, typically navigating to `https://localhost:7xxx` (where `7xxx` is a dynamically assigned port).

## Installation Using Visual Studio Code (Windows / macOS / Linux)

### 1. Install .NET SDK
* Ensure the .NET 8 SDK is installed. You can verify by running:
    ```bash
    dotnet --version
    # Should return 8.0.x or above
    ```

### 2. Clone the Repository
* Open your terminal or command prompt.
* Navigate to your desired project directory.
* Clone the BuLAKLAK repository:
    ```bash
    git clone [https://github.com/MvrPgi/ADET_FINAL_PROJECT.git](https://github.com/MvrPgi/ADET_FINAL_PROJECT.git)
    cd ADET_FINAL_PROJECT
    ```

### 3. Install VS Code Extensions (Recommended)
* Open the `ADET_FINAL_PROJECT` folder in Visual Studio Code (`code .`).
* Install the following recommended extensions for a better development experience:
    * C# (by Microsoft)
    * Razor (by Microsoft)
    * SQL Server (optional, for database interaction)
    * GitLens (optional, for Git history visualization)

### 4. Configure Database Connection
* Open `appsettings.Development.json` (or `appsettings.json`) in your project folder.
* Edit the `ConnectionStrings` section to match your database setup.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=BuLAKLAKInventoryDB;User Id=youruser;Password=yourpass;MultipleActiveResultSets=true"
    }
    ```
    * **Note:** Adjust `localhost`, `youruser`, and `yourpass` to match your SQL Server instance credentials.

### 5. Apply Migrations
* Open the integrated terminal in VS Code (`Ctrl+`` or `View > Terminal`).
* Navigate to the project root containing the `.csproj` file (e.g., `ADET_FINAL_PROJECT/`).
* Execute the EF Core migration command to create/update your database schema:
    ```bash
    dotnet ef database update
    ```

### 6. Run the Project
* In the terminal, ensure you are in the project root directory.
* Run the application:
    ```bash
    dotnet run
    ```
* The console will display messages, including the URL where the application is hosted (e.g., `https://localhost:5001`).

### 7. Navigate to the Application
* Open your web browser and go to the URL displayed in the console (e.g., `https://localhost:5001`).
* You should now see the BuLAKLAK Inventory System running.

# BuLAKLAK Inventory System User Guide

## 1. Introduction to BuLAKLAK
BuLAKLAK is an intuitive Inventory Management System designed to help users efficiently track and manage various items. This guide will walk you through the key features and functionalities of the application.

## 2. Getting Started
Before accessing the main inventory dashboard, users typically interact with authentication pages.

### 2.1. Registration (If applicable)
If you are a new user and do not have an account, you will need to register. The database schema includes a `User_Table` with `username` and `password` fields to support user accounts.
1.  Navigate to the registration page (URL to be provided by administrator).
2.  Fill in the required details, such as your desired `username` and `password`.
3.  Submit the form to create your account.

### 2.2. Login
To access the BuLAKLAK Inventory System:
1.  Navigate to the application's login page (URL to be provided by administrator).
2.  Enter your registered `username` and `password`.
3.  Click the "Login" button to proceed to the main dashboard.

## 3. Dashboard Overview
Upon successful login, you will be directed to the main BuLAKLAK dashboard. This interface is designed for easy navigation and quick access to inventory information.

### 3.1. Header
The top section of the dashboard features the "Inventory System" title on the left and a "User" profile indicator with a user icon on the right, signifying the currently logged-in user. The header on the edit inventory page also features a distinctive blue border at the top.

### 3.2. Sidebar Navigation
The left-hand sidebar provides quick access to different sections of the application:
* **Logo**: Display system's branding.
* **Inventory**: Displays a comprehensive list of all items in your inventory.
* **Add Item**: Navigates to a form for adding new items to the inventory.
* **Edit Inventory**: Allows you to modify details of existing inventory items.
* **Delete Item**: Provides functionality to remove items from the inventory.

### 3.3. Main Content Panel
The large central area of the dashboard displays the primary content based on your sidebar selection.

## 4. Key Features and How to Use Them

### 4.1. Viewing Inventory
The main "Inventory" page provides an overview of all items in your system.
1.  Click on the "Inventory" link in the sidebar.
2.  The main panel will display a table with key details for each item, including: `Item ID`, `Name`, `Category`, `Description`, `Quantity`, and `Status` (e.g., High, Medium, Low). These details are stored in the `Item_Table` of the database.
3.  You can review item quantities and their corresponding status at a glance.

### 4.2. Adding a New Item (Create Item)
To add a new item to your inventory:
1.  Click on the "Add Item" link in the sidebar.
2.  You will be presented with a form. Fill in the required item details such as `Name`, `Category`, `Description`, and `Quantity`. The `Category` should align with the `Item_Category` table's predefined values.
3.  Submit the form to add the new item.

### 4.3. Editing an Existing Item (Edit Inventory / Update Item)
To modify details of an item:
1.  Click on the "Edit Inventory" link in the sidebar. This will lead to a page with an "EDIT INVENTORY" heading.
2.  The main panel will display the item list, likely in an editable format.
3.  Make the necessary changes to the item's `Name`, `Category`, `Description`, or `Quantity`.
4.  Once all edits are complete, click the green "Confirm" button to save your changes.
5.  If you wish to discard changes, click the red "Cancel" button.

### 4.4. Deleting an Item
To remove an item from your inventory:
1.  Click on the "Delete Item" link in the sidebar.
2.  (Depending on implementation) You might be presented with a list of items where you can select one or more for deletion, or a dedicated form to specify the item to delete.
3.  Follow the on-screen prompts to confirm the deletion. Be cautious, as this action is usually irreversible.

# Screenshots
BuLAKLAK Application

<table>
    <tr>
        <td>
            <img src="https://github.com/user-attachments/assets/5559066e-6283-4614-a4cf-1b76ffd08909" alt="Add Item" />
            <br />
            <p align="center">Add Item</p>
        </td>
        <td>
            <img src="https://github.com/user-attachments/assets/5559066e-6283-4614-a4cf-1b76ffd08909" alt="Add New Item" />
            <br />
            <p align="center">Add New Item</p>
        </td>
    </tr>
    <tr>
        <td>
            <img src="https://github.com/user-attachments/assets/ed9320ab-45d7-4476-8219-6aaab479f110" alt="Edit Inventory" />
            <br />
            <p align="center">Edit Inventory</p>
        </td>
        <td>
            <img src="resources/UI/Login.png" alt="Login" />
            <br />
            <p align="center">Login</p>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <img src="resources/UI/Register.png" alt="Register" />
            <br />
            <p align="center">Register</p>
        </td>
    </tr>
</table>


## Developers
* Alwyn John M. Mercene  
* Jozar Tumabini  
* Aira Robles  
* John Vincent Modelo


---

© Polytechnic University of the Philippines  
