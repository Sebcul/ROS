namespace ROS.Services.Models
{
    public interface IRegattaUserRecord
    {
        string Name { get; }

        string EndDate { get; }
        
        string StartDate { get; }
    }
}