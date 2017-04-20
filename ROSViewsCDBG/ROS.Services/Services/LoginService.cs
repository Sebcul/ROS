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
        private readonly ILoginRepository _repository;

        public LoginService()
        {
            _repository = RepositoryFactory.Instance.CreateLoginRepository();
        }

        public bool ConfirmUserCredentials(string email, string password)
        {
            SqlParameter emailParam = new SqlParameter("@Email", email);
            SqlParameter passwordParam = new SqlParameter("@Password", password);
            return _repository.ConfirmUserCredentials(emailParam, passwordParam);
        }
    }
}
