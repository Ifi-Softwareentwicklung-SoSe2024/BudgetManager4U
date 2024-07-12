using Microsoft.Maui.Controls;
using System;
using BudgetManager4U.Data;

namespace BudgetManager4U.Pages
{
    public partial class LogInPage : ContentPage
    {
        private DatabaseService _databaseService;

        public LogInPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private async void OnSignInButtonClicked(object sender, EventArgs e)
        {
            string email = MailEntry.Text;
            string password = PasswordEntry.Text;

            // Authenticate user using the database
            User user = await _databaseService.GetUserByEmailAndPasswordAsync(email, password);

            if (user != null)
            {
                await DisplayAlert("Success", "Login successful", "OK");
                // Navigate to the main page or dashboard
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Invalid email or password", "OK");
            }
        }

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
