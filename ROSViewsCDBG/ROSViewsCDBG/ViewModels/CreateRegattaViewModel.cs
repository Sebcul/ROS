using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROSPersistence.ROSDB;

namespace ROSViewsCDBG.ViewModels
{
    public class CreateRegattaViewModel : ViewModelBase
    {
        private string _name;
        private ObservableCollection<IUser> _admins;
        private string _location;
        private DateTime _starTime;
        private DateTime _endTime;
        private string _description;
        private ObservableCollection<Event> _events;
        private ObservableCollection<IClub> _clubs;

        public CreateRegattaViewModel()
        {
            
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged();}
        }

        public ObservableCollection<IUser> Admins
        {
            get => _admins;
            set { _admins = value; OnPropertyChanged();} 
        }

        public string Location
        {
            get => _location;
            set { _location = value; OnPropertyChanged();}
        }

        public DateTime StarTime
        {
            get => _starTime;
            set { _starTime = value; OnPropertyChanged();}
        }

        public DateTime EndTime
        {
            get => _endTime;
            set { _endTime = value; OnPropertyChanged();}
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

        
        public ObservableCollection<IClub> Clubs
        {
            get => _clubs;
            set { _clubs = value; OnPropertyChanged();}
        }

    }
}
