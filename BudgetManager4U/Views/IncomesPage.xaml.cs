namespace BudgetManager4U.Views;
using BudgetManager4U.Services;
using BudgetManager4U.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class IncomesPage : ContentPage
{
    private readonly LocalDbService _dbService;

    public IncomesPage(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;

    }
    private async void OnFilterClicked(object sender, EventArgs e)
    {
        InclistView.ItemsSource = await _dbService.GetIncomesByDate(dayFrom.Date, dayTo.Date);


    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        InclistView.ItemsSource = await _dbService.GetIncomes();

    }

}