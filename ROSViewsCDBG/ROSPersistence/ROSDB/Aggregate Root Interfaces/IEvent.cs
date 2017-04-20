using System;
using System.Collections.Generic;

namespace ROSPersistence.ROSDB
{
    public interface IEvent
    {
        bool Active { get; set; }
        string Description { get; set; }
        DateTime EndTime { get; set; }
        ICollection<EventsFee> EventsFees { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        int No { get; set; }
        RaceEvent RaceEvent { get; set; }
        Regatta Regatta { get; set; }
        int RegattaId { get; set; }
        SocialEvent SocialEvent { get; set; }
        DateTime StartTime { get; set; }
    }
}