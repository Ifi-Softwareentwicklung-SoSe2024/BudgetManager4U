using System;
namespace BudgetManager4U;

public class ExpenseClass
{
	public int idExp { get; set; }
	public string categoryExp { get; set; }
	public DateTime dateExp { get; set; }
	public decimal valExp { get; set; }
	public string descriptionExp{ get; set; }
}
