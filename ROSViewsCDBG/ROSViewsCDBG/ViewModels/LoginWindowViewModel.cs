using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ROS.Services.Services;
using ROSViewsCDBG.Commands;
using ROSViewsCDBG.UserControls;
using ROSViewsCDBG.Views.UserControls;

namespace ROSViewsCDBG.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private ICommand _loginCommand;
        private ICommand _registerCommand;
        private string _email;

        public LoginWindowViewModel()
        {
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }


        public ICommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new RelayCommand(Login)); }
        }

        public ICommand RegisterCommand
        {
            get { return _registerCommand ?? (_registerCommand = new RelayCommand(Register)); }
        }

        private void Login(object obj)
        {
            var loginService = new LoginService();
            var passwordBox = (PasswordBox)obj;

            var checkLogin = loginService.ConfirmUserCredentials(Email, passwordBox.Password);
        }

        private void Register(object obj)
        {
            Window registerUserWindow = new Window
            {
                Title = "Register",
                Content = new RegisterUserView(),
                MaxHeight = 600,
                MaxWidth = 370,
                MinWidth = 370,
                MinHeight = 600
            };
            
            registerUserWindow.ShowDialog();
        }
    }
}
