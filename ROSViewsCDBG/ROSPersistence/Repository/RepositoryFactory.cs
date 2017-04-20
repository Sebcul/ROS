using System.Data.Entity;

namespace ROSPersistence.Repository
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public static readonly RepositoryFactory Instance = new RepositoryFactory();

        private readonly DbContext _context;


        private RepositoryFactory()
        {
            _context = new ROSDB.ROSDB();
        }

        public IRepository<TEntity> CreateRepository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context);
        }

        public ILoginRepository CreateLoginRepository()
        {
            return new LoginRepository(_context);
        }
    }
}