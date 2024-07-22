using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetManager4U
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSaveCsvButtonClicked(object sender, EventArgs e)
        {
            var transactions = new List<Transaction>
            {
                new Income { Id = 1, Value = 1000.00m, Date = DateTime.Now, Description = "Salary" },
                new Expense { Id = 2, Value = -150.00m, Date = DateTime.Now, Description = "Grocery" }
                
                
                
                
                // Adding more transactions here 





            };

            var csvContent = CsvHelper.ConvertTransactionsToCsv(transactions);
            await SaveCsvAsync(csvContent);
        }

        private async Task SaveCsvAsync(string csvContent)
        {
            try
            {
                await FileSaver.SaveCsvToFileAsync(csvContent, "transactions.csv");
                await DisplayAlert("Success", "CSV file saved successfully.", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to save CSV file: {ex.Message}", "OK");
            }
        }
    }
}
