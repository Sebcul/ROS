using System.Data.SqlClient;

namespace ROSPersistence.Repository
{
    public interface ILoginRepository
    {
        bool ConfirmUserCredentials(SqlParameter emailParam, SqlParameter passwordParam);
    }
}