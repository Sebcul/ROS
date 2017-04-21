﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROS.Services;
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

        private ObservableCollection<IRegattaUserRecord> _regattaUserRecords;

        private User _user;


        public ListUsersRegattasViewModel()
        {
            Initialize();
        }


        public ObservableCollection<IRegattaUserRecord> RegattaUserRecords { get { return _regattaUserRecords; } }


        private void Initialize()
        {
            Messenger.Default.Register<User>(this, OnUserObjectRecieved);

            _regattaService = ServiceLocator.Instance.RegattaService;

            var regattas = _regattaService.FindRegattasParticipatedInByUserId(_user.Id);

            _regattaUserRecords = regattas.ToObservableCollection();
        }


        private void OnUserObjectRecieved(User user)
        {
            _user = user;
        }
    }
}
