using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicles.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string _password;
        private bool _isrunning;
        private bool _isenabled;
        private DelegateCommand _logincommand;


        //el constructor navigation sirv para pasar de pagina y parametros
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Login";
            IsEnabled = true;
        }

        public DelegateCommand LoginCommand
        {
            get
            {
                if (_logincommand == null)
                {
                    _logincommand = new DelegateCommand(Login);
                }
                return _logincommand;
            }
        }

        public string Email { get; set; }
        public string Password 
        { 
           get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsRunning
        {
            get => _isrunning;
            set => SetProperty(ref _isrunning, value);
        }

        public bool IsEnabled
        {
            get => _isenabled;
            set => SetProperty(ref _isenabled, value);
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter an email", "Accept");
            }
            if (string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a password", "Accept");
            }

            await App.Current.MainPage.DisplayAlert("Ok", "Fuck Yeah!!!", "Accept");
        }

    }
}
