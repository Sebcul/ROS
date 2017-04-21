using System.Collections.Generic;
using ROS.Services.Models;

namespace ROS.Services.Services.Interfaces
{
    public interface IRegattaService
    {
        IEnumerable<IRegattaUserRecord> FindRegattasParticipatedInByUserId(int id);
    }
}