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
        private readonly IRepository<ContactInformationType> _contactInformationTypeRepository;

        public UserService(IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.CreateRepository<User>();
            _contactInformationTypeRepository = repositoryFactory.CreateRepository<ContactInformationType>();
        }


        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(user => user.Active);
        }


        public User FindUserByEmail(string email)
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(user => user.Email == email && user.Active).First();
        }

        public User FindUserById(int id)
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(user => user.Id == id && user.Active).First();
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

        public User AddContactInformationType(User user)
        {
            var allContactInformations = _contactInformationTypeRepository.GetAllWhereEntitiesMatchPredicate(x => x.Active);
            var allUserContactTypes = new List<ContactInformationType>();

            for (int i = 0; i < user.UserContactInformations.Count; i++)
            {
                allUserContactTypes.Add(user.UserContactInformations.ElementAt(i).ContactInformationTypes.ElementAt(0));
                user.UserContactInformations.ElementAt(i).ContactInformationTypes.ElementAt(0).Id = i;
            }

            foreach (var allConctactTypesType in allContactInformations)
            {
                foreach (var allUserContactTypesType in allUserContactTypes)
                {
                    if (allConctactTypesType.Type == allUserContactTypesType.Type)
                    {
                        var userContactInformation = user.UserContactInformations.FirstOrDefault(x => x.Id == allUserContactTypesType.Id);

                        if (userContactInformation != null)
                        {
                            var hej = userContactInformation.ContactInformationTypes.ElementAt(0);
                            hej.Id = 0;
                            foreach (var contactInformationTypeForUser in user.UserContactInformations)
                            {
                                contactInformationTypeForUser.ContactInformationTypes.Remove(hej);
                                contactInformationTypeForUser.ContactInformationTypes.Add(allConctactTypesType);
                            }
                        }
                    }
                }
            }
            return user;
        }

    }

}