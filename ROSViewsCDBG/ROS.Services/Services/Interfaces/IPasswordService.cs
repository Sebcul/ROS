namespace ROS.Services.Services.Interfaces
{
    public interface IPasswordService
    {
        void UpdatePassword(int id, string oldPassword, string newPassword);
    }
}