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

namespace ROSViewsCDBG.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ListUsersResultsView.xaml
    /// </summary>
    public partial class ListUsersResultsView : UserControl
    {
        public ListUsersResultsView()
        {
            InitializeComponent();
        }
        public static event EventHandler<EventArgs> OpenRaceInfoView;

        private void Race_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (OpenRaceInfoView != null)
                OpenRaceInfoView(this, new EventArgs());
        }
    }
}
