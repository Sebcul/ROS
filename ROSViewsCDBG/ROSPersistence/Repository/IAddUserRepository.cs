using System.Data.SqlClient;

namespace ROSPersistence.Repository
{
    interface IAddUserRepository
    {
        void AddUserToDataBase(SqlParameter email, SqlParameter password, SqlParameter firstName, SqlParameter lastName, SqlParameter description);
    }
}