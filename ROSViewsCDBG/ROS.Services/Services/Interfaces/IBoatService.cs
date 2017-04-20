using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ROSPersistence.ROSDB;

namespace Ros.Services.Services.Interfaces
{
    public interface IBoatService
    {
        void AddEntity(Boat boat);

        void DeleteEntity(Boat boat);

        void UpdateEntity(Boat boat);

        List<Boat> GetAllBoats();
            
        Boat GetBoat(int id);
    }
}
