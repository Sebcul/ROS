using System.Collections.ObjectModel;
using System.Windows;
using ROS.Services.Helpers;
using ROS.Services.Models;
using ROS.Services.Services.Interfaces;
using ROSViewsCDBG.Extensions;
using ROSViewsCDBG.Helper_classes;

namespace ROSViewsCDBG.ViewModels
{

    public class ListUsersRegattasViewModel : ViewModelBase
    {
        private IRegattaService _regattaService;


        private ObservableCollection<IRegattaUserRecord> _regattasUserParticipatedIn;
        private ObservableCollection<IRegattaUserRecord> _usersUpcomingRegattas;
        private ObservableCollection<IRegattaUserRecord> _usersOngoingRegattas;

        private Visibility _visibilityOfVisibilityOfUserHasNoParticipationRecordsMessage;
        private Visibility _visibilityOfUserHasNoUpcomingRegattasMessage;
        private Visibility _visibilityOfUserHasNoOngoingRegattasMessage;


        private int _userId;


        public ListUsersRegattasViewModel()
        {
            Messenger.Default.Register<int>(this, OnUserIdRecieved);

            _regattaService = ServiceLocator.Instance.RegattaService;

            InitializeCollections();
        }

        private void InitializeCollections()
        {
            RegattasUserParticipatedIn = _regattaService.FindRegattasParticipatedInByUserId(_userId).ToObservableCollection();
            UsersOngoingRegattas = _regattaService.FindUsersOngoingRegattasById(_userId).ToObservableCollection();
            UsersUpcomingRegattas = _regattaService.FindUsersUpcomingRegattasByUserId(_userId).ToObservableCollection();
        }


        public ObservableCollection<IRegattaUserRecord> RegattasUserParticipatedIn
        {
            get
            {
                VisibilityOfUserHasNoRecordOfParticipationInRegattasMessage = RegattaCollectionIsEmpty(_regattasUserParticipatedIn)
                    ? Visibility.Visible : Visibility.Collapsed;
                return _regattasUserParticipatedIn;
            }
            set
            {
                _regattasUserParticipatedIn = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IRegattaUserRecord> UsersUpcomingRegattas
        {
            get
            {
                VisibilityOfUserHasNoUpcomingRegattasMessage = RegattaCollectionIsEmpty(_usersUpcomingRegattas) 
                    ? Visibility.Visible : Visibility.Collapsed;

                return _usersUpcomingRegattas;
            }
            set
            {
                _usersUpcomingRegattas = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IRegattaUserRecord> UsersOngoingRegattas
        {
            get
            {
                VisibilityOfUserHasNoOngoingRegattasMessage = RegattaCollectionIsEmpty(_usersOngoingRegattas)
                    ? Visibility.Visible : Visibility.Collapsed;
                return _usersOngoingRegattas;
            }
            set
            {
                _usersOngoingRegattas = value;
                OnPropertyChanged();
            }
        }
        




        public Visibility VisibilityOfUserHasNoUpcomingRegattasMessage
        {
            get { return _visibilityOfUserHasNoUpcomingRegattasMessage; }
            set
            {
                _visibilityOfUserHasNoUpcomingRegattasMessage = value;
                OnPropertyChanged();
            }
        }


        public Visibility VisibilityOfUserHasNoOngoingRegattasMessage
        {
            get { return _visibilityOfUserHasNoOngoingRegattasMessage; }
            set
            {
                _visibilityOfUserHasNoOngoingRegattasMessage = value;
                OnPropertyChanged();
            }
        }

        public Visibility VisibilityOfUserHasNoRecordOfParticipationInRegattasMessage
        {
            get { return _visibilityOfVisibilityOfUserHasNoParticipationRecordsMessage; }
            set
            {
                _visibilityOfVisibilityOfUserHasNoParticipationRecordsMessage = value;
                OnPropertyChanged();
            }
        }


        private void OnUserIdRecieved(int id)
        {
            _userId = id;
        }


        private bool RegattaCollectionIsEmpty(ObservableCollection<IRegattaUserRecord> regattaCollection)
        {
            return regattaCollection.Count == 0;
        }

    }

  
}
