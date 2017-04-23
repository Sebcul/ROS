using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROS.Services.Helpers;
using ROS.Services.Services.Interfaces;
using ROSViewsCDBG.Helper_classes;
using ROSViewsCDBG.Models;

namespace ROSViewsCDBG.ViewModels
{
    public class EditUserInfoViewModel : ViewModelBase
    {
        private string _firstName;
        private string _lastName;
        private ObservableCollection<string> _userPhoneNumbers;
        private ObservableCollection<UserAddress> _userAddresses;
        private IUserService _userService;
        private int _userId;
        private UserAddress _userAddress;

        public EditUserInfoViewModel()
        {
            RegisterMessages();
            _userPhoneNumbers = new ObservableCollection<string>();
            _userAddresses = new ObservableCollection<UserAddress>();
            _userService = ServiceLocator.Instance.UserService;
        }
        
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value; 
                OnPropertyChanged();
            }
        }
        
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> UserPhoneNumbers
        {
            get { return _userPhoneNumbers; }
            set
            {
                _userPhoneNumbers = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UserAddress> UserAddresses
        {
            get { return _userAddresses; }
            set
            {
                _userAddresses = value;
                OnPropertyChanged();
            }
        }

        private void OnUserIdReceived(int userId)
        {
            _userId = userId;
            InitializeValues();
        }

        private void InitializeValues()
        {
            var user =_userService.GetAllUsers().FirstOrDefault(x => x.Id == _userId);
            FirstName = user.FirstName;
            LastName = user.LastName;
            foreach (var number in user.UserContactInformations.FirstOrDefault().UserPhoneNumbers)
            {
                UserPhoneNumbers.Add(number.PhoneNumber);
            }
            foreach (var address in user.UserContactInformations)
            {
                _userAddress = new UserAddress() {Country = address.Country, City = address.City, Street = address.Street, Zip_Code = address.Zip_Code };
                UserAddresses.Add(_userAddress);
            }
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<int>(this, OnUserIdReceived, "ToEditUserInfo");
        }
    }
}
