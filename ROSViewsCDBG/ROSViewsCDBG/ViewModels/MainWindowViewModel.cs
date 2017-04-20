﻿using System;
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
        private ICommand _userTeamsCommand;
        private ICommand _userResultsCommand;
        private ICommand _userRegattasCommand;
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
            SelectedUserControl = new EditUserInfoView();
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
