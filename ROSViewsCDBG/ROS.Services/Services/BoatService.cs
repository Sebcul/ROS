using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ros.Domain.Aggregate_Roots.Boat;
using Ros.Domain.Aggregate_Roots.Interfaces;
using Ros.Persistence.Repositories;
using Ros.Services.Services.Interfaces;

namespace Ros.Services.Services
{
    public class BoatService : IBoatService
    {
        private Repository<DomainBoat> repository;

        public BoatService(Repository<DomainBoat> repository)
        {
            this.repository = repository;
        }

        public void DeleteEntity(DomainBoat domainBoat)
        {
            throw new NotImplementedException();
        }

        public IList<IDomainBoat> GetAllBoatsThatMatchPredicate(Expression<Func<IDomainBoat, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(DomainBoat domainBoat)
        {
            throw new NotImplementedException();
        }

        public void InsertEntity(DomainBoat domainBoat)
        {
            throw new NotImplementedException();
        }

        public void AddEntity(DomainBoat domainBoat)
        {
            throw new NotImplementedException();
        }
    }
}
