using System.Data.Entity;

namespace ROSPersistence.Repository
{
    public class RepositoryFactory
    {
        public static readonly RepositoryFactory Instance = new RepositoryFactory();

        private readonly DbContext _context;


        private RepositoryFactory()
        {
            _context = new ROSDB.ROSDB();
        }

        public Repository<TEntity> CreateRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context);
        }
    }
}