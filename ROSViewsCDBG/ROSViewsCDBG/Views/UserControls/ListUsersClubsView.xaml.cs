using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ROSViewsCDBG.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ListUsersClubsView.xaml
    /// </summary>
    public partial class ListUsersClubsView : UserControl
    {
        public ListUsersClubsView()
        {
            InitializeComponent();
        }

        public static event EventHandler<EventArgs> OpenClubInfoView;
        public static event EventHandler<EventArgs> OpenCreateClubView;

        public void Club_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenClubInfoView?.Invoke(this, new EventArgs());
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenCreateClubView?.Invoke(this, new EventArgs());
        }
    }
}
