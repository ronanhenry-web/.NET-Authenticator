# .NET Authenticator

This project is a .NET 8 Web API demonstrating a complete authentication system using **ASP.NET Core Identity** and **JWT (JSON Web Tokens)**. It is designed using a clean architecture with **three layers (Controller, Service, DataAccess)** and implements best practices for security and scalability.

## 📦 Features

- ✅ Authentication & Authorization using **JWT tokens**
- 🔐 Secure **refresh token** mechanism
- 👤 User & Role management with **ASP.NET Identity**
- 🧱 Clean architecture: **Controller / Service / DataAccess**
- 🌍 Localization support (i18n) and RFC 7807 error format
- 📋 Full CRUD for Interventions and Service Types
- 👥 Role-specific endpoints for clients and technicians
- 🧪 Ready for integration with frontend apps or mobile clients
- 📁 Modular structure with support for **manual data seeding**

## 🧱 Architecture

```
├── Controllers/       # API entrypoints
├── Services/          # Business logic
├── DataAccess/        # EF Core context & repositories
├── DTOs/              # Data transfer objects
├── Models/            # Domain entities
├── Middleware/        # Error handling, localization
├── Program.cs         # App configuration
├── appsettings.json   # Config file
```

## 🔧 Technologies

- ASP.NET Core 8
- Entity Framework Core
- ASP.NET Identity
- JWT Bearer Authentication
- C# / .NET
- SQL Server

## 🔐 Endpoints

### 🔑 Authentication

| Method | Route                              | Description                        |
|--------|------------------------------------|------------------------------------|
| POST   | `/api/auth/register/client`        | Register a new client              |
| POST   | `/api/auth/register/technicien`    | Register a new technician          |
| POST   | `/api/auth/login`                  | Login and receive JWT token        |
| POST   | `/api/auth/refresh`                | Get a new access token             |

### 🛠️ Interventions

| Method | Route                          | Description                               |
|--------|--------------------------------|-------------------------------------------|
| GET   | `/api/intervention`             | Get all interventions (admin/tech/client) |
| GET   | `/api/intervention/{id}`        | Get a specific intervention by ID         |
| POST   | `/api/intervention`            | Create a new intervention (admin only)    |

### 🦾 Service Types

| Method | Route                          | Description                            |
|--------|--------------------------------|----------------------------------------|
| GET   | `/api/servicetype`              | Get all service types                  |
| POST   | `/api/servicetype`             | Create a new service type (admin)      |

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/ronanhenry-web/.NET-Authenticator.git
cd .NET-Authenticator
```

### 2. Configure the database

In `appsettings.json`, update the `DefaultConnection` string to match your SQL Lite settings.

```json
"ConnectionStrings": {
    "DefaultConnection": "Data Source=articles.db"
},
```

### 3. Run migrations and seed the database

```bash
dotnet ef database update
```

(Seeding will insert demo users and roles)

### 4. Run the application

```bash
dotnet run
```

API is now available at: `https://localhost:5001` or `http://localhost:5000`

## 🧪 Testing

Use tools like Postman to test the API.

Example login request:
```json
POST /api/auth/login
{
  "email": "admin@admin.com",
  "password": "Admin123!"
}
```

## 🛡️ Security Highlights

- Passwords hashed using PBKDF2
- JWT tokens signed and verified with a secret key
- Refresh tokens stored securely and linked to users
- RFC 7807 compliant error handling with i18n support
- CSRF/XSS mitigations explained in code comments

## 📚 Based on

This project follows concepts from an advanced .NET course, including:
- REST API fundamentals
- Identity + JWT setup
- Manual seeding
- Clean architecture and DI
- Localized error messages

---

Feel free to fork and customize this boilerplate for your own use cases!
