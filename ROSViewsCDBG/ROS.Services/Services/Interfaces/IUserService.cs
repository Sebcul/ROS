using System.Collections.Generic;
using ROSPersistence.ROSDB;

namespace ROS.Services.Services.Interfaces
{
    public interface IUserService
    {
        User FindUserByEmail(string email);
        IEnumerable<User> GetAllUsers();
    }
}