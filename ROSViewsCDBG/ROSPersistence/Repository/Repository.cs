using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ROSPersistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbContext _context;
        private DbSet<TEntity> _dbSet;


        public Repository(DbContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;

            _dbSet = _context.Set<TEntity>();
        }


        public IList<TEntity> GetAllWhereEntitiesMatchPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            var queryableEntities = _dbSet.AsNoTracking();
            return queryableEntities.Where(predicate).ToList();
        }


        public void UpdateEntity(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void InsertEntity(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
    }
}
