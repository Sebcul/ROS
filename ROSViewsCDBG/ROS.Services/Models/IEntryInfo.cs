using ROSPersistence.ROSDB;
using System.Collections.Generic;

namespace ROS.Services.Models
{
    public interface IEntryInfo
    {      
        int No { get; }
        int SkipperId { get; }
        IEnumerable<string> Boat{ get; }
        IEnumerable<int>  Regatta { get; }
        decimal TotalSumPaid { get; }
        string Description { get; }

    }
}
