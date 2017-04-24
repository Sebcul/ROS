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
    class UsersToUserNamesConverter : IValueConverter
    {
        private ObservableCollection<User> _users;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ( value != null && value.GetType() == typeof(ObservableCollection<User>))
            {
                _users = (ObservableCollection<User>)value;
                return _users.Select(u => u.FirstName + " " + u.LastName);
            }

            if ( value != null && value.GetType() == typeof(User))
            {
                var user = (User) value;
                return user.FirstName + " " + user.LastName;
            }

            return "Error";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (_users == null || _users.Count == 0)
            {
                return null;
            }
            var name = (string) value;
            var firstName = name.Split(' ').First();
            var lastName = name.Split(' ').Last();
            if (_users.Contains(_users.First(u => u.FirstName == firstName && u.LastName == lastName)))
                return _users.First(u => u.FirstName == firstName && u.LastName == lastName);
            
            return _users.First();
        }
    }
}
