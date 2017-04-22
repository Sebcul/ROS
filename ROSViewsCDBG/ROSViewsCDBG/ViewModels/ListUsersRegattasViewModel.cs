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

        private Visibility _visibilityOfUsersRegattaParticipationContainer;
        private Visibility _visibilityOfUsersUpcomingRegattasContainer;

        private Visibility _visibilityOfNoInformationAboutUsersRegattasMessage;

        private Visibility _visibilityOfUsersOngoingRegattasLabelHeader;

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
            RegattasUserParticipatedIn = new ObservableCollection<IRegattaUserRecord>();
            UsersOngoingRegattas = new ObservableCollection<IRegattaUserRecord>();
            UsersUpcomingRegattas = new ObservableCollection<IRegattaUserRecord>();
        }


        public ObservableCollection<IRegattaUserRecord> RegattasUserParticipatedIn
        {
            get
            {
                VisibilityOfUsersParticipationRecordsContainer = !RegattaCollectionIsEmpty(_regattasUserParticipatedIn)
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
                VisibilityOfUsersUpcomingRegattasContainer = !RegattaCollectionIsEmpty(_usersUpcomingRegattas) 
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
        




        public Visibility VisibilityOfUsersUpcomingRegattasContainer
        {
            get { return _visibilityOfUsersUpcomingRegattasContainer; }
            set
            {
                _visibilityOfUsersUpcomingRegattasContainer = value;
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

        public Visibility VisibilityOfUsersParticipationRecordsContainer
        {
            get { return _visibilityOfUsersRegattaParticipationContainer; }
            set
            {
                _visibilityOfUsersRegattaParticipationContainer = value;
                OnPropertyChanged();
            }
        }

        public Visibility VisibilityOfUsersOngoingRegattasLabelHeader
        {
            get { return _visibilityOfUsersOngoingRegattasLabelHeader; }
            set
            {
                _visibilityOfUsersOngoingRegattasLabelHeader = value;
                OnPropertyChanged();
            }
        }

        public Visibility VisibilityOfNoInformationAboutUsersRegattasMessage
        {
            get { return _visibilityOfNoInformationAboutUsersRegattasMessage; }
            set
            {
                _visibilityOfNoInformationAboutUsersRegattasMessage = value;
                OnPropertyChanged();
            }
        }



        private void OnUserIdRecieved(int id)
        {
            _userId = id;

            RegattasUserParticipatedIn = _regattaService.FindRegattasParticipatedInByUserId(_userId).ToObservableCollection();
            UsersOngoingRegattas = _regattaService.FindUsersOngoingRegattasById(_userId).ToObservableCollection();
            UsersUpcomingRegattas = _regattaService.FindUsersUpcomingRegattasByUserId(_userId).ToObservableCollection();

            VisibilityOfNoInformationAboutUsersRegattasMessage = Visibility.Collapsed;

            if (AllRegattaCollectionsAreEmpty())
            {
                HideOngoingRegattasContent();
                DisplayNoInformationAboutUsersRegattasMessage();

            }



        }

        private bool RegattaCollectionIsEmpty(ObservableCollection<IRegattaUserRecord> regattaCollection)
        {
            return regattaCollection.Count == 0;
        }

        private bool AllRegattaCollectionsAreEmpty()
        {
            return RegattaCollectionIsEmpty(_regattasUserParticipatedIn)
                            && RegattaCollectionIsEmpty(_usersUpcomingRegattas)
                            && RegattaCollectionIsEmpty(_usersOngoingRegattas);
        }


        private void HideOngoingRegattasContent()
        {
            VisibilityOfUsersOngoingRegattasLabelHeader = Visibility.Collapsed;
            VisibilityOfUserHasNoOngoingRegattasMessage = Visibility.Collapsed;

        }

        private void DisplayNoInformationAboutUsersRegattasMessage()
        {
            VisibilityOfNoInformationAboutUsersRegattasMessage = Visibility.Visible;
        }


    }

  
}
