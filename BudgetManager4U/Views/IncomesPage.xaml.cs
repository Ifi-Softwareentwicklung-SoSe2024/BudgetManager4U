namespace BudgetManager4U.Views;
using BudgetManager4U.Services;
using BudgetManager4U.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
/// <summary>
///  class <c>IncomesPage</c> Displays a listview with instances of the TransactionsClass  with the negative values of the transactionAmount property
/// </summary>
public partial class IncomesPage : ContentPage
{
   
    
   
    private readonly LocalDbService _dbService;
    /// <summary>
    /// constructor of the class <c>IncomesPage</c> 
    /// </summary>
    public IncomesPage(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;

    }
    /// <summary>
    /// Updates the current listview values of this page with respect to selected dates
    /// </summary>
    /// <param name="sender"> object, the control binded to the clicked event</param>
    /// <param name="e">argument of triggered event </param>
    /// <returns> void </returns>
    private async void OnFilterClicked(object sender, EventArgs e)
    {
       
        InclistView.ItemsSource = await _dbService.GetIncomesByDate(dayFrom.Date, dayTo.Date);


    }
    /// <summary>
    /// Updates the current listview  of this page on appearing
    /// </summary>
    /// <returns> void </returns>
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        InclistView.ItemsSource = await _dbService.GetIncomes();

    }

}