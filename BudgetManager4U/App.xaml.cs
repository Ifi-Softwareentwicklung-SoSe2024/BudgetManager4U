using BudgetManager4U;
using BudgetManager4U.Views;

namespace BudgetManager4U;


public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        //MainPage = new NavigationPage(new LoginPage());
       // MainPage = loginPage();
       // Application.Current.MainPage = new AppShell();
        
        
        MainPage = new AppShell();
        
    }
}
