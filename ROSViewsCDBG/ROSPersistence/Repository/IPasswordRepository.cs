using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSPersistence.Repository
{
    public interface IPasswordRepository
    {
        void UpdatePassword(SqlParameter idParam, SqlParameter oldPasswordParam, SqlParameter newPasswordParam);
    }
}
