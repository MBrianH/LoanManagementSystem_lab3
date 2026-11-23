# Loan Management System

A Windows desktop application for a small microfinance institution. Staff use it to register clients, process loan applications, record decisions, record payouts and repayments, and review loan reports.

## Technology

- C# and Windows Forms
- .NET 10 for Windows
- MariaDB through XAMPP
- MySqlConnector and ADO.NET

## Open the project

1. Extract the project folder.
2. Open `LoanManagementSystem.sln` in Visual Studio.
3. Install the **.NET desktop development** workload if it is not installed.
4. Start MariaDB from the XAMPP Control Panel.
5. Open phpMyAdmin and select the SQL tab.
6. Run `Scripts/LoanManagementDB.sql` only if you are creating the database for the first time.
7. If the database already exists, back it up and run `Scripts/UpdateRepaymentAmountColumn.sql` to align the repayment amount column with the application.
8. Restore NuGet packages, then choose **Build > Rebuild Solution**.
9. Press F5 to run the application.

The connection string is in `Database/DatabaseConnection.cs`. The supplied value assumes MariaDB is running on port 3306 and the local `root` account has no password.

## First sign-in

When the database has no Administrator account, the login screen shows **First-time Administrator setup**. Use it once to create the first Administrator. After that, the setup option is hidden. The Administrator creates the remaining staff accounts from **Staff Management**.

Clients do not sign in. The four staff roles are Administrator, Loan Officer, Loan Manager and Cashier.

## Screens

- Login and first Administrator setup
- Dashboard
- Client Management
- Loan Applications
- Loan Decisions
- Loan Payouts
- Active Loans
- Repayments
- Repayment Schedule
- Reports
- Staff Management

## Visual Designer and code

Each screen is a standard Windows Forms form with matching `.cs`, `.Designer.cs` and `.resx` files.

In Visual Studio, expand `Views` in Solution Explorer. Right-click a form's `.cs` file and choose **View Designer** to change its layout. Choose **View Code** to edit its event handlers and application logic. Use the Toolbox and Properties window to add controls and adjust their appearance. Keep the control `(Name)` values in sync with the code.

## Database notes

The SQL script creates the tables used by the application. `CREATE TABLE IF NOT EXISTS` does not change an existing table, so it does not automatically update an older database structure. Back up existing data before applying a migration.

The SRS does not specify interest, fees, penalties or the final repayment calculation policy. The current classroom implementation creates equal monthly instalments from the payout amount. Confirm that assumption with the lecturer before using it as a real lending policy.

The application records payments confirmed by staff. It does not transfer money or connect to a bank or mobile-money provider.


## Editing the Windows Forms interfaces

Each screen has a `.cs`, `.Designer.cs`, and `.resx` file. Open a form's `.cs` file and choose **View Designer** to edit its controls. Use **View Code** for event handlers and application logic.

Some data-entry areas use a `TableLayoutPanel` so the fields stay aligned when the window is resized. In those areas, controls are arranged by table cells rather than by free-form pixel dragging. Select a control and change its cell, row/column size, margins, and properties in the Properties window. The search bars and action buttons use fixed positions inside their panels so they remain separate and do not overlap.


## Recent interface adjustments

- The sign-in and System Account Setup screens use ordinary Windows Forms panels and positioned controls. This makes it easier to select and move individual controls in the Visual Studio Designer.
- The System Account Setup button remains visible on the sign-in screen. The setup screen checks whether an Administrator already exists and prevents creating another initial Administrator.
- The Loan Decisions table wraps long column headings and provides horizontal scrolling so headings are not forced into narrow columns.

### Moving controls in Design View

1. Open `LoginForm.cs` or `SystemAccountSetupForm.cs` in Solution Explorer.
2. Right-click the `.cs` file and choose **View Designer**.
3. Click the control you want to move. Drag it by its body, not by a text caret.
4. If it is difficult to select, use the Document Outline window or choose the control from the Properties window's object selector.
5. Change its `Location` and `Size` properties in the Properties window for precise alignment.

The green branding panel is a container. Controls inside it can be moved within that panel, but not outside it unless they are moved to the main form or another panel.

## Demo client records

Open `Scripts/DemoClientData.sql` in phpMyAdmin and execute it after the main
`Scripts/LoanManagementDB.sql` has created the database tables. The names,
identification numbers, phone numbers, and addresses in that file are fictional
test data. They are not real clients or verified national ID numbers.

## Updated account and reports screens

The Login and System Account Setup screens use side-by-side labels and textboxes.
The Reports screen has a separate, clearly spaced date/report row and client
statement row. In Visual Studio, expand each form node in Solution Explorer and
open the `.cs` file with **View Designer**. The project file marks
`SystemAccountSetupForm` as a Windows Form so its Designer file is paired.

## Administrator password recovery

The first-time System Account Setup screen is only for creating the first
Administrator. It intentionally does not create another Administrator after
setup has been completed. If the only Administrator password is lost, use a
controlled password-reset procedure that generates a new PBKDF2 hash through
the application's `PasswordHasher`; do not insert a plain-text password or
create another Administrator by bypassing the setup check.
