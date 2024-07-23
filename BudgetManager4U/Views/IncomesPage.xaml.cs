namespace BudgetManager4U.Views;
using BudgetManager4U.Services;
using BudgetManager4U.Models;
public partial class IncomesPage : ContentPage
{
    private readonly LocalDbService _dbService;

    public IncomesPage(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        InclistView.ItemsSource = await _dbService.GetIncomes();

    }

}