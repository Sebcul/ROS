using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROSPersistence.ROSDB;

namespace ROS.Services.Services
{
    public class AddUserService : IAddUserService
    {
        public void AddUser(User user, string password)
        {
            SqlParameter emailParam = new SqlParameter("@Email", user.Email);
            SqlParameter passwordParam = new SqlParameter("@Password", password);
            SqlParameter firstNameParam = new SqlParameter("@FirstName", user.FirstName);
            SqlParameter lastNameParam = new SqlParameter("@LastName", user.LastName);
            SqlParameter descriptionParam = new SqlParameter(@"Description", user.Description);
        }
    }
}
