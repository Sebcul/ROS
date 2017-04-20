using System.Windows;
using System.Windows.Controls;
using ROS.Services.Services;
using ROSViewsCDBG.UserControls;

namespace ROSViewsCDBG.Views.UserControls
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var service = new LoginService();
            service.ConfirmUserCredentials("bajs", "bajs");
            MainWindow main = new MainWindow();
            App.Current.MainWindow = main;
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
            main.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterUserView registerUserView = new RegisterUserView();
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Content = registerUserView;
            parentWindow.Height = 600;
            parentWindow.Width = 370;
        }
    }
}
