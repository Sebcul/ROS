using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROSViewsCDBG.Helper_classes;

namespace ROSViewsCDBG.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {


        public MainWindowViewModel()
        {
            RegisterMessages();
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<string>(this, OnEmailReceived);
        }

        private void OnEmailReceived(string email)
        {
            Email = email;
        }
    }
}
