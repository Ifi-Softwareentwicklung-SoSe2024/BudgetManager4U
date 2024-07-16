using BudgetManager4U.Views;

namespace BudgetManager4U
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Register all routes
            Routing.RegisterRoute("loginpage", typeof(LoginPage));
            Routing.RegisterRoute("signuppage", typeof(SignUpPage));
            Routing.RegisterRoute("mainpage", typeof(MainPage));
            Routing.RegisterRoute("useraccountpage", typeof(UserAccountPage));
        }
    }
}
