using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ROSViewsCDBG.Views.UserControls;

namespace ROSViewsCDBG.UserControls
{
    /// <summary>
    /// Interaction logic for RegisterUserView.xaml
    /// </summary>
    public partial class RegisterUserView : UserControl
    {
        public RegisterUserView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Content = new LoginView();
            parentWindow.Height = 350;
            parentWindow.Width = 525;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            App.Current.MainWindow = main;
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
            main.Show();
        }
    }
}
