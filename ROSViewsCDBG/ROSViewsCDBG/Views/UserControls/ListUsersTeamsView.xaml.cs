﻿using System;
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
using Projektet;
using ROSViewsCDBG.UserControls;

namespace ROSViewsCDBG.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ListUsersTeamsView.xaml
    /// </summary>
    public partial class ListUsersTeamsView : UserControl
    {
        public ListUsersTeamsView()
        {
            InitializeComponent();
        }
        public static event EventHandler<EventArgs> OpenTeamInfoView;
        public static event EventHandler<EventArgs> OpenRegattaInfoView;

        private void Team_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (OpenTeamInfoView != null)
                OpenTeamInfoView(this, new EventArgs());
        }

        private void Regatta_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (OpenRegattaInfoView != null)
                OpenRegattaInfoView(this, new EventArgs());
        }
    }
}
