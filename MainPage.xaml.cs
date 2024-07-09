using System.Collections.ObjectModel;


namespace BudgetManager4U
{
    public ObservableCollection<BudgetItem> BudgetItems { get; set; }

    public MainPage()
    {
        InitializeComponent();
        BudgetItems = new ObservableCollection<BudgetItem>();
        BindingContext = this;
    }

    private async void OnLoadBudgetClicked(object sender, EventArgs e)
    {
        var path = Path.Combine(FileSystem.AppDataDirectory, "budget.csv");
        var budgetItems = BudgetCsvReader.ReadCsv(path);

        BudgetItems.Clear();
        foreach (var item in budgetItems)
        {
            BudgetItems.Add(item);
        }
    }

    private async void OnSaveBudgetClicked(object sender, EventArgs e)
    {
        var path = Path.Combine(FileSystem.AppDataDirectory, "budget.csv");
        BudgetCsvWriter.WriteCsv(path, new List<BudgetItem>(BudgetItems));
    }
}
}