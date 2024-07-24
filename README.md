# BudgetManger4U
Matriculation No.: 65368, 63072 <br>
Modul: SWE

As part of the final project for the Software Development course in Summer Semester 2024, the following individuals:

* Konstantin Ibadullaev
* Carl Reemt Alf Schwaten

developed the project "BudgetManager4U."
## Project Aim
The goal of this project is to explore MAUI.NET and demonstrate some essential CRUD-operations that are a cornerstone of modern apps which rely on databases for storage. On top of that, it is often handy to make use of available data export options, which export the given data into one of the most common file formats, such as a csv-file. These are frequently used for further processing, e.g statistical inference/summary or data analysis in the external apps/environments. 
Also note, that despite MAUI.NET is "cross-platform", this app targets Windows platform.

## Used Packages/Technologies
There exist many available options for development of applications with similar functionality, e.g. CRUD Systems.
We used the following technological stack to develope this application:
1. **SQLite**. This data base provider has the simplest functionality in comparison to other data bases with more sophisticated  functionality, but sufficient for this app given only one model. The following packages are installed via NuPackage Manager to enable manipulations with SQLite data bases:
  - sqlite-net-pcl
  - SQLitePCLRaw.bundle_green
  - SQLitePCLRaw.core
2. **MAUI.NET**. This is a framework for the cross-platform development in .NET. Its components are used, for exapmle, to create UI, navigation and app itselves.
3. **LINQ**. LINQ is one of the most common tool for collection manipulation, e.g filtering, ordering, grouping operation in .NET. In this application it is used in combination with the output of basic CRUD operations to produce more sophisticated results.

## Application Design
The modern enterpise applications are developed according to MVP following patterns like Model-View-Control(MVC), Model-View-ViewModel(MVVM) and Model-View-Update(MVU), which allow to decouple business logic, data(model) and presenation(view). This is crucial for very large and complex applications consisting of many models, services and makes easier maintainabilty and testing. This is considered to be a standard and best practice in the industry.

Despite aforementioned benefits, we do not follow this concept above, due to the simple structure of the project, but still achieve some grade of decoupling. Indeed, it contains only one model, one service(which could be also atomized in future), and 3 view pages.

## Implementation
This application serves as a finance tracker/budget manager/transaction scheduler. One can insert/edit/delete/get transactions(expense/income) by filling data in entry/editor of the main page and display them on three pages(views). 


The first page is the main page of the application, it displays the complete transaction history and the current balance, besides the controls and fields of the form for the editing and creating transaction.
The view for expenses displays only transactions with negative values. Furthermore, it is possible to filter transactions by date.
Finally, the view for incomes displays only transactions with positive values, which can be similarly filtered by date.


The project has only one model class: TransactionClass class, whose properties are also columns for the table "Transactions" created and manipulated by LocalDbService.
The LocalDbService is an essential component of this application, as it creates the database, the table "Transactions" and performs data manipulations.
Finally, the CSVWriter class enables the export of the transaction history stored in the data base instance.

## Class Diagram
Below  is the UML class diagram of the application. 
<br>
<br>
![My Diagram](ProjectUML.drawio.png)
<br>

## Instructions / User Guide
When the BudgetManager4U application is launched, a window opens showing the user's personal account. Here the user can monitor and manage their transactions, including both income and expenses. The following steps illustrate the process using an example income (salary) entry:

**Entering Income:**
To add an income transaction, for example a salary of €1000.00, enter the amount of the transaction in the top line. The application accepts both periods and commas as decimal separators and will automatically convert them if necessary. Immediately below, enter the date of the transaction (in this case, the salary) and optionally add a short description (e.g. 'monthly salary'). Once you have entered all the information correctly, click on the green 'Add Income' button. This will add the salary to the account, update the balance accordingly, and the income entry (highlighted in green) will automatically appear at the bottom of the recent transactions list. 
An overview of total income can be found in the top left tab, with the option to filter by specific dates. 

**Entering Expenses:** 
To add an expense, such as a weekly trip to the supermarket costing €150.34, enter the amount of the transaction, select the date of the trip to the supermarket and optionally add a short description (e.g. 'Groceries') as described more detailed in the 'Entering Income' section. Once you have entered all the information correctly, click the red 'Add Expense' button. This will add the expense to your account and update your balance accordingly. The groceries expense entry (highlighted in red and negative (-)) will automatically appear at the bottom of the recent transactions list. Again, you will find an overview of all expenses in the top left-hand tab, with the option of filtering by specific dates.

**Editing / Deleting a Transaction:**
If there are any errors in the transaction entry, or if an entry needs to be deleted, this can be done by clicking on the transaction in question. A window will appear with the options 'Edit', 'Delete' or 'Cancel'. Selecting "Edit" will reopen the transaction in the input fields at the top, where it can be modified as required. Selecting 'Delete' will remove the transaction permanently. If no changes are required, the transaction can be cancelled by selecting 'Cancel'.

**CSV Export:**
BudgetManager4U also allows you to export data in CSV format for further processing and compatibility with other software solutions. All you need to do is click on the grey 'Export as CSV' button. This will automatically save the transactions to a CSV file and display a confirmation and the location of the file.
