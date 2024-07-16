using BudgetManager4U.Service;

using BudgetManager4U.ViewModels;
using System.ComponentModel;
namespace BudgetManager4U.Views;

public partial class LoginPage : ContentPage
{
  
    public LoginPage()
	{
		InitializeComponent();
        BindingContext = this;
	}

    private async void OnUrlClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }

}