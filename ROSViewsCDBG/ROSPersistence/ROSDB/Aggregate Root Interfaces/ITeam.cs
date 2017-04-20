using System.Collections.Generic;

namespace ROSPersistence.ROSDB
{
    public interface ITeam
    {
        bool Active { get; set; }
        int BoatId { get; set; }
        ICollection<CrewMember> CrewMembers { get; set; }
        Entry Entry { get; set; }
        int EntryId { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        int No { get; set; }
        ICollection<RaceEvent> RaceEvents { get; set; }
        ICollection<Result> Results { get; set; }
    }
}