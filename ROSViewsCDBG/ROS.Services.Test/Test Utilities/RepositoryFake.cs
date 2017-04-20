using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ROSPersistence.Repository;

namespace ROS.Services.Test.Test_Utilities
{
    public class RepositoryFake<TEntity> : IRepository<TEntity>
        where TEntity : class
    {

        private IQueryable<TEntity> _testData;


        public RepositoryFake(List<TEntity> testData)
        {
            _testData = testData.AsQueryable();
        }


        public IList<TEntity> GetAllWhereEntitiesMatchPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return _testData.AsQueryable().Where(predicate).ToList();
        }


        public void UpdateEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }


        public void InsertEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }

}