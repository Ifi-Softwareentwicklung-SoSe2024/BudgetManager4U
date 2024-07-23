using BudgetManager4U;
using BudgetManager4U.Views;
using BudgetManager4U.Services;
namespace BudgetManager4U;



    public partial class App : Application
    {
        private static LocalDbService _database;

        public static LocalDbService Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new LocalDbService();
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
