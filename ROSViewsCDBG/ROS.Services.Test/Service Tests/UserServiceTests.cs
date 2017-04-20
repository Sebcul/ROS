using System.Collections.Generic;
using System.Linq;
using ROS.Services.Test.Test_Utilities;
using ROSPersistence.Repository;
using ROSPersistence.ROSDB;
using Xunit;

namespace ROS.Services.Test.Service_Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void Should_ReturnAllActiveEntities_When_GetAllActiveEntitiesIsCalled()
        {
            //Arrange
            var data = new List<User>
            {
                new User {Id = 1, Active = true, FirstName = "John", LastName = "Doe"},
                new User {Id = 2, Active = true, FirstName = "Eric", LastName = "Evans"},
                new User {Id = 3, Active = false, FirstName = "Martin", LastName = "Fowler"},
                new User {Id = 4, Active = true, FirstName = "Kent", LastName = "Beck"},
                new User {Id = 5, Active = true, FirstName = "Uncle", LastName = "Bob"}
            };

            var stubRepositoryFactory = A.RepositoryFactory().ThatReturnsAFakeRepositoryWithTestUsers(data).Build();

            var userServiceSut = new UserService(stubRepositoryFactory);

            //Act
            var resultUsers = userServiceSut.GetAllUsers();

            var containsAllActiveEntities = resultUsers.All(u => u.Active);

            //Assert
            Assert.Equal(true, containsAllActiveEntities);

        }
    }


    public class UserService
    {
        private IRepository<User> _repository;


        public UserService(IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.CreateRepository<User>();
        }


        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(user => user.Active);
        }
    }

}