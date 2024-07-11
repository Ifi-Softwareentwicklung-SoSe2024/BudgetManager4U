using System;
namespace BudgetManager4U;
public class ExpenseClass
{
	public int id { get; set; }
	public string category { get; set; }
	public DateTime dateExp { get; set; }
	public decimal valExp { get; set; }
	public string description{ get; set; }
}
