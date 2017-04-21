namespace ROS.Services.Services.Interfaces
{
    public interface ILoginService
    {
        bool ConfirmUserCredentials(string email, string password);
    }
}