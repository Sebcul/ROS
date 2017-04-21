using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROS.Services.Services.Interfaces;
using ROSPersistence.Repository;

namespace ROS.Services.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository _repository;

        public PasswordService()
        {
            _repository = RepositoryFactory.Instance.CreatePasswordRepository();
        }
        public void UpdatePassword(int id, string oldPassword, string newPassword)
        {
            var idParam = new SqlParameter("@Id", id);
            var oldPasswordParam = new SqlParameter("@OldPassword", oldPassword);
            var newPasswordParam = new SqlParameter("@NewPassword", newPassword);

            _repository.UpdatePassword(idParam, oldPasswordParam, newPasswordParam);
        }
    }
}
