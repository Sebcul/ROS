using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSPersistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
            //_context.Configuration.LazyLoadingEnabled = false;
        }

        public void AddUserToDataBase(SqlParameter email, SqlParameter password,
            SqlParameter firstName, SqlParameter lastName, SqlParameter description)
        {
            _context.Database.ExecuteSqlCommand(
                "sp_AddUserInApplication @Email, @Password, @FirstName, @LastName, @Description", 
                email, password, firstName, lastName, description);
        }

        public bool ConfirmUserCredentials(SqlParameter emailParam, SqlParameter passwordParam)
        {
            int responseMessageInput = 0;
            SqlParameter resultParam = new SqlParameter("@responseMessage", responseMessageInput);
            int result = _context.Database.SqlQuery<int>(
                "EXEC sp_ApplicationUserLogin @Email, @Password, @responseMessage",
                emailParam, passwordParam, resultParam).First();
            return Convert.ToBoolean(result);
        }

        public void UpdatePassword(SqlParameter idParam, SqlParameter oldPasswordParam, SqlParameter newPasswordParam)
        {
            _context.Database.ExecuteSqlCommand("sp_UpdatePassword @Id, @OldPassword, NewPassword", 
                idParam, oldPasswordParam, oldPasswordParam);
        }
    }
}
