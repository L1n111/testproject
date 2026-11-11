namespace testproject.Views;
using testproject.Models;
using testproject.Services;
using testproject.ViewModels;

public partial class RegisterPage : ContentPage
{
    RegisterPageViewModel vm;
    public RegisterPage()
	{
        InitializeComponent();
        vm = new RegisterPageViewModel();
        BindingContext = vm;
    }
}