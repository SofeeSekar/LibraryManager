# Library Management System

A simple ASP.NET Core Web API for managing a library with books, authors, borrowers, and borrow records. It includes JWT authentication and authorization and uses in-memory data with data seeding.

## Features
- **Books**: Add, update, delete, and fetch book details.
- **Authors**: Manage author information.
- **Borrowers**: Track library users.
- **Borrow Records**: Handle book borrowing transactions.
- **JWT Authentication**: Secure API endpoints.

## Project Architecture

The project follows a **Clean Architecture** approach with **three main layers**:#### **1. Controllers (Presentation Layer)**
Located in the `Controllers/` folder, these handle HTTP requests and responses.
- `BookController.cs`  
- `AuthorController.cs`  
- `BorrowerController.cs`  
- `AuthController.cs` (Handles authentication)

### **2. Services (Business Logic Layer)**
Located in the `Services/` folder, these contain the core logic of the application.
- `BookService.cs`
- `AuthorService.cs`
- `BorrowerService.cs`
- `AuthService.cs`

### **3. Interfaces (Abstraction Layer)**
Located in the `Interfaces/` folder, these define contracts for services.
- `IBookService.cs`
- `IAuthorService.cs`
- `IBorrowerService.cs`
- `IAuthService.cs`

### **4. Data Layer (In-Memory Database)**
Located in the `Data/` folder, it provides initial seeding and manages data persistence.
- `LibraryContext.cs` (Handles in-memory storage)
- `LibraryDataSeeder.cs` (Populates sample data)

### **5. Middleware**
Contains JWT authentication setup.

## **6. Setup and Running the Solution**  

### **Step 1: Open the Application**
- Ensure **.NET 8** is installed.  
- Open the project in **Visual Studio**.  

### **Step 2: Install Necessary Packages**  
Use the **Package Manager Console** (`Tools > NuGet Package Manager > Package Manager Console`) and install the required dependencies:  
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.IdentityModel.Tokens

### **Step 3: Run the application**  
The app runs on swagger.
	- First login using the following payload
			{
				"username": "test",
				"password": "test"
			}
	- This will return a JWT token
	-Input this token in the authorize pop-up on swagger - Bearer {jwt-token}
	- Now the api end points are authorized for further calls. 