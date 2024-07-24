namespace BudgetManager4U.Views;
using BudgetManager4U.Services;
using BudgetManager4U.Models;
public partial class ExpensesPage : ContentPage
{
    private readonly LocalDbService _dbService;
   
    public ExpensesPage(LocalDbService dbService)
    {
		InitializeComponent();
        _dbService = dbService;
       
    }
    private async void OnFilterClicked(object sender, EventArgs e)
    {
        ExplistView.ItemsSource = await _dbService.GetExpensesByDate(dayFrom.Date, dayTo.Date);


    }

    protected override async void OnAppearing()
    {
       base.OnAppearing();
       ExplistView.ItemsSource = await _dbService.GetExpenses();
 
    }

}