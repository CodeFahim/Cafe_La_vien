# Cafe La Vien

A cafe management system I made for my C# course using Windows Forms and SQL Server.

There are two types of users:
- **Admin** can manage users, the menu and see sales history.
- **Cashier** can take orders, add items to the cart and print the invoice.

## How to run

1. Open `Cafe La Vien.sln` in Visual Studio.
2. Create a SQL Server database named `CafeLaVie` with these tables: `LogIn`, `UserTable`, `MenuTable`, `OrderTable`, `SellTable`.
3. In `DataAccess.cs`, change the server name and password to your own.
4. Run the project.
