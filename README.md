# BuLAKLAK
An inventory system designed for our imaginary flower and alcohol shop. Its purpose is to efficiently manage stock for products catering to various customer needs, whether for celebration or contemplation. This is the final output of four students from the Polytechnic University of the Philippines (PUP) for the course **Application Development**.

## 📥 BuLAKLAK Inventory System Installation Guide (Windows / macOS / Linux)
The BuLAKLAK Inventory System is a .NET application that leverages .NET 8 and can be developed using Visual Studio 2022 (Windows only) or Visual Studio Code (cross-platform). Choose your preferred setup below.

## ⚙️ Prerequisites
Requirement	Windows	macOS	Linux
.NET SDK 8+	✅	✅	✅
SQL Server (Developer Edition) or [Azure SQL]	✅	✅	✅
Visual Studio 2022	✅	❌	❌
Visual Studio Code	✅	✅	✅
EF Core CLI	✅	✅	✅
Git	✅	✅	✅

##  Installation Using Visual Studio 2022 (Windows Only)
1. Install Visual Studio 2022
Download and install Visual Studio 2022.
During installation, ensure you choose the ASP.NET and web development workload.
2. Clone the Project
Open Git Bash or your preferred terminal.
Navigate to the directory where you want to clone the project.
Execute the following commands:
Bash
git clone https://github.com/MvrPgi/ADET_FINAL_PROJECT.git
cd ADET_FINAL_PROJECT
3. Open .sln File
Open the ADET_FINAL_PROJECT.sln solution file in Visual Studio 2022.
4. Configure Database Connection
Open appsettings.json in the project's root or ADET_FINAL_PROJECT folder.
Edit the ConnectionStrings section to point to your SQL Server instance and desired database name (e.g., BuLAKLAKInventoryDB). Ensure SQL Server is running.
JSON
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BuLAKLAKInventoryDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
Note: For an external SQL Server, replace (localdb)\\mssqllocaldb with your server name/IP, and adjust authentication (e.g., User Id=youruser;Password=yourpass;).
5. Run Migrations
BuLAKLAK uses Entity Framework Core Migrations to manage its database schema.
In Visual Studio, open the Package Manager Console (Go to Tools > NuGet Package Manager > Package Manager Console).
Ensure the default project selected in the console is ADET_FINAL_PROJECT.
Execute the following command to apply all pending migrations and create the database schema (including User_Table, Item_Table, Item_Category):
PowerShell
Update-Database
6. Run the Application
Press F5 or click the green "Start Debugging" button in Visual Studio.
The application should build and launch in your default web browser, typically navigating to https://localhost:7xxx (where 7xxx is a dynamically assigned port).
💻 Installation Using Visual Studio Code (Windows / macOS / Linux)
1. Install .NET SDK
Ensure the .NET 8 SDK is installed. You can verify by running:
Bash
dotnet --version
# Should return 8.0.x or above
2. Clone the Repository
Open your terminal or command prompt.
Navigate to your desired project directory.
Clone the BuLAKLAK repository:
Bash
git clone https://github.com/MvrPgi/ADET_FINAL_PROJECT.git
cd ADET_FINAL_PROJECT
3. Install VS Code Extensions (Recommended)
Open the ADET_FINAL_PROJECT folder in Visual Studio Code (code .).
Install the following recommended extensions for a better development experience:
C# (by Microsoft)
Razor (by Microsoft)
SQL Server (optional, for database interaction)
GitLens (optional, for Git history visualization)
4. Configure Database Connection
Open appsettings.Development.json (or appsettings.json) in your project folder.
Edit the ConnectionStrings section to match your database setup.
JSON
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=BuLAKLAKInventoryDB;User Id=youruser;Password=yourpass;MultipleActiveResultSets=true"
}
Note: Adjust localhost, youruser, and yourpass to match your SQL Server instance credentials.
5. Apply Migrations
Open the integrated terminal in VS Code (Ctrl+`` orView > Terminal`).
Navigate to the project root containing the .csproj file (e.g., ADET_FINAL_PROJECT/).
Execute the EF Core migration command to create/update your database schema:
Bash
dotnet ef database update
6. Run the Project
In the terminal, ensure you are in the project root directory.
Run the application:
Bash
dotnet run
The console will display messages, including the URL where the application is hosted (e.g., https://localhost:5001).
7. Navigate to the Application
Open your web browser and go to the URL displayed in the console (e.g., https://localhost:5001).
You should now see the BuLAKLAK Inventory System running.

## Developers
- Alwyn John M. Mercene  
- Jozar Tumabini  
- Aira Robles  
- John Vincent Modelo  

---

© Polytechnic University of the Philippines  
