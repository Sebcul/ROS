using System.Collections.Generic;
using ROS.Services.Models;
using ROSPersistence.ROSDB;

namespace ROS.Services.Services.Interfaces
{
    public interface IUserService
    {
        User FindUserByEmail(string email);
        IEnumerable<User> GetAllUsers();
        IUserInfo GetUserInfoDisplayObjectByEmail(string email);
        void UpdateUser(User user);
        User AddContactInformationType(User user);
    }
}