using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ros.Services.Services.Interfaces;
using ROS.Services.Helpers;

namespace ROSViewsCDBG.ViewModels
{
    public class TeamInfoViewModel : ViewModelBase
    {
        private int _no, _boatId, _entryId, _skipperId;
        private string _name, _boatName, _description;
        private readonly ITeamService _teamService;

        public TeamInfoViewModel()
        {
            _teamService = ServiceLocator.Instance.TeamService;
        }

        public int No
        {
            get { return _no; }
            set
            {
                _no = value;
                OnPropertyChanged();
            }
        }

        public int BoatId
        {
            get { return _boatId; }
            set
            {
               _boatId = value;
                OnPropertyChanged(); 
            }
        }

        public string BoatName
        {
            get { return _boatName; }
            set { _boatName = value; OnPropertyChanged(); }
        }

        public int SkipperId
        {
            get { return _skipperId;  }
            set { _skipperId = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }

        public int EntryId {
            get { return _entryId; }
            set
            {
                _entryId = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

    }
}
