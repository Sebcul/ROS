using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ROS.Services.Helpers;
using ROS.Services.Services.Interfaces;
using ROSPersistence.ROSDB;
using ROSViewsCDBG.Extensions;
using ROSViewsCDBG.Helper_classes;

namespace ROSViewsCDBG.ViewModels
{
    public class CreateRegattaViewModel : ViewModelBase
    {
        private readonly IRegattaService _regattaService;
        private readonly IUserService _userService; 
        private string _name;
        private ObservableCollection<User> _admins;
        private string _location;
        private string _startDate;
        private string _endDate;
        private string _startTime;
        private string _endTime;
        private string _description;
        private ObservableCollection<User> _hostClubMembers;
        private ObservableCollection<Event> _events;
        private ObservableCollection<Club> _clubs;
        private Club _hostClub;
        private ICommand _addAdminCommand;
        private ICommand _addEventCommand;
        private ICommand _deleteEventCommand;
        private ICommand _registerRegattaCommand;
        private ICommand _cancelCommand;


        public CreateRegattaViewModel()
        {
            _regattaService = ServiceLocator.Instance.RegattaService;
            _userService = ServiceLocator.Instance.UserService;
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged();}
        }

        public ObservableCollection<User> Admins
        {
            get => _admins;
            set { _admins = value; OnPropertyChanged();} 
        }

        public string Location
        {
            get => _location;
            set { _location = value; OnPropertyChanged();}
        }

        public string StarDate
        {
            get => _startDate;
            set { _startDate = value; OnPropertyChanged();}
        }

        public string EndDate
        {
            get => _endDate;
            set { _endDate = value; OnPropertyChanged();}
        }

        public string StartTime
        {
            get => _startTime;
            set { _startTime = value; OnPropertyChanged(); }
        }
        public string EndTime
        {
            get => _endTime;
            set { _endTime = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged();}
        }

        public ObservableCollection<Event> Events
        {
            get => _events;
            set { _events = value; OnPropertyChanged();}
        }
    
        public ObservableCollection<Club> Clubs
        {
            get => _clubs;
            set { _clubs = value; OnPropertyChanged();}
        }
        public Club HostClub
        {
            get => _hostClub;
            set { _hostClub = value; OnPropertyChanged(); }
        }
        public ObservableCollection<User> HostClubMembers
        {
            get { return HostClub.Members.SelectMany(m => m.Users).ToObservableCollection(); }
            set { _hostClubMembers = value; OnPropertyChanged(); }
        }

        public ICommand AddAdminCommand => _addAdminCommand ?? new RelayCommand(AddAdminToList);

        private void AddAdminToList(object obj)
        {
            throw new NotImplementedException();
        }

        public ICommand DeleteAdminCommand => _deleteEventCommand ?? new RelayCommand(DeleteAdminFromList);

        private void DeleteAdminFromList(object obj)
        {
            throw new NotImplementedException();
        }

        public ICommand AddEventCommand => _addEventCommand ?? new RelayCommand(AddEventToList);

        private void AddEventToList(object obj)
        {
            throw new NotImplementedException();
        }

        public ICommand DeleteEventCommand => _deleteEventCommand ?? new RelayCommand(DeleteEventFromList);

        private void DeleteEventFromList(object obj)
        {
            throw new NotImplementedException();
        }

        public ICommand RegisterRegattaCommand => _registerRegattaCommand ?? new RelayCommand(RegisterRegatta);

        private void RegisterRegatta(object obj)
        {
            throw new NotImplementedException();
        }

        public ICommand CancelCommand => _cancelCommand ?? new RelayCommand(CancelRegistration);

        
        private void CancelRegistration(object obj)
        {
            throw new NotImplementedException();
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<string>(this, OnEmailReceived);
        }

        private void OnEmailReceived(string email)
        {
            var user = _userService.FindUserByEmail(email);
            Clubs = user.Members.SelectMany(u => u.Clubs).ToObservableCollection();


        }
    }
}
