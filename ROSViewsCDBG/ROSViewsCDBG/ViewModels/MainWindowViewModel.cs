using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ROSViewsCDBG.Helper_classes;
using ROSViewsCDBG.Views.UserControls;

namespace ROSViewsCDBG.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ICommand _editUserInfoCommand;
        private ICommand _myTeamsCommand;
        private ICommand _userResultsCommand;
        private object _selectedUserControl;
        private string _email;

        public MainWindowViewModel()
        {
            RegisterMessages();
        }

        public ICommand EditUserInfoCommand
        {
            get { return _editUserInfoCommand ?? (_editUserInfoCommand = new RelayCommand(OpenEditUserInfo)); }
        }

        public ICommand MyTeamsCommand
        {
            get { return _myTeamsCommand ?? (_myTeamsCommand = new RelayCommand(OpenMyTeams)); }
        }

        public ICommand UserResultsCommand
        {
            get { return _userResultsCommand ?? (_userResultsCommand = new RelayCommand(OpenUserResults)); }
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

        private void OpenEditUserInfo(object obj)
        {
            var editUserInfoWindow = new EditUserInfoView();
            SelectedUserControl = editUserInfoWindow;
        }

        private void OpenMyTeams(object obj)
        {
            var teamsForUserWindow = new ListUsersTeamsView();
            SelectedUserControl = teamsForUserWindow;
        }

        private void OpenUserResults(object obj)
        {
            var resultsForUserWindow = new ListUsersResultsView();
            SelectedUserControl = resultsForUserWindow;
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<string>(this, OnEmailReceived);
        }

        private void OnEmailReceived(string email)
        {
            Email = email;
        }
    }
}
