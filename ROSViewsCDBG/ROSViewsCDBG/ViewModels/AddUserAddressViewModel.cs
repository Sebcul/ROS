using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ROSViewsCDBG.Helper_classes;
using ROSViewsCDBG.Models;

namespace ROSViewsCDBG.ViewModels
{
    public class AddUserAddressViewModel : ViewModelBase
    {
        private ICommand _saveAddressCommand;
        private UserAddress _address;
        private ObservableCollection<string> _addressTypes;

        public AddUserAddressViewModel()
        {
            _addressTypes = new ObservableCollection<string>();
            _address = new UserAddress();
            AddAddressTypes();
        }

        public ICommand SaveAddressCommand
        {
            get { return _saveAddressCommand ?? (_saveAddressCommand = new RelayCommand(SaveAddress)); }
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

        public ObservableCollection<string> AddressTypes
        {
            get { return _addressTypes; }
            set
            {
                _addressTypes = value;
                OnPropertyChanged();
            }
        }

        private void SaveAddress(object obj)
        {
            if (String.IsNullOrEmpty(Address.City) || String.IsNullOrEmpty(Address.Country) ||
                String.IsNullOrEmpty(Address.Street) || Address.Zip_Code == 0)
            {
                MessageBox.Show("Du måste lägga in korrekta värden i respektive fält.");
            }
            else
            {
                Messenger.Default.Send(Address, "AddressSent");
                CloseWindow();
            }

        }

        private void AddAddressTypes()
        {
            AddressTypes.Add("Hem");
            AddressTypes.Add("Faktura");
            AddressTypes.Add("Arbete");
        }

        private static void CloseWindow()
        {
            Window window = Application.Current.Windows
                .OfType<Window>().FirstOrDefault(w => w.Name == "AddUserAddress");
            window?.Close();
        }
    }
}
