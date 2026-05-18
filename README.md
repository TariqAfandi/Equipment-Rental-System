# 🏗️ Equipment Rental System

A full-stack equipment rental management system built with **ASP.NET Core Web API** and **Windows Forms**, backed by **Microsoft SQL Server**. The system supports end-to-end rental lifecycle management including user management, rental requests, transactions, return processing, notifications, and feedback.

---

## 📁 Project Structure

```
EquipmentRentalSystem/
├── EquipmentRental.Web/        # ASP.NET Core Web API (backend)
├── EquipmentRental.Data/       # Data access layer / Entity Framework models
├── rental_system_frontend/     # Windows Forms desktop application (frontend)
├── rental_System_db/           # Database project
├── EquipmentRentalDb.sql       # Full SQL Server database schema & seed script
└── EquipmentRentalSystem.sln   # Visual Studio solution file
```

---

## 🗄️ Database Schema

The application uses **Microsoft SQL Server** with the following tables:

| Table | Description |
|---|---|
| `Users` | Stores user accounts with roles (admin/customer) |
| `Categories` | Equipment categories for classification |
| `Equipment` | Equipment inventory with pricing, condition, and availability |
| `RentalRequests` | Customer rental requests pending approval |
| `RentalTransactions` | Confirmed and active rental records |
| `ReturnRecords` | Return processing with late/damage fees |
| `Documents` | Uploaded files linked to users or transactions |
| `Feedback` | Customer ratings and comments per rental |
| `Notifications` | In-app notification system per user |
| `Logs` | Audit trail of user actions |

---

## 🚀 Getting Started

### Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/) (v17+)
- [.NET SDK](https://dotnet.microsoft.com/download) (version used in solution)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server) (2019 or later)
- [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup) *(optional but recommended)*

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/EquipmentRentalSystem.git
cd EquipmentRentalSystem
```

### 2. Set Up the Database

1. Open **SSMS** and connect to your SQL Server instance
2. Open `EquipmentRentalDb.sql`
3. Run the script to create the database and all tables

> ⚠️ The SQL script contains a hardcoded file path from the original machine. Before running, update the `FILENAME` paths in the `CREATE DATABASE` block to match your local SQL Server data directory.

### 3. Configure the Connection String

In `EquipmentRental.Web`, locate `appsettings.json` and update the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=EquipmentRentalDb;Trusted_Connection=True;"
}
```

### 4. Run the Application

Open `EquipmentRentalSystem.sln` in Visual Studio.

- To run the **Web API**: set `EquipmentRental.Web` as the startup project and press **F5**
- To run the **Windows Forms desktop app**: set `rental_system_frontend` as the startup project and press **F5**

> 💡 You can run both simultaneously — right-click the solution → **Properties** → **Multiple startup projects**, and set both to **Start**.

---

## ⚙️ Tech Stack

| Layer | Technology |
|---|---|
| Backend | ASP.NET Core Web API (C#) |
| Desktop Frontend | Windows Forms (C#) |
| ORM | Entity Framework Core |
| Database | Microsoft SQL Server |
| IDE | Visual Studio 2022 |

---

## 🔐 Environment & Security Notes

- **Do not commit** `appsettings.json` if it contains real credentials — add it to `.gitignore`
- Use environment variables or [.NET User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) for local development
- The `Users` table stores passwords — ensure hashing is applied in the application layer before production use

---

## 📄 License

This project was developed as part of an academic course (IT8118). All rights reserved.
