using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSViewsCDBG.ViewModels
{
    public class EntryInfoViewModel : ViewModelBase
    {
        private string _boatName;
        private int _regattaId;
        private int _totalSumPaid;
        private string _description;
        private string _regattaName;
        private ObservableCollection<string> _registeredUsers;
                        
    }
}
        public string BoatName
        public int RegattaId
        public string RegattaName
        public ObservableCollection<string> RegisteredUsers
            set { _registeredUsers = value;OnPropertyChanged(); }
            
        }
    }
