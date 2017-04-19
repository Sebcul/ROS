namespace ROSPersistence.Repository
{
    public interface IRepositoryFactory
    {
        Repository<TEntity> CreateRepository<TEntity>() where TEntity : class;
    }
}