2.1  The database is designed to store task-related information in a single normalized table.
2.1.1 ER Diagram
+---------------------+
|       TASKS         |
+---------------------+
| Id (PK)             |
| TaskTitle           |
| TaskDescription     |
| TaskDueDate         |
| TaskStatus          |
| TaskRemarks         |
| CreatedOn           |
| LastUpdatedOn       |
| CreatedBy           |
| LastUpdatedBy       |
+---------------------+

Primary Key: Id
One task represents one row
No redundancy
Supports CRUD & search efficiently

2.1.2 Data Dictionary

| Column Name     | Data Type | Description                           |
| --------------- | --------- | ------------------------------------- |
| Id              | int       | Primary key, auto-increment           |
| TaskTitle       | varchar   | Title of the task                     |
| TaskDescription | text      | Detailed description                  |
| TaskDueDate     | date      | Due date of task                      |
| TaskStatus      | varchar   | Status (Pending/InProgress/Completed) |
| TaskRemarks     | text      | Additional remarks                    |
| CreatedOn       | timestamp | Task creation time                    |
| LastUpdatedOn   | timestamp | Last update time                      |
| CreatedBy       | varchar   | Creator name                          |
| LastUpdatedBy   | varchar   | Last updater name                     |


2.1.4  Code First Approach is used
Reason:
New application (no existing database)
Faster development
Strong version control using migrations
Easy schema evolution
Ideal for Agile development


Architecture Pattern
 MVC (Model–View–Controller

3.1  Standard MVC Server-Side Rendering is used
Why MVC?
Simple UI requirements
Faster initial load
SEO friendly
Easy debugging
Suitable for CRUD-based applications

4.2 Web-based application
Accessible via browser
Desktop & mobile responsive
Can be extended to mobile apps via API later

5.1 Environment Details & Dependencies
Software Requirements:
.NET SDK 8.0+
PostgreSQL 16+
Visual Studio 2022 

NuGet Packages Used:
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design
Npgsql.EntityFrameworkCore.PostgreSQL

5.2 Instructions to Build / Compile Project
Step 1: Clone Repository
  git clone <https://github.com/adarshk-6310/TaskManager>
  cd TaskManagerMVC
Step 2: Restore Packages
  dotnet restore

Step 3: Configure Database
Update appsettings.json:

Host=localhost;
Port=5432;
Database=taskdb;
Username=postgres;
Password=postgres


Step 4: Run Migration
Using Visual Studio Package Manager Console:

Add-Migration InitialCreate
Update-Database


5.3 Run the Application
dotnet run
