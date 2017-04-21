﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using ROSViewsCDBG.Helper_classes;
using ROSViewsCDBG.Models;
using ROSViewsCDBG.Views.Windows;

namespace ROSViewsCDBG.ViewModels
{
    public class RegisterUserWindowViewModel : ViewModelBase
    {
        private ICommand _addPhoneNumberCommand;
        private ICommand _removePhoneNumberCommand;
        private ICommand _registerUserCommand;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _passwordRepeat;
        private ObservableCollection<string> _phoneNumbers;
        private string _selectedPhoneNumber;
        private Dictionary<string, string> _phoneNumbersTypeAndPhoneNumber;
        private UserAddress _address;

        public RegisterUserWindowViewModel()
        {
            _phoneNumbers = new ObservableCollection<string>();
            _phoneNumbersTypeAndPhoneNumber = new Dictionary<string, string>();
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

        public UserAddress Address
        {
            get { return _address; }
            set { _address = value; }
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

        private void RegisterUser(object obj)
        {
            
        }

        private void OnPhoneNumberAndTypeReceived(Dictionary<string, string> phoneNumberAndType)
        {
            if (phoneNumberAndType.Any(keyValuePairReceivedDictionary =>
                _phoneNumbersTypeAndPhoneNumber.ContainsValue(keyValuePairReceivedDictionary.Value)))
            {
                MessageBox.Show("The number is already added.");
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

        private void RegisterMessages()
        {
            Messenger.Default.Register<Dictionary<string, string>>(this, OnPhoneNumberAndTypeReceived);
        }
    }
}