using ROSPersistence.ROSDB;

namespace ROS.Services.Services
{
    public interface IAddUserService
    {
        void AddUser(User user, string password);
    }
}