
using BudgetManager4U.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager4U.Service;

public class BaseService
{
    protected readonly DatabaseContext dbContext;
    public string StatusMessage;
    public BaseService(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
        _ = Init(this.dbContext);
    }

    public async Task Init(DatabaseContext dbContext)
    {
        if (dbContext.DatabaseConnection is not null)
            return;

        dbContext.DatabaseConnection = new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);

        var migrationResult = await dbContext.DatabaseConnection.CreateTablesAsync(CreateFlags.None
                , typeof(UserAccountClass)
                , typeof(IncomeClass)
                , typeof(ExpenseClass)
                );
    }

}
