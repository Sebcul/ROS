using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROS.Services.Services.Interfaces;
using ROSPersistence.Repository;
using ROSPersistence.ROSDB;

namespace ROS.Services.Services
{
    public class AddUserService : IAddUserService
    {
        private readonly IAddUserRepository _repository;

        public AddUserService()
        {
            _repository = RepositoryFactory.Instance.CreateAddUserRepository();
        }
        public void AddUser(User user, string password)
        {
            var emailParam = new SqlParameter("@Email", user.Email);
            var passwordParam = new SqlParameter("@Password", password);
            var firstNameParam = new SqlParameter("@FirstName", user.FirstName);
            var lastNameParam = new SqlParameter("@LastName", user.LastName);
            var descriptionParam = new SqlParameter(@"Description", user.Description);

            _repository.AddUserToDataBase(emailParam, passwordParam, firstNameParam, 
                lastNameParam, descriptionParam);
        }
    }
}
