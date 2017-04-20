using System;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using ROSPersistence.Repository;
using ROSPersistence.ROSDB;

namespace ROS.Services.Services
{
    public class LoginService
    {
        private IRepository<User> repo;

        public LoginService()
        {
            repo = RepositoryFactory.Instance.CreateRepository<User>();
        }

        public bool ConfirmUserCredentials(string email, string password)
        {
            SqlParameter param1 = new SqlParameter("@Email", email);
            SqlParameter param2 = new SqlParameter("@Password", password);
            int result = 0;
            SqlParameter param3 = new SqlParameter("@responseMessage", result);
            var context = new ROSDB();
            int x = context.Database.SqlQuery<int>("EXEC sp_ApplicationUserLogin @Email, @Password, @responseMessage", param1, param2, param3).First();
            return Convert.ToBoolean(x);
            
        }
    }
}
