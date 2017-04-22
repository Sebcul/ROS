using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ROSViewsCDBG.Helper_classes;

namespace ROSViewsCDBG.ViewModels
{
    public class AddPhoneNumberViewModel : ViewModelBase
    {
        private ICommand _savePhoneNumberCommand;
        private string _phoneNumber;
        private ObservableCollection<string> _phoneNumberTypes;
        private string _selectedPhoneNumberType;
        private Dictionary<string, string> _typeAndPhoneNumber;

        public AddPhoneNumberViewModel()
        {
            _phoneNumberTypes = new ObservableCollection<string>();
            _typeAndPhoneNumber = new Dictionary<string, string>();
            AddPhoneNumberTypes();
        }

        public ICommand SavePhoneNumberCommand
        {
            get { return _savePhoneNumberCommand ?? (_savePhoneNumberCommand = new RelayCommand(SavePhoneNumber)); }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value; 
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<string> PhoneNumberTypes
        {
            get { return _phoneNumberTypes; }
            set
            {
                _phoneNumberTypes = value; 
                OnPropertyChanged();
            }
        }

        public string SelectedPhoneNumberType
        {
            get { return _selectedPhoneNumberType; }
            set
            {
                _selectedPhoneNumberType = value; 
                OnPropertyChanged();
            }
        }

        private void SavePhoneNumber(object obj)
        {
            var regexPattern = @"^[0-9]+$";

            if (String.IsNullOrEmpty(PhoneNumber) || PhoneNumber.Length < 5 || !Regex.IsMatch(PhoneNumber, regexPattern))
            {
                MessageBox.Show("Du måste ange ett giltigt telefonnummer.");
            }
            else
            {
                _typeAndPhoneNumber.Add(SelectedPhoneNumberType, PhoneNumber);
                Messenger.Default.Send(_typeAndPhoneNumber);
                CloseWindow();
            }
        }

        private void AddPhoneNumberTypes()
        {
            PhoneNumberTypes.Add("Mobil");
            PhoneNumberTypes.Add("Arbete");
            PhoneNumberTypes.Add("Hem");
        }

        private static void CloseWindow()
        {
            Window window = Application.Current.Windows
                .OfType<Window>().FirstOrDefault(w => w.Name == "AddPhoneNumber");
            window?.Close();
        }
    }
}
