using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ROS.Services.Services.Interfaces;
using ROSPersistence.ROSDB;
using ROSViewsCDBG.Extensions;
using ROSViewsCDBG.Helper_classes;
using Ros.Services.Services.Interfaces;
using ROS.Services;

namespace ROSViewsCDBG.ViewModels
{
    public class EntryInfoViewModel : ViewModelBase
    {
        private int _no;
        private int _skipperId;
        private string _boatName;
        private int _regattaId;
        private int _totalSumPaid;
        private string _description;
        private string _regattaName;
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
        public string BoatName
        {
            get => _boatName;
            set { _boatName = value; OnPropertyChanged(); }
        }
        public int RegattaId
        {
            get => _regattaId;
            set { _regattaId = value; OnPropertyChanged(); }
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
        public string RegattaName
        {
            get => _regattaName;
            set { _regattaName = value; OnPropertyChanged(); }
        }
            
        }
    }

