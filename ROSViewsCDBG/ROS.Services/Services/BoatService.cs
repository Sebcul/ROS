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

        public Boat GetBoat(int id)
        {
            throw new NotImplementedException();
        }

        public List<Boat> GetAllBoats()
        {
            return _repository.GetAllWhereEntitiesMatchPredicate((x => x.Active)).ToList();
        }
    }
}
