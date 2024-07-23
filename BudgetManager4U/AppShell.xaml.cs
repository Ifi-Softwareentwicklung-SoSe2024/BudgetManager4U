using BudgetManager4U.Views;

namespace BudgetManager4U
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Register all routes
            Routing.RegisterRoute("mainpage", typeof(MainPage));
            Routing.RegisterRoute("expensespage", typeof(ExpensesPage));
            Routing.RegisterRoute("incomespage", typeof(IncomesPage));
        }
    }
}
