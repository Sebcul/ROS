using System.Data.SqlClient;

namespace ROSPersistence.Repository
{
    public interface IAddUserRepository
    {
        void AddUserToDataBase(SqlParameter email, SqlParameter password, SqlParameter firstName, SqlParameter lastName, SqlParameter description);
    }
}