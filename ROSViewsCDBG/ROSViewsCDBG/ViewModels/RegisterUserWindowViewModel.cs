using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ROS.Services;
using ROS.Services.Helpers;
using ROS.Services.Services.Interfaces;
using ROSPersistence.ROSDB;
using ROSViewsCDBG.Helper_classes;
using ROSViewsCDBG.Models;
using ROSViewsCDBG.Views.Windows;

namespace ROSViewsCDBG.ViewModels
{
    public class RegisterUserWindowViewModel : ViewModelBase
    {
        //TODO: Check if ContactInformationType already exists in database, will throw an exception if it already exists

        private ICommand _addPhoneNumberCommand;
        private ICommand _removePhoneNumberCommand;
        private ICommand _addAddressCommand;
        private ICommand _removeAddressCommand;
        private ICommand _registerUserCommand;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _passwordRepeat;
        private ObservableCollection<string> _phoneNumbers;
        private ObservableCollection<UserAddress> _listOfUserAddresses;
        private string _selectedPhoneNumber;
        private UserAddress _selectedAddress;
        private Dictionary<string, string> _phoneNumbersTypeAndPhoneNumber;
        private UserAddress _address;
        private IAddUserService _addUserService;
        private IUserService _userService;

        public RegisterUserWindowViewModel()
        {
            _phoneNumbers = new ObservableCollection<string>();
            _listOfUserAddresses = new ObservableCollection<UserAddress>();
            _phoneNumbersTypeAndPhoneNumber = new Dictionary<string, string>();
            _addUserService = ServiceLocator.Instance.AddUserService;
            _userService = ServiceLocator.Instance.UserService;
            RegisterMessages();
        }

        public ICommand AddPhoneNumberCommand
        {
            get { return _addPhoneNumberCommand ?? (_addPhoneNumberCommand = new RelayCommand(AddPhoneNumber)); }
        }

        public ICommand RemovePhoneNumberCommand
        {
            get { return _removePhoneNumberCommand ?? (_removePhoneNumberCommand = new RelayCommand(RemovePhoneNumber)); }
        }

        public ICommand AddAddressCommand
        {
            get { return _addAddressCommand ?? (_addAddressCommand = new RelayCommand(AddAddress)); }
        }

        public ICommand RemoveAddressCommand
        {
            get { return _removeAddressCommand ?? (_removeAddressCommand = new RelayCommand(RemoveAddress)); }
        }

        public ICommand RegisterUserCommand
        {
            get { return _registerUserCommand ?? (_registerUserCommand = new RelayCommand(RegisterUser)); }
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

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value; 
                OnPropertyChanged();
            }
        }

