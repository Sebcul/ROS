using ROS.Services.Test.Test_Utilities;
using ROSPersistence.ROSDB;
using System.Linq;
using ROS.Services.Services;
using Xunit;

namespace ROS.Services.Test.Service_Tests
{
    public class RegattaServiceTests
    {
        [Fact]
        public void Should_ReturnRegattaHistory_When_FindRegattaHistoryByUserIdIsCalled()
        {
            //Arrange
            var stubRepositoryFactory = A.RepositoryFactory()
                .ThatReturnsAFakeRepositoryWithTestUsers(
                    TestDataFactory.CreateRegattaTestDataWithUser(new User
                    {
                        Id = 33,
                        FirstName = "Johny",
                        LastName = "BeGood"
                    })).Build();

            var regattaServiceSut = new RegattaService(stubRepositoryFactory);

            //Act
            var regattaHistory = regattaServiceSut.FindRegattaHistoryByUserId(33);

            //Assert
            Assert.True(regattaHistory.First().Name == "Westcoast S-Regatta 2016");
            Assert.True(regattaHistory.Last().Name == "Eastcoast S-Regatta 2016");
        }
    }
}