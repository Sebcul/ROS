using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROSPersistence.ROSDB;

namespace ROSPersistence.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DbContext _context;

        public LoginRepository(DbContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
        }
        public bool ConfirmUserCredentials(SqlParameter emailParam, SqlParameter passwordParam)
        {
            int responseMessageInput = 0;
            SqlParameter resultParam = new SqlParameter("@responseMessage", responseMessageInput);
            int result = _context.Database.SqlQuery<int>("EXEC sp_ApplicationUserLogin @Email, @Password, @responseMessage", 
                emailParam, passwordParam, resultParam).First();
            return Convert.ToBoolean(result);
        }
    }
}
