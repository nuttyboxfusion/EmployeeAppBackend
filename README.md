
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

## Generic Repository
The generic repository pattern is used to abstract data access logic, making it reusable and easier to maintain.

1. IRepository.cs: Interface defining common CRUD operations.
2. Repository.cs: Implementation of the generic repository

## API Endpoints
1. GET /api/employees: Get all employees.
2. GET /api/employees/{id}: Get a single employee by ID.
3. POST /api/employees: Create a new employee.
4. PUT /api/employees/{id}: Update an existing employee.
5. DELETE /api/employees/{id}: Delete an employee.
6. GET /api/employees/search?query={query}: Search employees by first name, last name, or email.

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

