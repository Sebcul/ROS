using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROSPersistence.ROSDB;


namespace ROS.Services.Models
{
    public class UserInfo : IUserInfo
    {
        private readonly IUser _user;

        public UserInfo(IUser user)
        {
            _user = user;
        }

        public string Name => $"{_user.FirstName} {_user.LastName}";
        public IEnumerable<string> Clubs => _user.Members.SelectMany(u => u.Clubs.Select(c => c.Name));
        public IEnumerable<UserContactInformation> ContactInformation => _user.UserContactInformations;
    }
}
