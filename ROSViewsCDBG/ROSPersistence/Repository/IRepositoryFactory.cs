namespace ROSPersistence.Repository
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> CreateRepository<TEntity>() where TEntity : class;
        ILoginRepository CreateLoginRepository();
        IAddUserRepository CreateAddUserRepository();
        IPasswordRepository CreatePasswordRepository();
    }
}