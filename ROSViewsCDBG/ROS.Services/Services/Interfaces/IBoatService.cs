using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Ros.Domain.Aggregate_Roots.Boat;
using Ros.Domain.Aggregate_Roots.Interfaces;
using Ros.Persistence.Repositories.Interfaces;

namespace Ros.Services.Services.Interfaces
{
    public interface IBoatService
    {
        void AddEntity(DomainBoat domainBoat);

        void DeleteEntity(DomainBoat domainBoat);

        IList<IDomainBoat> GetAllBoatsThatMatchPredicate(Expression<Func<IDomainBoat, bool>> predicate);

        void UpdateEntity(DomainBoat domainBoat);

        void InsertEntity(DomainBoat domainBoat);
    }
}
