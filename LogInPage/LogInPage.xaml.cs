using Microsoft.Maui.Controls;
using System;

namespace BudgetManager.Pages
{
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
        }

        private async void OnSignInButtonClicked(object sender, EventArgs e)
        {
            string email = MailEntry.Text;
            string password = PasswordEntry.Text;

            // Implement your authentication logic here
            bool isAuthenticated = AuthenticateUser(email, password);

            if (isAuthenticated)
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

        private bool AuthenticateUser(string email, string password)
        {
            // Placeholder authentication logic
            return !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password);
        }
    }
}
