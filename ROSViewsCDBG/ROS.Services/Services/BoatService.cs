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

        public void DeleteEntity(Boat Boat)
        {
            throw new NotImplementedException();
        }

        public IList<Boat> GetAllBoatsThatMatchPredicate(Expression<Func<Boat, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Boat Boat)
        {
            throw new NotImplementedException();
        }

        public void InsertEntity(Boat Boat)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(Boat Boat)
        {
            throw new NotImplementedException();
        }
    }
}