        public string PasswordRepeat
        {
            get { return _passwordRepeat; }
            set
            {
                _passwordRepeat = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> PhoneNumbers
        {
            get { return _phoneNumbers; }
            set
            {
                _phoneNumbers = value;
                OnPropertyChanged();
            }
        }

        public string SelectedPhoneNumber
        {
            get { return _selectedPhoneNumber; }
            set
            {
                _selectedPhoneNumber = value; 
                OnPropertyChanged();
            }
        }

        public UserAddress SelectedAddress
        {
            get { return _selectedAddress; }
            set
            {
                _selectedAddress = value; 
                OnPropertyChanged();
            }
        }


        public UserAddress Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UserAddress> ListOfUserAddresses
        {
            get { return _listOfUserAddresses; }
            set
            {
                _listOfUserAddresses = value;
                OnPropertyChanged();
            }
        }

        private void AddPhoneNumber(object obj)
        {
            new AddPhoneNumberWindow().ShowDialog();
        }

        private void RemovePhoneNumber(object obj)
        {
            var numberToRemove = _phoneNumbersTypeAndPhoneNumber.FirstOrDefault(x => x.Value == SelectedPhoneNumber).Key;
            if (!String.IsNullOrEmpty(numberToRemove))
            {
                _phoneNumbersTypeAndPhoneNumber.Remove(numberToRemove);
                PhoneNumbers.Remove(SelectedPhoneNumber);
            }
            
        }
        
        private void AddAddress(object obj)
        {
            new AddUserAddressWindow().ShowDialog();
        }

        private void RemoveAddress(object obj)
        {
            ListOfUserAddresses.Remove(SelectedAddress);
        }

        private void RegisterUser(object obj)
        {
            var userToRegister = new User
            {
                Active = true,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Description = ""
            };

            if (Password.Equals(PasswordRepeat))
            {
                _addUserService.AddUser(userToRegister, Password);
            }
            else
            {
                MessageBox.Show("Lösenorden stämmer inte överrens.");
            }

            var savedUser = _userService.FindUserByEmail(userToRegister.Email);

            UserContactInformation userContactInformationToRegister = CreateUserContactInformation();

            savedUser.UserContactInformations.Add(userContactInformationToRegister);

            var userContactInformationType = savedUser.UserContactInformations.FirstOrDefault().ContactInformationTypes = new List<ContactInformationType>();

            ContactInformationType userContactInformationTypeToRegister = CreateContactInformationType();

            userContactInformationType.Add(userContactInformationTypeToRegister);

            var phoneNumberList = userContactInformationToRegister.UserPhoneNumbers = new List<UserPhoneNumber>();
            foreach (var number in PhoneNumbers)
            {
                phoneNumberList.Add(new UserPhoneNumber() { Active = true, PhoneNumber = number });
            }

            TryToRegisterUserToDatabase(userToRegister);

        }

        private void TryToRegisterUserToDatabase(User userToRegister)
        {
            try
            {
                _userService.UpdateUser(userToRegister);
            }
            catch (DbUpdateException)
            {
                //Tanken är här att man kollar om usern finns eller några andra delar som är unika i databasen.
                //Finns det så ska det som ligger i databasen användas, annars används det som användaren matat in.
                //Detta implementeras tyvärr inte pga. tidsbrist.
                MessageBox.Show("Already exists.");
            }
        }

        private ContactInformationType CreateContactInformationType()
        {
            return new ContactInformationType()
            {
                Active = true,
                Type = Address.AddressType
            };
        }

        private UserContactInformation CreateUserContactInformation()
        {
            return new UserContactInformation()
            {
                Active = true,
                BoxNo = Address.BoxNo,
                Country = Address.Country,
                City = Address.City,
                Street = Address.Street,
                Zip_Code = Address.Zip_Code,
                Description = Address.Description
            };
        }

        private void OnPhoneNumberAndTypeReceived(Dictionary<string, string> phoneNumberAndType)
        {
            if (phoneNumberAndType.Any(keyValuePairReceivedDictionary =>
                _phoneNumbersTypeAndPhoneNumber.ContainsValue(keyValuePairReceivedDictionary.Value)))
            {
                MessageBox.Show("Numret är redan tillagt.");
                return;
            }

            ConvertReceivedDictionaryToLocalDictionary(phoneNumberAndType);

            foreach (var phoneNumber in phoneNumberAndType)
            {
                PhoneNumbers.Add(phoneNumber.Value);
            }
        }

        private void ConvertReceivedDictionaryToLocalDictionary(Dictionary<string, string> phoneNumberAndType)
        {
            if (_phoneNumbersTypeAndPhoneNumber.Count == 0)
            {
                foreach (var phoneKeyValuePair in phoneNumberAndType)
                {
                    _phoneNumbersTypeAndPhoneNumber.Add(phoneKeyValuePair.Key, phoneKeyValuePair.Value);
                }
            }
            else
            {
                for (int i = 0; i < phoneNumberAndType.Count; i++)
                {
                    if (_phoneNumbersTypeAndPhoneNumber.ContainsKey(phoneNumberAndType.Keys.ElementAt(i)))
                    {
                        _phoneNumbersTypeAndPhoneNumber.Add(phoneNumberAndType.ElementAt(i).Key + (PhoneNumbers.Count + 1), phoneNumberAndType.ElementAt(i).Value);
                    }
                    else
                    {
                        _phoneNumbersTypeAndPhoneNumber.Add(phoneNumberAndType.ElementAt(i).Key, phoneNumberAndType.ElementAt(i).Value);
                    }
                }
            }
        }

        private void OnNewAddressRecieved(UserAddress address)
        {
            Address = address;
            ListOfUserAddresses.Add(Address);
        }

        private void RegisterMessages()
        {
            Messenger.Default.Register<Dictionary<string, string>>(this, OnPhoneNumberAndTypeReceived);
            Messenger.Default.Register<UserAddress>(this, OnNewAddressRecieved, "AddressSent");
        }
    }
}
