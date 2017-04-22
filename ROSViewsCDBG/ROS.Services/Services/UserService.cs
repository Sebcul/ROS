using System.Collections.Generic;
using System.Linq;
using ROS.Services.Factories;
using ROS.Services.Models;
using ROS.Services.Services.Interfaces;
using ROSPersistence.Repository;
using ROSPersistence.ROSDB;

namespace ROS.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.CreateRepository<User>();
        }


        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(user => user.Active);
        }


        public User FindUserByEmail(string email)
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(user => user.Email == email && user.Active).First();
        }

        public void UpdateUser(User user)
        {
            _repository.UpdateEntity(user);
        }

        public IUserInfo GetUserInfoDisplayObjectByEmail(string email)
        {
            var user = FindUserByEmail(email);
            return ModelFactory.Instance.CreateUserInfo(user);
        }
    }

}