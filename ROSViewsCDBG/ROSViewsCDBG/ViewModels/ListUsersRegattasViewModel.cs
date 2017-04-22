using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROS.Services;
using ROS.Services.Helpers;
using ROS.Services.Models;
using ROS.Services.Services.Interfaces;
using ROSPersistence.ROSDB;
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
                if (RegattaCollectionIsEmpty())
                {
                    var collection = new ObservableCollection<IRegattaUserRecord>();
                    var emptyRegatta = new NonExistingRegattaUserRecord();
                    emptyRegatta.Name = "Du har inte deltagit i några regattor.";

                    collection.Add(emptyRegatta);

                    return collection;;
                }

                return _regattasUserParticipatedIn;
            }
            set
            {
                _regattasUserParticipatedIn = value;
                OnPropertyChanged();
            }
        }

        private bool RegattaCollectionIsEmpty()
        {
            return _regattasUserParticipatedIn.Count == 0;
        }

        public ObservableCollection<IRegattaUserRecord> UsersUpcomingRegattas
        {
            get { return _usersUpcomingRegattas; }
            set
            {
                _usersUpcomingRegattas = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<IRegattaUserRecord> UsersOngoingRegattas
        {
            get { return _usersOngoingRegattas; }
            set
            {
                _usersOngoingRegattas = value;
                OnPropertyChanged();
            }
        }


        private void OnUserIdRecieved(int id)
        {
            _userId = id;
     
            
        }




        private class NonExistingRegattaUserRecord : IRegattaUserRecord
        {
            public string Name { get; set; }
            public string Location { get; }
            public string EndDate { get; }
            public string StartDate { get; }
        }
    }

  
}
