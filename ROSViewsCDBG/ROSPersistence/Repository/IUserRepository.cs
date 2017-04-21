using System.Data.SqlClient;

namespace ROSPersistence.Repository
{
    interface IUserRepository : IAddUserRepository, ILoginRepository, IPasswordRepository
    {       
    }
}