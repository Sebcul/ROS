using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ROSPersistence.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAllWhereEntitiesMatchPredicate(Expression<Func<TEntity, bool>> predicate);

        void UpdateEntity(TEntity entity);

        void InsertEntity(TEntity entity);

    }
}