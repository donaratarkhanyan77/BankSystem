# Bank System

Bank System is a learning project built with **.NET 8 / ASP.NET Core Web API**, following the principles of **Onion Architecture** and using **Entity Framework Core**.

## 📂 Solution Structure

### 1. Bank.Domain
- Entities: Customer, Account, Transaction, CustomerProfile, Branch, CustomerBranch
- Interfaces/Repositories: ICustomerRepository, IAccountRepository, etc.
- IUnitOfWork – unit of work contract

### 2. Bank.Application
- DTOs – request and response models
- Interfaces – service contracts
- Services – business logic via UnitOfWork

### 3. Bank.Infrastructure
- Data – AppDbContext
- Repositories – repository implementations
- Migrations – EF Core database migrations

### 4. Bank.API
- Controllers – REST API controllers
- Application configuration – Dependency Injection, Swagger

## ⚙️ Technologies
- .NET 8 / ASP.NET Core Web API
- Entity Framework Core
- InMemory / SQL Server provider
- Swagger (Swashbuckle)
- Dependency Injection
