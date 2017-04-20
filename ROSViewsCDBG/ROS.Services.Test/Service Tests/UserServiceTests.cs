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

        private List<User> _testData = new List<User>
        {
             new User {Id = 1, Active = true, FirstName = "John", LastName = "Doe", Email = "doedoe_@gmail.com"},
             new User {Id = 2, Active = true, FirstName = "Eric", LastName = "Evans", Email = "evan_s@hotmail.com"},
             new User {Id = 3, Active = false, FirstName = "Martin", LastName = "Fowler", Email = "m_fowler@greatest.com"},
             new User {Id = 4, Active = true, FirstName = "Kent", LastName = "Beck", Email = "commisarie_beck@snuten.se"},
             new User {Id = 5, Active = true, FirstName = "Uncle", LastName = "Bob", Email = "uncle_b0b@grottmail.com"}
        };


        [Fact]
        public void Should_ReturnAllActiveEntities_When_GetAllActiveEntitiesIsCalled()
        {
            //Arrange
            var stubRepositoryFactory = A.RepositoryFactory().ThatReturnsAFakeRepositoryWithTestUsers(_testData).Build();

            var userServiceSut = new UserService(stubRepositoryFactory);

            //Act
            var resultUsers = userServiceSut.GetAllUsers();

            var containsAllActiveEntities = resultUsers.All(u => u.Active);

            //Assert
            Assert.Equal(true, containsAllActiveEntities);

        }


        [Theory]
        [InlineData("doedoe_@gmail.com")]
        [InlineData("uncle_b0b@grottmail.com")]
        public void Should_ReturnUser_When_EmailIsMatchingAndUserIsActive(string expectedEmail)
        {
            //Arrange
            var stubRepositoryFactory = A.RepositoryFactory().ThatReturnsAFakeRepositoryWithTestUsers(_testData).Build();

            var userServiceSut = new UserService(stubRepositoryFactory);

            //Act
            var resultUser = userServiceSut.FindUserByEmail(expectedEmail);


            //Assert
            Assert.Equal(expectedEmail, resultUser.Email);
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


        public User FindUserByEmail(string email)
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(user => user.Email == email && user.Active).First();
        }
    }

}