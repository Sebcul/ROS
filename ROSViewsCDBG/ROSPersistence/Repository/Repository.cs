using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace ROSPersistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> _dbSet;


        public Repository(DbContext context)
        {
            _context = context;
            //_context.Configuration.LazyLoadingEnabled = false;

            _dbSet = _context.Set<TEntity>();
        }


        public IList<TEntity> GetAllWhereEntitiesMatchPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }


        public void UpdateEntity(TEntity entity)
        {
            _context.Entry(entity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public void InsertEntity(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
    }
}
