using ROS.Services.Models;
using ROSPersistence.ROSDB;

namespace ROS.Services.Factories
{
    interface IModelFactory
    {
        IRegattaUserRecord CreateRegattaRecord(IRegatta regatta);
        IUserInfo CreateUserInfo(IUser user);
    }
}