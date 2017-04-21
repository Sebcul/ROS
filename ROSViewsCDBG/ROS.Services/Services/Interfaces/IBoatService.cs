using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ROSPersistence.ROSDB;

namespace Ros.Services.Services.Interfaces
{
    public interface IBoatService
    {
        void AddBoat(Boat boat);

        void DeleteBoat(Boat boat);

        void UpdateBoat(Boat boat);

        IEnumerable<Boat> GetAllBoats();

        IEnumerable<Boat> GetAllBoatsWithHandicap(int handicap);
        
        IBoat GetBoatByName(string name);
    }
}
