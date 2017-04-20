using System;
using System.Collections.Generic;

namespace ROSPersistence.ROSDB
{
    public interface IEntry
    {
        bool Active { get; set; }
        Boat Boat { get; set; }
        int BoatId { get; set; }
        string Description { get; set; }
        ICollection<EventsFee> EventsFees { get; set; }
        int Id { get; set; }
        int No { get; set; }
        Regatta Regatta { get; set; }
        int RegattadId { get; set; }
        ICollection<RegattasFee> RegattasFees { get; set; }
        ICollection<RegisteredUser> RegisteredUsers { get; set; }
        DateTime? RegistrationDate { get; set; }
        int SkipperId { get; set; }
        ICollection<Team> Teams { get; set; }
        decimal? TotalSumPaid { get; set; }
        User User { get; set; }
    }
}