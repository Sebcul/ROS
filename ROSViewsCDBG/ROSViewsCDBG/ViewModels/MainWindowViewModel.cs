using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ROS.Services;
using ROS.Services.Helpers;
using ROS.Services.Services.Interfaces;
using ROSViewsCDBG.Helper_classes;
using ROSViewsCDBG.Views.UserControls;

namespace ROSViewsCDBG.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ICommand _editUserInfoCommand;
        private ICommand _userTeamsCommand;
        private ICommand _userResultsCommand;
        private ICommand _userRegattasCommand;
        private ICommand _userSocialEventsCommand;
        private ICommand _userClubsCommand;
        private ICommand _userInfoCommand;
        private readonly IUserService _serviceLocator;
        private string _userFullName;
        private object _selectedUserControl;
        private string _email;
        private int _userId;

        public MainWindowViewModel()
        {
            RegisterMessages();
            _serviceLocator = ServiceLocator.Instance.UserService;
        }

        public ICommand EditUserInfoCommand
        {
            get { return _editUserInfoCommand ?? (_editUserInfoCommand = new RelayCommand(OpenEditUserInfo)); }
        }

        public ICommand UserTeamsCommand
        {
            get { return _userTeamsCommand ?? (_userTeamsCommand = new RelayCommand(OpenUserTeams)); }
        }

        public ICommand UserResultsCommand
        {
            get { return _userResultsCommand ?? (_userResultsCommand = new RelayCommand(OpenUserResults)); }
        }

        public ICommand UserRegattasCommand
        {
            get { return _userRegattasCommand ?? (_userRegattasCommand = new RelayCommand(OpenUserRegattas)); }
        }

        public ICommand UserSocialEventsCommand
        {
            get { return _userSocialEventsCommand ?? (_userSocialEventsCommand = new RelayCommand(OpenUserEvents)); }
        }

        public ICommand UserClubsCommand
        {
            get { return _userClubsCommand ?? (_userClubsCommand = new RelayCommand(OpenUserClubs)); }
        }

        public ICommand UserInfoCommand
        {
            get { return _userInfoCommand ?? (_userInfoCommand = new RelayCommand(OpenUserInfo)); }
        }

        public object SelectedUserControl
        {
            get { return _selectedUserControl; }
            set
            {
                _selectedUserControl = value;
                OnPropertyChanged();
            }
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
        
        public string UserFullName
        {
            get { return _userFullName; }
            set
            {
                _userFullName = value;
                OnPropertyChanged();
            }
        }


        private void OpenEditUserInfo(object obj)
        {
            SelectedUserControl = new EditUserInfoView();
            Messenger.Default.Send<int>(_userId, "ToEditUserInfo");
        }

        private void OpenUserTeams(object obj)
        {
            SelectedUserControl = new ListUsersTeamsView();
        }

        private void OpenUserResults(object obj)
        {
            SelectedUserControl = new ListUsersResultsView();
        }

        private void OpenUserRegattas(object obj)
        {
            SelectedUserControl = new ListUsersRegattasView();
            Messenger.Default.Send<int>(_userId);
        }

        private void OpenUserInfo(object obj)
        {
            SelectedUserControl = new CreateRegattaView();
            Messenger.Default.Send<int>(_userId);
        }

        private void OpenUserEvents(object obj)
        {
            SelectedUserControl = new SocialEventInfoView();
        }

        private void OpenUserClubs(object obj)
        {
            SelectedUserControl = new ListUsersClubsView();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<string>(this, OnEmailReceived);
        }

        private void OnEmailReceived(string email)
        {
            Email = email;
            var user =_serviceLocator.FindUserByEmail(Email);
            UserFullName = user.FirstName + " " + user.LastName;
            _userId = user.Id;
        }
    }
}
