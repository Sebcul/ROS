using ROSPersistence.ROSDB;
using System.Collections.Generic;

namespace ROS.Services.Models
{
    public interface IEntryInfo
    {      
        int No { get; }
        int SkipperId { get; }
        string Boat { get; }
        int Regatta { get; }
        int TotalSumPaid { get; }
        string Description { get; }
        string RegattaName { get; }
        IEnumerable<RegisteredUser> RegisteredUser { get; }
    }
}
