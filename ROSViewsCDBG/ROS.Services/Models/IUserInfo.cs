using System.Collections.Generic;
using ROSPersistence.ROSDB;

namespace ROS.Services.Models
{
    public interface IUserInfo
    {
        IEnumerable<string> Clubs { get; }
        IEnumerable<UserContactInformation> ContactInformation { get; }
        string Name { get; }
    }
}