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
using ROSViewsCDBG.Helper_classes;
using ROSViewsCDBG.Models;
using ROSViewsCDBG.Views.Windows;

namespace ROSViewsCDBG.ViewModels
{
    public class EditUserInfoViewModel : ViewModelBase
    {
        private ICommand _saveCommand;
        private ICommand _addPhoneNumberCommand;
        private ICommand _removePhoneNumberCommand;
        private ICommand _addAddressCommand;
        private ICommand _removeAddressCommand;
        private string _firstName;
        private string _lastName;
        private string _currentPassword;
        private string _newPassword;
        private string _repeatNewPassword;
        private ObservableCollection<string> _userPhoneNumbers;
        private ObservableCollection<UserAddress> _userAddresses;
        private IUserService _userService;
        private IPasswordService _passwordService;
        private int _userId;
        private UserAddress _userAddress;

        public EditUserInfoViewModel()
        {
            RegisterMessages();
            _userPhoneNumbers = new ObservableCollection<string>();
            _userAddresses = new ObservableCollection<UserAddress>();
            _userService = ServiceLocator.Instance.UserService;
            _passwordService = ServiceLocator.Instance.PasswordService;
        }
        public ICommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new RelayCommand(SaveChanges)); }
        }

        public ICommand AddPhoneNumberCommand
        {
            get { return _addPhoneNumberCommand ?? (_addPhoneNumberCommand = new RelayCommand(OpenAddPhoneNumberWindow)); }
        }

        public ICommand RemovePhoneNumberCommand
        {
            get { return _removePhoneNumberCommand ?? (_removePhoneNumberCommand = new RelayCommand(RemovePhoneNumber)); }
        }

        public ICommand AddAddressCommand
        {
            get { return _addAddressCommand ?? (_addAddressCommand = new RelayCommand(OpenAddAddressWindow)); }
        }

        public ICommand RemoveAddressCommand
        {
            get { return _removeAddressCommand ?? (_removeAddressCommand = new RelayCommand(RemoveAddress)); }
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

        public string CurrentPassword
        {
            set
            {
                _currentPassword = value;
                OnPropertyChanged();
            }
        }
        
        public string NewPassword
        {
            set
            {
                _newPassword = value;
                OnPropertyChanged();
            }
        }

        public string RepeatNewPassword
        {
            set
            {
                _repeatNewPassword = value;
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

        private void SaveChanges(object obj)
        {
            var user = _userService.GetAllUsers().FirstOrDefault(x => x.Id == _userId);

            if (CheckPasswordIsValidForChange())
            {
                _passwordService.UpdatePassword(user.Id, _currentPassword, _newPassword);
            }

            user.FirstName = FirstName;
            user.LastName = LastName;

            user = _userService.AddContactInformationType(user);
            _userService.UpdateUser(user);

        }

        private void OpenAddPhoneNumberWindow(object obj)
        {
            new AddPhoneNumberWindow().ShowDialog();
        }

        private void RemovePhoneNumber(object obj)
        {

        }

        private void OpenAddAddressWindow(object obj)
        {
            new AddUserAddressWindow().ShowDialog();
        }

        private void RemoveAddress(object obj)
        {

        }

        private bool CheckPasswordIsValidForChange()
        {
            return !string.IsNullOrEmpty(_currentPassword) && _newPassword.Equals(_repeatNewPassword);
        }

        private void OnUserIdReceived(int userId)
        {
            _userId = userId;
            InitializeValues();
        }

        private void OnNewPhoneNumberReceived(Dictionary<string, string> phoneNumberAndType)
        {
            var user = _userService.GetAllUsers().FirstOrDefault(x => x.Id == _userId);

            foreach (var keyValuePair in phoneNumberAndType)
            {
                UserPhoneNumbers.Add(keyValuePair.Value);
                user.UserContactInformations.FirstOrDefault().UserPhoneNumbers.Add(new UserPhoneNumber() {Active = true, Description = null,
                    PhoneNumber = keyValuePair.Value, UserContactInformationId = user.UserContactInformations.FirstOrDefault().Id});
            }
        }

        private void OnNewAddressReceived(UserAddress address)
        {
            var user = _userService.GetAllUsers().FirstOrDefault(x => x.Id == _userId);

            UserAddresses.Add(address);

            if (address.BoxNo == 0)
            {
                address.BoxNo = null;
            }
            var contactInformationType = new ContactInformationType() { Active = true, Type = address.AddressType, Description = address.Description};

            user.UserContactInformations.Add(new UserContactInformation() {Active = true, BoxNo = address.BoxNo, City = address.City,
                ContactInformationTypes = new List<ContactInformationType>() { contactInformationType }, Country = address.Country, Street = address.Street, Zip_Code = address.Zip_Code});
        }

        private void InitializeValues()
        {
            var user = _userService.GetAllUsers().FirstOrDefault(x => x.Id == _userId);

            SetUserFullNameForDisplay(user);
            AddUserPhoneNumbersToDisplayList(user);
            AddUserAddressInfoToDisplayList(user);
        }

        private void AddUserAddressInfoToDisplayList(User user)
        {
            foreach (var address in user.UserContactInformations)
            {
                _userAddress = new UserAddress() { Country = address.Country, City = address.City, Street = address.Street, Zip_Code = address.Zip_Code, AddressType = address.ContactInformationTypes.FirstOrDefault().Type};
                UserAddresses.Add(_userAddress);
            }
        }

        private void AddUserPhoneNumbersToDisplayList(User user)
        {
            foreach (var number in user.UserContactInformations.FirstOrDefault().UserPhoneNumbers)
            {
                UserPhoneNumbers.Add(number.PhoneNumber);
            }
        }

        private void SetUserFullNameForDisplay(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<int>(this, OnUserIdReceived, "ToEditUserInfo");
            Messenger.Default.Register<Dictionary<string, string>>(this, OnNewPhoneNumberReceived);
            Messenger.Default.Register<UserAddress>(this, OnNewAddressReceived, "AddressSent");
        }
    }
}
