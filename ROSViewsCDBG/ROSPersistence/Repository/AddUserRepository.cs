using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROSPersistence.Repository
{
    public class AddUserRepository : IAddUserRepository
    {
        private readonly DbContext _context;

        public AddUserRepository(DbContext context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public void AddUserToDataBase(SqlParameter email, SqlParameter password,
            SqlParameter firstName, SqlParameter lastName, SqlParameter description)
        {
            _context.Database.ExecuteSqlCommand(
                "sp_AddUserInApplication @Email, @Password, @FirstName, @LastName, @Description", email, password,
                firstName, lastName, description);
        }
    }
}
