using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using Projektet;
using ROSPersistence.Repository;
using ROSPersistence.ROSDB;
using ROSViewsCDBG.UserControls;
using ROSViewsCDBG.Views.UserControls;

namespace ROSViewsCDBG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListUsersTeamsView.OpenRegattaInfoView += MyUserControl_OpenScreen2;
            ListUsersTeamsView.OpenTeamInfoView += MyUserControl_OpenScreen1;
            ListUsersResultsView.OpenRaceInfoView += OpenRace;
            ListUsersClubsView.OpenClubInfoView += MyUserControl_OpenScreen3;
            ClubAdminView.OpenCreateRegattaView += CreateRegatta_Click;
            ListUsersClubsView.OpenCreateClubView += CreateClub;
            ClubInfoView.OpenCreateClubView += CreateClub;
            RegattaInfoView.OpenCreateEntryView += CreateEntry;
        }

        private void CreateEntry(object sender, EventArgs e)
        {
            UcContentControl.Content = new CreateEntryView();
        }

        private void CreateClub(object sender, EventArgs e)
        {
            UcContentControl.Content = new CreateClubView();
        }

        private void OpenRace(object sender, EventArgs e)
        {
            UcContentControl.Content = new DistanceMeasuredRaceEventInfoView();
        }

        void MyUserControl_OpenScreen2(object sender, EventArgs e)
        {
            UcContentControl.Content = new RegattaInfoView();
        }

        void MyUserControl_OpenScreen1(object sender, EventArgs e)
        {
            UcContentControl.Content = new TeamInfoView();
        }

        void MyUserControl_OpenScreen3(object sender, EventArgs e)
        {
            UcContentControl.Content = new ClubInfoView();
        }

        private void UserProfileButton_Click(object sender, RoutedEventArgs e)
        {
            UcContentControl.Content = new EditUserInfoView();
        }

        private void TeamsButton_Click(object sender, RoutedEventArgs e)
        {
            UcContentControl.Content = new ListUsersTeamsView();
        }

        private void ResultsButton_Click(object sender, RoutedEventArgs e)
        {
            UcContentControl.Content = new ListUsersResultsView();
        }

        private void RegattasButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EventsButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ClubsButton_Click(object sender, RoutedEventArgs e)
        {
            UcContentControl.Content = new ListUsersClubsView();
        }

        private void CreateRegatta_Click(object sender, EventArgs e)
        {
            UcContentControl.Content = new CreateRegattaView();
        }
    }
}
