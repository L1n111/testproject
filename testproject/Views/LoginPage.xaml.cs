
using System.Xml.Linq;
using testproject.Models;
using testproject.Services;
using testproject.ViewModels;

namespace testproject.Views;

public partial class LoginPage : ContentPage
{
    LoginPageViewModel vm;
	public LoginPage()
	{
		InitializeComponent();
		vm = new LoginPageViewModel();
        BindingContext = vm;
	}
}