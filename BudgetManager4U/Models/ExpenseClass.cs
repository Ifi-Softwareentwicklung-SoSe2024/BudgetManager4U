using System;
namespace BudgetManager4U.Models;

public class ExpenseClass
{
    // foreign key
    public int userId;
	public int idExp { get; set; }
	public string categoryExp { get; set; }
	public DateTime dateExp { get; set; }
	public decimal valExp { get; set; }
	public string descriptionExp{ get; set; }
}
