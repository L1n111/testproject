
using System.Xml.Linq;
using testproject.Models;
using testproject.Services;

namespace testproject.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void OnSignInClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
        var users = DataRepo.GetUsers();
        if (string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(password))
        {
            ShowError("All fields are required.");
            return;
        }
        User foundUser = users.FirstOrDefault(u => u.Email.Equals(email));
        if (foundUser != null && foundUser.Password == password)
        {
            ShowError("Login successful :3");
        }
        else
        {
            ShowError("Wrong e-mail or password");
        }
    }
    private void ShowError(string message)
    {
        ErrorLabel.Text = message;
        ErrorLabel.IsVisible = true;
    }
}