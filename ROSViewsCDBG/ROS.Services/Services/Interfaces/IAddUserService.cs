using ROSPersistence.ROSDB;

namespace ROS.Services.Services.Interfaces
{
    public interface IAddUserService
    {
        void AddUser(User user, string password);
    }
}