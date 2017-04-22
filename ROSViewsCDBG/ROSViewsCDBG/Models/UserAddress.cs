using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSViewsCDBG.Models
{
    public class UserAddress : ModelBase
    {
        private string _country;
        private string _city;
        private string _street;
        private int _zipCode;
        private int _boxNo;
        private string _addressType;
        private string _description;

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged();
            }
        }

        public int Zip_Code
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
                OnPropertyChanged();
            }
        }

        public int BoxNo
        {
            get { return _boxNo; }
            set
            {
                _boxNo = value;
                OnPropertyChanged();
            }
        }

        public string AddressType
        {
            get { return _addressType; }
            set
            {
                _addressType = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
    }
}
