using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BudgetManager4U.Models;
[Table("transactions")]

public class TransactionClass
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]

    public int Id { get; set; }
    
    [Column("Date")]
    [Required]

    public DateTime Datum { get; set; }

    [Column("Transaction_Amount")]
    [Required]
    public  decimal TransactionAmount { get; set; }
    
    [Column("Description")]
    
    public string? Description { get; set; }   

}
