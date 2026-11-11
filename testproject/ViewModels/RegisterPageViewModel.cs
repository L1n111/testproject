using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using testproject.Services;

namespace testproject.ViewModels
{
    internal class RegisterPageViewModel : ViewModelBase
    {
        public ICommand RegisterCommand { get; set; }
        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(Register);
            BirthDate = DateTime.Today; // Default date
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
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

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged();
            }
        }

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
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

        private async void Register()
        {
            if (string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(ConfirmPassword))
            {
                ShowError("All fields are required.");
                return;
            }

            if (Password.Length < 6)
            {
                ShowError("Password must be at least 6 characters long.");
                return;
            }

            if (!Email.Contains("@") || !Email.Contains("."))
            {
                ShowError("Invalid email format.");
                return;
            }

            if (Password != ConfirmPassword)
            {
                ShowError("Passwords do not match.");
                return;
            }

            if (DataRepo.RegisterNewUser(Name, Email, Password, BirthDate))
            {
                await Shell.Current.DisplayAlert("Success", "Account created successfully!", " >~< ");
            }
            else
            {
                ShowError("User already exists");
            }
        }

        private void ShowError(string message)
        {
            ErrorMessage = message;
            IsErrorVisible = true; 
        }
    }
}
