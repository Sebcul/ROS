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
    class EventsToEventNamesConverter : IValueConverter
    {
        private ObservableCollection<Event> _events;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(ObservableCollection<Event>))
            {
                _events = (ObservableCollection<Event>)value;
                return _events.Select(e => e.Name);
            }

            return "Error";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var name = (string) value;
            return _events.First(e => e.Name == name);
        }
    }
}
