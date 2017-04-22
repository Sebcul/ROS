﻿using Ros.Services.Services.Interfaces;
using ROS.Services;
using ROSPersistence.ROSDB;
using System;
using System.Collections.ObjectModel;

namespace ROSViewsCDBG.ViewModels
{
    public class EntryInfoViewModel : ViewModelBase
    {
        private int _no;
        private int _skipperId;
        private int _totalSumPaid;
        private string _description;
        private string _regattaName;
        private ObservableCollection<RegisteredUser> _registeredUsers;
        private readonly IEntryService _entryService;

        public EntryInfoViewModel()
        {
            _entryService = ServiceLocator.Instance.EntryService;

        }

        public int No
        {
            get => _no;
            set { _no = value; OnPropertyChanged(); }
        }
        public int SkipperId
        {
            get => _skipperId;
            set { _skipperId = value; OnPropertyChanged(); }
        }
        public Boat BoatName
        {
            get => _boatName;
            set { _boatName = value; OnPropertyChanged(); }
        }
        public Regatta RegattaId
        {
        get => _regattaId;
        set {_regattaId = value; OnPropertyChanged(); }
        }
        public int TotalSumPaid
        {
            get => _totalSumPaid;
            set { _totalSumPaid = value; OnPropertyChanged(); }
        }
        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }
        public Regatta RegattaName
        {
        get => _regattaName;
        set {_regattaName = value; OnPropertyChanged(); }
        }
        public ObservableCollection<RegisteredUser> RegisteredUsers
        {
        get => _registeredUsers;
        set {_registeredUsers = value; OnPropertyChanged(); }
            

        }
    }
}

