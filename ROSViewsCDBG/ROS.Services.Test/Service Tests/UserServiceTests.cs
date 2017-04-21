using System;
using System.Collections.Generic;
using System.Linq;
using ROS.Services.Services;
using ROS.Services.Test.Test_Utilities;
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
            var stubRepositoryFactory = A.RepositoryFactory().ThatReturnsAFakeRepositoryWithTestEntities(TestDataFactory.CreateDataForUserRepository()).Build();

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
            var stubRepositoryFactory = A.RepositoryFactory().ThatReturnsAFakeRepositoryWithTestEntities(TestDataFactory.CreateDataForUserRepository()).Build();

            var userServiceSut = new UserService(stubRepositoryFactory);

            //Act
            var resultUser = userServiceSut.FindUserByEmail(expectedEmail);


            //Assert
            Assert.Equal(expectedEmail, resultUser.Email);
        }



        

    }

    
    

}