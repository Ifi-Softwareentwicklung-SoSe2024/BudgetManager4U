# BudgetManger4U
Matriculation No.: 65368, 63072 <br>
Modul: SWE

As part of the final project for the Software Development course in Summer Semester 2024, the following individuals:

* Konstantin Ibadullaev
* Carl Reemt Alf Schwaten

developed the project "BudgetManager4U."

This application not only assists in tracking your cash flow by recording expenses and income but also provides a basic statistical summary. Additionally, it allows for the export of data in CSV format for further processing and compatibility with other software solutions.

## Structure
The structure of the proposed app is presented on the UML diagram.
<br>
<br>
![My Diagram](uml.drawio.png)
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
