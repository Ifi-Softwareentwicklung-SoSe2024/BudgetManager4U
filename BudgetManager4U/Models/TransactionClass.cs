using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BudgetManager4U.Models;
/// <summary>
///Model of the class <c>TransactionClass</c>
/// </summary>
[Table("transactions")]

public class TransactionClass
{
    /// <value>
    /// The <c>Id</c> property represents an Id 
    /// for this instance.
    /// </value>
    [PrimaryKey]
    [AutoIncrement]
    [Column("id")]

    public int Id { get; set; }
    /// <value>
    /// The <c>Datum</c> property represents an transaction date 
    /// for this instance .
    /// </value>

    [Column("Date")]
    [Required]

    public DateTime Datum { get; set; }
    /// <value>
    /// The <c>TransactionAmount</c> property represents an transaction amount 
    /// for this instance .
    /// </value>

    [Column("Transaction_Amount")]
    [Required]
    public  decimal TransactionAmount { get; set; }

    /// <value>
    /// The <c>Description</c> property represents an description of this transaction  
    ///  instance .
    /// </value>
    [Column("Description")]
    
    public string? Description { get; set; }   

}
