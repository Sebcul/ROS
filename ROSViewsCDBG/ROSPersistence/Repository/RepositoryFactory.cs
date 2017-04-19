using System.Data.Entity;
using ROSPersistence.Repository;
using ROSPersistence.ROSDB;

namespace ROSPersistenceUnitTests
{
    public class RepositoryFactory
    {
        public static readonly RepositoryFactory Instance = new RepositoryFactory();

        private readonly DbContext _context;


        private RepositoryFactory()
        {
            _context = new ROSDB();
        }

        public Repository<TEntity> CreateRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context);
        }
    }
}