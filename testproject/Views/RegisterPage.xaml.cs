namespace testproject.Views;
using testproject.Services;
using testproject.Models;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}
    private void OnRegClicked(object sender, EventArgs e)
    {
        ErrorLabel.IsVisible = false;
        ErrorLabel.Text = string.Empty;

        string name = NameEntry.Text;
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;
        DateTime birthDate = BirthDatePicker.Date;
        var users = DataRepo.GetUsers();

        if (string.IsNullOrEmpty(name) ||
            string.IsNullOrEmpty(email) ||
            string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(confirmPassword))
        {
            ShowError("All fields are required.");
            return;
        }
        if (password.Length < 6)
        {
            ShowError("Password must be at least 6 characters long.");
            return;
        }
        if (!email.Contains("@") || !email.Contains("."))
        {
            ShowError("Invalid email format.");
            return;
        }

        if (password != confirmPassword)
        {
            ShowError("Passwords do not match.");
            return;
        }
        if (DataRepo.RegisterNewUser(name, email, password, birthDate))
        {
            ShowError("User created");
        }
        else
        {
            ShowError("User already exists");
            return;
        }
        DisplayAlert("Success", "Account created successfully!", "OK");
    }

    private void ShowError(string message)
    {
        ErrorLabel.Text = message;
        ErrorLabel.IsVisible = true;
    }
}