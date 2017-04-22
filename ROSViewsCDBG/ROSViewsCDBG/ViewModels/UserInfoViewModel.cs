using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ROS.Services.Helpers;
using ROS.Services.Services.Interfaces;
using ROSPersistence.ROSDB;
using ROSViewsCDBG.Extensions;
using ROSViewsCDBG.Helper_classes;

namespace ROSViewsCDBG.ViewModels
{
    public class UserInfoViewModel : ViewModelBase
    {
        private string _name;
        private ObservableCollection<string> _clubs;
        private ObservableCollection<string> _contactInformation;
        private readonly IUserService _service;

        public UserInfoViewModel()
        {
            _service = ServiceLocator.Instance.UserService;
            RegisterMessages();
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> Clubs
        {
            get => _clubs;
            set { _clubs = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> ContactInformation
        {
            get => _contactInformation;
            set { _contactInformation = value; OnPropertyChanged(); }
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<string>(this, OnEmailReceived);
        }

        private void OnEmailReceived(string email)
        {
            var user = _service.GetUserInfoDisplayObjectByEmail(email);

            Name = user.Name;
            Clubs = user.Clubs.ToObservableCollection();
            ContactInformation = ContactInformationToString(user.ContactInformation);
        }

        private ObservableCollection<string> ContactInformationToString(IEnumerable<UserContactInformation> contactInformation)
        {
            var contactCollection = new ObservableCollection<string>();

            foreach (var contact in contactInformation)
            { 
                var boxNo = contact.BoxNo.HasValue ? $"BOX: {contact.BoxNo}\n" : "";
                var contactInformationType = contact.ContactInformationTypes.Select(u => u.Type).First();

                contactCollection.Add($"{contactInformationType}\n{contact.Street}\n" +
                                      $"{boxNo}{contact.City}\n{contact.Zip_Code}\n{contact.Country}\n\n");
            }
            return contactCollection;
        }
    }
}
