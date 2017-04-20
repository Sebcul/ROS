using System.Collections.Generic;

namespace ROSPersistence.ROSDB
{
    public interface IRaceEvent
    {
        ICollection<Class> Classes { get; set; }
        DistanceMeasuredRaceEvent DistanceMeasuredRaceEvent { get; set; }
        string EndPosition { get; set; }
        Event Event { get; set; }
        int EventId { get; set; }
        string StartPosition { get; set; }
        ICollection<Team> Teams { get; set; }
        TimeMeasuredRaceEvent TimeMeasuredRaceEvent { get; set; }
    }
}