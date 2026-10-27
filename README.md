# 📚 Book Haven - Books Management System (Lab 7)

An elegant, modern ASP.NET Core Razor Pages application designed to seamlessly track and manage your global library catalog with a responsive database interface.

## ✨ Core Features

* **Compact List View:** An optimized metadata grid system built with a precision percentage-locked structural layout.
* **Dynamic Information Modal Pop-up:** View full descriptions, summaries, and deep indexing parameters instantly via an interactive JavaScript layout window without page shifts.
* **Complete CRUD Capabilities:** Built-in modular interfaces to easily Create, Read, Update, and Delete book tracking records.
* **Theme Integration:** Styled with a warm, modern aesthetic palette featuring chocolate accent lines, cream containers, and custom transaction labels.

## 🛠️ Technological Stack

* **Framework:** ASP.NET Core (Razor Pages)
* **Database Engine:** Microsoft SQL Server (LocalDB / SSMS)
* **Data Access Layer:** ADO.NET / raw SQL commands for optimized transaction handling
* **Front-End Styling:** Custom optimized CSS (`site.css`) alongside clean asynchronous JavaScript handlers

## 🗄️ Database Setup Configuration

To initialize the backend context system storage tables, execute the following script inside your target SQL server instance:

```sql
CREATE DATABASE BMS_Lab06_DB;
GO

USE BMS_Lab06_DB;
GO

CREATE TABLE books (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    title NVARCHAR(200) NOT NULL,
    author NVARCHAR(150) NOT NULL,
    description NVARCHAR(MAX) NULL,
    publisher NVARCHAR(150) NULL,
    status NVARCHAR(50) NOT NULL DEFAULT 'Available',
    category NVARCHAR(100) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO
```
