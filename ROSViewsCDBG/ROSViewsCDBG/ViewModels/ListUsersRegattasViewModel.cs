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

        private ObservableCollection<IRegattaUserRecord> _regattaUserRecords;

        private int _userId;


        public ListUsersRegattasViewModel()
        {
            Messenger.Default.Register<int>(this, OnUserIdRecieved);

            _regattaService = ServiceLocator.Instance.RegattaService;

        }


        public ObservableCollection<IRegattaUserRecord> RegattaUserRecords
        {
            get
            {
                return _regattaUserRecords;
            }

            set
            {
                _regattaUserRecords = value;
                OnPropertyChanged();
            }
        }



        private void OnUserIdRecieved(int id)
        {
            _userId = id;
            _regattaUserRecords = new List<IRegattaUserRecord>().ToObservableCollection();
            _regattaUserRecords.Add(new Record());
            _regattaUserRecords.Add(new Record());
            _regattaUserRecords.Add(new Record());
            _regattaUserRecords.Add(new Record());

            RegattaUserRecords = _regattaUserRecords;

            //_regattaUserRecords = _regattaService.FindRegattasParticipatedInByUserId(_userId).ToObservableCollection();
        }


    }

    public class Record : IRegattaUserRecord
    {
        public string Name { get; } = "Regatta 1";
        public string EndDate { get; } = "24/7 2016";
        public string StartDate { get; } = "24/7 2016";
    }
}
