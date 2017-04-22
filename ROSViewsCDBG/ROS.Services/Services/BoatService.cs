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
        private readonly IRepository<Boat> _repository;

        public BoatService(IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.CreateRepository<Boat>();
        }

        public void DeleteBoat(Boat boat)
        {
            throw new NotImplementedException();
        }

        public void UpdateBoat(Boat boat)
        {
            _repository.UpdateEntity(boat);
        }

        public void AddBoat(Boat boat)
        {
            _repository.InsertEntity(boat);
        }

        public IEnumerable<Boat> GetAllBoats()
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(boat => boat.Active);
        }

        public IEnumerable<Boat> GetAllBoatsWithHandicap(int handicap)
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(boat => boat.Handicap == handicap);
        }

        public IBoat GetBoatByName(string name)
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(boat => boat.Name == name).FirstOrDefault();
        }
    }
}
