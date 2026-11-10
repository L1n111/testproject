using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using testproject.Models;
using testproject.Services;

namespace testproject.ViewModels
{
    internal class LoginPageViewModel : ViewModelBase
    {

        public ICommand SignInCommand { get; set; }
        public LoginPageViewModel()
        {
            SignInCommand = new Command(SignIn);
        }
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        private string _errorMessage;

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        private bool _isErrorVisible;
        public bool IsErrorVisible
        {
            get => _isErrorVisible;
            set
            {
                _isErrorVisible = value;
                OnPropertyChanged();
            }
        }

        private void SignIn()
        {
            var users = DataRepo.GetUsers();
            if (string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password))
            {
                ShowError("All fields are required.");
                return;
            }
            User foundUser = users.FirstOrDefault(u => u.Email.Equals(Email));
            if (foundUser != null && foundUser.Password == Password)
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
            ErrorMessage = message;
            IsErrorVisible = true; // Makes the label appear
        }
    }
}
