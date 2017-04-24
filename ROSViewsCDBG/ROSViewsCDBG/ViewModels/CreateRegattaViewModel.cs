using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        private string _location;
        private string _startDate;
        private string _endDate;
        private string _startTime;
        private string _endTime;
        private string _description;
        private Club _hostClub;
        private ObservableCollection<User> _admins;
        private ObservableCollection<User> _hostClubMembers;
        private ObservableCollection<Event> _events;
        private ObservableCollection<Club> _clubs;
        private User _selectedMember;
        private Event _selectedEvent;
        private User _selectedAdmin;
        private ICommand _addAdminCommand;
        private ICommand _addEventCommand;
        private ICommand _deleteEventCommand;
        private ICommand _registerRegattaCommand;
        private ICommand _cancelCommand;


        public CreateRegattaViewModel()
        {
            _regattaService = ServiceLocator.Instance.RegattaService;
            _userService = ServiceLocator.Instance.UserService;

            InitializeCollections();

            RegisterMessages();
        }

        private void InitializeCollections()
        {
            _admins = new ObservableCollection<User>();
            _hostClubMembers = new ObservableCollection<User>();
            _events = new ObservableCollection<Event>();
            _clubs = new ObservableCollection<Club>();
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public ObservableCollection<User> Admins
        {
            get => _admins;
            set { _admins = value; OnPropertyChanged(); }
        }

        public string Location
        {
            get => _location;
            set { _location = value; OnPropertyChanged(); }
        }

        public string StartDate
        {
            get => _startDate;
            set { _startDate = value; OnPropertyChanged(); }
        }

        public string EndDate
        {
            get => _endDate;
            set { _endDate = value; OnPropertyChanged(); }
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
            set { _description = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Event> Events
        {
            get => _events;
            set { _events = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Club> Clubs
        {
            get => _clubs;
            set { _clubs = value; OnPropertyChanged(); }
        }

        public Club HostClub
        {
            get => _hostClub;
            set { _hostClub = value; OnPropertyChanged(); }
        }

        public ObservableCollection<User> HostClubMembers
        {
            get => _hostClubMembers;
            set { _hostClubMembers = value; OnPropertyChanged(); }
        }

        public User SelectedMember
        {
            get => _selectedMember;
            set { _selectedMember = value; OnPropertyChanged(); }
        }

        public Event SelectedEvent
        {
            get => _selectedEvent;
            set { _selectedEvent = value; OnPropertyChanged(); }
        }

        public User SelectedAdmin
        {
            get => _selectedAdmin;
            set { _selectedAdmin = value; OnPropertyChanged(); }
        }

        public ICommand AddAdminCommand => _addAdminCommand ?? new RelayCommand(AddAdminToList);

        private void AddAdminToList(object obj)
        {
            if (SelectedMember != null)
            {
                Admins.Add(SelectedMember);
                OnPropertyChanged("Admins");
            }
        }

        public ICommand DeleteAdminCommand => _deleteEventCommand ?? new RelayCommand(DeleteAdminFromList);

        private void DeleteAdminFromList(object obj)
        {
            if (SelectedAdmin != null)
            {
                Admins.Remove(SelectedAdmin);
                OnPropertyChanged("Admins");
            }
        }

        public ICommand AddEventCommand => _addEventCommand ?? new RelayCommand(AddEventToList);

        private void AddEventToList(object obj)
        {

        }

        public ICommand DeleteEventCommand => _deleteEventCommand ?? new RelayCommand(DeleteEventFromList);

        private void DeleteEventFromList(object obj)
        {

        }

        public ICommand RegisterRegattaCommand => _registerRegattaCommand ?? new RelayCommand(RegisterRegatta);

        private void RegisterRegatta(object obj)
        {
            var regatta = new Regatta()
            {
                Active = true,
                Name = Name,
                Club = HostClub,
                Description = Description,
                StartTime = GetStartDateTime(),
                EndTime = GetEndDateTime(),
                Entries = new List<Entry>(),
                Events = Events,
                Location = Location,
                RegattasFees = new Collection<RegattasFee>(),
                ResponsibleRegattaMembers = new List<ResponsibleRegattaMember>()
            };
            _regattaService.AddRegatta(regatta);

            Messenger.Default.Send("message", "SetSelectedUserControlToNull");
        }

        private DateTime GetStartDateTime()
        {
            var splitStartDate = StartDate.Split('-');
            var splitStartTime = StartTime.Split(':');

            return new DateTime(int.Parse(splitStartDate[0]), int.Parse(splitStartDate[1]),
                int.Parse(splitStartDate[2]), int.Parse(splitStartTime[0]), int.Parse(splitStartTime[1]), 0);
        }

        private DateTime GetEndDateTime()
        {
            var splitEndDate = EndDate.Split('-');
            var splitEndTime = EndTime.Split(':');

            return new DateTime(int.Parse(splitEndDate[0]), int.Parse(splitEndDate[1]),
                int.Parse(splitEndDate[2]), int.Parse(splitEndTime[0]), int.Parse(splitEndTime[1]), 0);
        }

        public ICommand CancelCommand => _cancelCommand ?? new RelayCommand(CancelRegistration);


        private void CancelRegistration(object obj)
        {
            Messenger.Default.Send("message", "SetSelectedUserControlToNull");
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<int>(this, OnIdReceived);
        }

        private void OnIdReceived(int id)
        {
            var user = _userService.FindUserById(id);
            Clubs = user.Members.SelectMany(u => u.Clubs).ToObservableCollection();
            HostClub = Clubs[0];
            HostClubMembers = HostClub.Members.SelectMany(u => u.Users).ToObservableCollection();
        }
    }
}
