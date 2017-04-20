using System.Collections.Generic;

namespace ROSPersistence.ROSDB
{
    public interface IBoat
    {
        bool Active { get; set; }
        string Description { get; set; }
        ICollection<Entry> Entries { get; set; }
        double Handicap { get; set; }
        int Id { get; set; }
        string Model { get; set; }
        string Name { get; set; }
        int SailNo { get; set; }
    }
}