using SQLite;
using System;
using CommunityToolkit.Mvvm.ComponentModel;

using System.Collections.ObjectModel;

namespace BudgetManager4U.Models   ;

[Table("Users")]
public class UserAccountClass
{
    [PrimaryKey]
    [AutoIncrement]
    [Column("Id")]
    public int Id { get; set; }
    
    [Column("First_name")]
  
    public string FirstName { get; set; }


    [Column("Last_name")]
    public string LastName { get; set; }

    [Column("Email")]
    public string Email { get; set; }

    private DateTime registrationDate;

    [Column("Registration_Date")]
    public DateTime RegistrationDate  
    {
        get { return registrationDate; }   
        set { registrationDate = value; }  
    }

    private string password;
    [Column("Password")]
    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    


}
