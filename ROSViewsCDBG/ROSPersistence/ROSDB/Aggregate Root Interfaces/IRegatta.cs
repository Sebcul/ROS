using System;
using System.Collections.Generic;

namespace ROSPersistence.ROSDB
{
    public interface IRegatta
    {
        bool Active { get; set; }
        Club Club { get; set; }
        int ClubId { get; set; }
        string Description { get; set; }
        DateTime EndTime { get; set; }
        ICollection<Entry> Entries { get; set; }
        ICollection<Event> Events { get; set; }
        int Id { get; set; }
        string Location { get; set; }
        string Name { get; set; }
        ICollection<RegattasFee> RegattasFees { get; set; }
        ICollection<ResponsibleRegattaMember> ResponsibleRegattaMembers { get; set; }
        DateTime StartTime { get; set; }
    }
}