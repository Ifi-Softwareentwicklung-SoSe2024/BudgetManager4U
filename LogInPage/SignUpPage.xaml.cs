using Microsoft.Maui.Controls;
using System;
using BudgetManager4U.Data;

namespace BudgetManager4U.Pages
{
    public partial class SignUpPage : ContentPage
    {
        private DatabaseService _databaseService;

        public SignUpPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            string vorname = VornameEntry.Text;
            string nachname = NachnameEntry.Text;
            string email = MailEntry.Text;
            string password = PasswordEntry.Text;

            // Create a new user and save it to the database
            User newUser = new User
            {
                Vorname = vorname,
                Nachname = nachname,
                Email = email,
                Password = password
            };

            int result = await _databaseService.SaveUserAsync(newUser);

            if (result > 0)
            {
                await DisplayAlert("Success", "Account created successfully", "OK");
                // Navigate back to the login page
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Failed to create account", "OK");
            }
        }
    }
}

