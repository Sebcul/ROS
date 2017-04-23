using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ROSPersistence.ROSDB;

namespace ROSViewsCDBG.Converters
{
    class ClubsToClubNamesConverter : IValueConverter
    {
        private ObservableCollection<Club> _clubs;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(ObservableCollection<Club>))
            {
                _clubs = (ObservableCollection<Club>)value;
                return _clubs.Select(c => c.Name);
            }

            return "Error";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var name = (string) value;
            return _clubs.First(c => c.Name == name);
        }
    }
}
