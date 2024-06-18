
### Back-End README

# Employee Management System - Back End

This is the back-end API for the Employee Management System, built with ASP.NET Core and Entity Framework Core.

## Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/your-repository.git
   cd your-repository/backend

## Connect Database
1. update connectionstring on appsettings to your local machine
2 apply migrations, run command on package manager console
   ```bash
   update-database

## Entity Framework
Entity Framework Core is used for database operations.

1. EmployeeContext.cs: Database context for managing entity configurations and relationships.


## Folder Structure
   ```bash
   backend/
├── Controllers/
│   └── EmployeesController.cs
├── Data/
│   ├── EmployeeContext.cs
│   └── Repository/
│       ├── GenericRepository.cs
│       └── IGenericRepository.cs
├── Models/
│   ├── Employee.cs
│   └── Skill.cs
├── Services/
│   └── EmployeeService.cs
├── Program.cs
├── Startup.cs
├── appsettings.json
└── EmployeeManagement.csproj

