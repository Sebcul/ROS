using Ros.Services.Services.Interfaces;
using ROS.Services;
using ROSPersistence.ROSDB;
using System;
using System.Collections.ObjectModel;

namespace ROSViewsCDBG.ViewModels
{
    public class EntryInfoViewModel : ViewModelBase
    {
        private string _boatName;
        private int _regattaId;
        private int _no;
        private int _totalSumPaid;
        private string _regattaName;
        private ObservableCollection<string> _registeredUsers;
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
        public string BoatName
        {
            get => _boatName;
            set {_boatName = value; OnPropertyChanged(); }
        }
        public int RegattaId
        {
        get => _regattaId;
        set {_regattaId = value; OnPropertyChanged(); }
        }
        public string RegattaName
        {
        get => _regattaName;
        set {_regattaName = value; OnPropertyChanged(); }
        }
        public ObservableCollection<string> RegisteredUsers
        {
        get => _registeredUsers;
        set {_registeredUsers = value; OnPropertyChanged(); }
        }

        public int TotalSumPaid
        {
            get => _totalSumPaid;
            set { _totalSumPaid = value; OnPropertyChanged(); }
        }
        

    }
}


