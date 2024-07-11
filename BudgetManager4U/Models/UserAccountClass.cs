using System;
namespace BudgetManager4U;
public class UserAccountClass
{
	public string firstName { get; set; }
    public string lastName { get; set; }
	
    public string email { get; set; }

    private string registrationDate; 
    public string RegistrationDate  
    {
        get { return registrationDate; }   
        set { registrationDate = value; }  
    }

    private string password 
    public string Password
    {
        get { return password; }
        set { password = value; }
    }


}
