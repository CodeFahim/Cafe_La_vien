# ☕ Cafe La Vien

A desktop **cafe management system** built with **C# Windows Forms** and **SQL Server**.
Admins manage staff, the menu, and sales records, while cashiers take orders, manage the cart, and generate invoices.

---

## ✨ Features

### 👤 Login
- One login screen for every user
- Opens the **Admin** or **Cashier** panel based on the user's role
- Show/hide password option

### 🛠️ Admin Panel
- **User Management**: add, update, remove, and search users (by ID or name)
- **Menu Management**: add, update, and remove food items with price and stock
- **Sales History**: view all sales, filter by month, sort by highest sale or cashier
- **Profile**: view your own details

### 🧾 Cashier Panel
- **Menu & Cart**: search food, add to cart, update quantity, remove items, clear the cart
- Stock updates automatically when items are added to or removed from the cart
- **Billing**: total, VAT, and discount calculated automatically
- **Invoice**: confirm the order to save the sale and show an invoice
- **Sales History** and **Profile**

---

## 🧰 Built With

| Part      | Technology                  |
|-----------|-----------------------------|
| Language  | C#                          |
| UI        | Windows Forms               |
| Framework | .NET Framework 4.7.2        |
| Database  | Microsoft SQL Server (Express) |
| IDE       | Visual Studio 2022          |

---

## 🚀 Getting Started

### 1. Clone the repository
```bash
git clone https://github.com/CodeFahim/Cafe_La_vien.git
```

### 2. Create the database
Open **SQL Server Management Studio** and run:

```sql
CREATE DATABASE CafeLaVie;
GO
USE CafeLaVie;
GO

CREATE TABLE LogIn (
    UserID   NVARCHAR(50) NOT NULL PRIMARY KEY,
    Password NVARCHAR(50) NOT NULL,
    Role     NVARCHAR(50) NOT NULL
);

CREATE TABLE UserTable (
    UserId   NVARCHAR(50) NOT NULL PRIMARY KEY,
    Name     NVARCHAR(50) NOT NULL,
    Email    NVARCHAR(50) NOT NULL,
    PhoneNo  NVARCHAR(50) NOT NULL,
    Gender   NVARCHAR(50) NOT NULL,
    Role     NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL
);

CREATE TABLE MenuTable (
    FoodID    NVARCHAR(50)   NOT NULL PRIMARY KEY,
    FoodName  NVARCHAR(50)   NOT NULL,
    FoodPrice DECIMAL(18, 0) NOT NULL,
    Quantity  INT            NOT NULL,
    FoodImage VARBINARY(MAX) NULL
);

CREATE TABLE OrderTable (
    OrderID    NVARCHAR(50)   NOT NULL PRIMARY KEY,
    Quantity   DECIMAL(18, 0) NOT NULL,
    TotalBill  DECIMAL(18, 0) NOT NULL,
    OrderName  NVARCHAR(50)   NOT NULL,
    OrderPrice NVARCHAR(50)   NOT NULL
);

CREATE TABLE SellTable (
    OrderID   NVARCHAR(50)   NOT NULL,
    FoodName  NVARCHAR(50)   NOT NULL,
    Quantity  DECIMAL(18, 0) NOT NULL,
    CashierID NVARCHAR(50)   NOT NULL,
    SellDate  DATE           NOT NULL,
    TotalBill DECIMAL(18, 0) NOT NULL
);

-- First admin account (change the password after logging in)
INSERT INTO LogIn     VALUES ('A-001', 'admin123', 'Admin');
INSERT INTO UserTable VALUES ('A-001', 'Admin', 'admin@cafe.com', '0000000000', 'Male', 'Admin', 'admin123');
```

### 3. Set your connection string
Open `DataAccess.cs` and update the connection string **in both places** with your own SQL Server name and password:

```csharp
Data Source=YOUR_PC_NAME\SQLEXPRESS;Initial Catalog=CafeLaVie;User ID=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True;
```

### 4. Run
Open `Cafe La Vien.sln` in Visual Studio and press **F5**.
Log in with **User ID:** `A-001` and **Password:** `admin123`.

> 💡 **Build error about a resource path?** Some image names are long. Put the project in a short folder (for example `C:\CafeLaVien`) so the full path stays under Windows' 260-character limit.

---

## 📂 Project Structure

| File | Purpose |
|------|---------|
| `FormLoginPanel.cs` | Login screen |
| `FormAdmin.cs` | Admin dashboard |
| `FormCashier.cs` | Cashier dashboard |
| `FormUserManage.cs` | Add / update / remove users |
| `FormManageMenu.cs` | Add / update / remove menu items |
| `Form1.cs` | Menu, cart, billing, and invoice (cashier) |
| `Form2.cs` | Sales history |
| `FormUserProfile.cs` | User profile |
| `DataAccess.cs` | Database connection and queries |

---

## 👨‍💻 Author

**Fahim**: [@CodeFahim](https://github.com/CodeFahim)

Made as a C# course project. 🎓
