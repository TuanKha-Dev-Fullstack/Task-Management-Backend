# Task-Management-Backend
Note: 
* Installed docker
* Installed .NET 8
## Instructions for running the application
### 1: Clone: https://github.com/TuanKha-Dev-Fullstack/Task-Management-Backend.git
### 2: Install nuget packages:
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Npgsql.EntityFrameworkCore.PostgreSQL
### 3: Setup postgresql and app
* 1: Open terminal and run command:
`docker-compose up -- build`
* 2: Open appsettings.json, replace this:
`"DefaultConnection": "Server=localhost;Port=5432;Database=task_management;User Id=root;Password=root123;"`
* 3: Open terminal and run this command:
`dotnet ef database update`
* 4: Open appsettings.json, replace this:
`"DefaultConnection": "Server=db;Port=5432;Database=task_management;User Id=root;Password=root123;"`
### 4: Deployment
Open terminal and run command: 
`docker-compose up --build`
### 5: Using app
Open url: http://localhost:5000/swagger/index.html
