using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ROS.Services;
using ROS.Services.Helpers;
using ROS.Services.Services;
using ROS.Services.Services.Interfaces;
using ROSViewsCDBG.Helper_classes;
using ROSViewsCDBG.UserControls;
using ROSViewsCDBG.Views.Windows;
using ServiceLocator = ROS.Services.Helpers.ServiceLocator;

namespace ROSViewsCDBG.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private ICommand _loginCommand;
        private ICommand _registerCommand;
        private string _email;
        private readonly ILoginService _loginService;

        public LoginWindowViewModel()
        {
            _loginService = ServiceLocator.Instance.LoginService;

            Email = "";
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
            var passwordBox = (PasswordBox)obj;
            bool checkLogin = _loginService.ConfirmUserCredentials(Email, passwordBox.Password);

            if (checkLogin)
            {
                var mainWindow = new MainWindow();
                Messenger.Default.Send(Email);
                mainWindow.Show();
                CloseWindow();
            }
        }

        private static void CloseWindow()
        {
            Window window = Application.Current.Windows
                .OfType<Window>().FirstOrDefault(w => w.Name == "LoginWindowView");
            window?.Close();
        }

        private void Register(object obj)
        {
            var registerUserWindow = new RegisterUserWindow();
            registerUserWindow.ShowDialog();
            //Window registerUserWindow = new Window
            //{
            //    Title = "Register",
            //    Content = new RegisterUserView(),
            //    MaxHeight = 600,
            //    MaxWidth = 370,
            //    MinWidth = 370,
            //    MinHeight = 600
            //};
            //registerUserWindow.ShowDialog();
        }
    }
}
