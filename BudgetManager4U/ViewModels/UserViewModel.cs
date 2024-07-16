using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using BudgetManager4U.Models;
using BudgetManager4U.Service;
namespace BudgetManager4U.ViewModels;


public partial class UserViewModel:BaseViewModel
{
   UserService _userService;


    public UserViewModel(UserService userService)
    {
        _userService = userService;
    }

    //[ObservableProperty]
   // UserAccountClass user;

    [RelayCommand]
    public async Task CreateUserAsync(UserAccountClass user)
    {
        var newUser = await _userService.InsertUserAccount(user);//InsertUserAccount(UserAccountClass);
    }















}
