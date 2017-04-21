using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ros.Services.Services.Interfaces;
using ROSPersistence.Repository;
using ROSPersistence.ROSDB;

namespace Ros.Services.Services
{
    public class BoatService : IBoatService
    {
        private Repository<Boat> repository;

        public BoatService(Repository<Boat> repository)
        {
            this.repository = repository;
        }

        public void DeleteBoat(Boat boat)
        {
            throw new NotImplementedException();
        }

        public void UpdateBoat(Boat boat)
        {
            repository.UpdateEntity(boat);
        }

        public void AddBoat(Boat boat)
        {
            repository.InsertEntity(boat);
        }

        public Boat GetBoat(int id)
        {
            throw new NotImplementedException();
        }

        public List<Boat> GetAllBoats()
        {
            return repository.GetAllWhereEntitiesMatchPredicate((x => x.Active)).ToList();
        }
    }
}
