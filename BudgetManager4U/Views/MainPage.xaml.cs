using BudgetManager4U.Services;
using BudgetManager4U.Models;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;

namespace BudgetManager4U.Views;

public partial class MainPage : ContentPage
{
    private readonly LocalDbService _dbService;
    private int _editTransactionId;


    /// <summary>
    ///  constructor, Initalizaties the component and assgins '_dbServices' to provided 'LocalDbService' instance
    /// </summary>
    /// <param name="main"></param>
    /// <returns></returns>
    public MainPage(LocalDbService dbService)
    {
        InitializeComponent();
        _dbService = dbService;
        Task.Run(async () => listView.ItemsSource = await _dbService.GetTransactions());
        Task.Run(async () => balanceLabel.Text = await _dbService.GetBalance());

    }


    /// <summary>
    ///  handles the click even for adding an income transaction
    /// </summary>
    /// <param name="main"></param>
    /// <returns></returns>

    private async void OnIncomeClicked(object sender, EventArgs e)
    {
        try
        {
            if (_editTransactionId == 0 && TransactionAmountEntryField.Text != null)
            {


                await _dbService.AddTransaction(
                    new TransactionClass
                    {

                        TransactionAmount = Convert.ToDecimal(TransactionAmountEntryField.Text.Replace(".", ",").Replace("-", "")),
                        Description = DescriptionEntryField.Text,
                        Datum = Convert.ToDateTime(DatePickerField.Date),
                    }
                         );
            }


            else
            {
                await _dbService.UpdateTransaction(new TransactionClass
                {
                    Id = _editTransactionId,
                    TransactionAmount = Convert.ToDecimal(TransactionAmountEntryField.Text.Replace(".", ",").Replace("-", "")),
                    Description = DescriptionEntryField.Text,
                    Datum = DatePickerField.Date,
                });
                _editTransactionId = 0;


            }
            TransactionAmountEntryField.Text = string.Empty;
            DescriptionEntryField.Text = string.Empty;
            listView.ItemsSource = await _dbService.GetTransactions();
            balanceLabel.Text = await _dbService.GetBalance();
        }
        catch (FormatException ex) { Console.WriteLine(ex.Message); }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        finally { Console.WriteLine(""); }

    }


    /// <summary>
    ///  handles the click even for saving transactions to CSV file
    /// </summary>
    /// <param name="main"></param>
    /// <returns></returns>
    
    private async void OnSaveCsvButtonClicked(object sender, EventArgs e)
    {
        //List<TransactionClass> transactions = await _dbService.GetTransactionsAsync();
        List<TransactionClass> transactions = await _dbService.GetTransactions();
        string fileName = $"Transactions_{DateTime.Now:yyyyMMdd}.csv";

        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
        CsvWriter.WriteTransactionsToCsv(transactions, filePath);

        await DisplayAlert("CSV Saved", $"CSV file has been saved to: {filePath}", "OK");
    }


    /// <summary>
    ///  handles the click even for adding an epense transaction
    /// </summary>
    /// <param name="main"></param>
    /// <returns></returns>

    private async void OnExpenseClicked(object sender, EventArgs e)
    {
        try
        {
            if (_editTransactionId == 0 && TransactionAmountEntryField.Text != null)
            {


                await _dbService.AddTransaction(
                new TransactionClass
                {

                    TransactionAmount = -1 * Convert.ToDecimal(TransactionAmountEntryField.Text.Replace(".", ",").Replace("-", "")),
                    Description = DescriptionEntryField.Text,
                    Datum = Convert.ToDateTime(DatePickerField.Date),
                }
                     );
            }
            else
            {
                await _dbService.UpdateTransaction(new TransactionClass
                {
                    Id = _editTransactionId,
                    TransactionAmount = Convert.ToDecimal(TransactionAmountEntryField.Text),
                    Description = DescriptionEntryField.Text,
                    Datum = DatePickerField.Date,
                });
                _editTransactionId = 0;


            }

            balanceLabel.Text = await _dbService.GetBalance();
            TransactionAmountEntryField.Text = string.Empty;
            DescriptionEntryField.Text = string.Empty;
            listView.ItemsSource = await _dbService.GetTransactions();
        }
        catch (FormatException ex) { Console.WriteLine(ex.Message); }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        finally { Console.WriteLine(""); }
    }


    /// <summary>
    ///  handles the tapping even on an item in the list view
    /// </summary>
    /// <param name="main"></param>
    /// <returns></returns>

    public async void OnlistViewTapped(object sender, ItemTappedEventArgs e)
    {
        var transaction = (TransactionClass)e.Item;
        var action = await DisplayActionSheet($"Would you like to remove or \n edit this transaction? ", "Cancel", null, "Edit", "Delete");
        switch (action)
        {
            case "Edit":
                _editTransactionId = transaction.Id;
                TransactionAmountEntryField.Text = Convert.ToString(transaction.TransactionAmount);
                DescriptionEntryField.Text = transaction.Description;
                DatePickerField.Date = transaction.Datum;
                balanceLabel.Text = await _dbService.GetBalance();
                break;
            case "Delete":
                await _dbService.DeleteTransaction(transaction);
                listView.ItemsSource = await _dbService.GetTransactions();
                balanceLabel.Text = await _dbService.GetBalance();
                break;


        }


    }

    

}
