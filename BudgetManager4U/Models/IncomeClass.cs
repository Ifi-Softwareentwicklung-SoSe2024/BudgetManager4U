using System;
namespace BudgetManager4U.Models;
public class IncomeClass
{
    // foreign key
    public int userId;
    public int idInc { get; set; }
    public string categoryInc { get; set; }
    public DateTime dateInc { get; set; }
    public decimal valInc { get; set; }
    public string descriptionInc { get; set; }

}
