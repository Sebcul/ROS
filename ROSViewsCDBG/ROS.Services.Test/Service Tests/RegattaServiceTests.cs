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
                .ThatReturnsAFakeRepositoryWithTestEntities(
                    TestDataFactory.CreateRegattaTestDataWithUser(new User
                    {
                        Id = 33,
                        FirstName = "Johny",
                        LastName = "BeGood"
                    })).Build();

            var regattaServiceSut = new RegattaService(stubRepositoryFactory);

            //Act
            var regattaHistoryResult = regattaServiceSut.FindRegattaHistoryByUserId(33);

            //Assert
            Assert.True(regattaHistoryResult.First().Name == "Westcoast S-Regatta 2016");
            Assert.True(regattaHistoryResult.Last().Name == "Eastcoast S-Regatta 2016");
        }


        [Fact]
        public void Should_ReturnAListContainingTwoElements_When_GetAllRegattasIsCalled()
        {
            //Arrange
            var stubRepositoryFactory =
                A.RepositoryFactory()
                    .ThatReturnsAFakeRepositoryWithTestEntities(TestDataFactory.CreateRegattaTestData()).Build();

            var serviceSut = new RegattaService(stubRepositoryFactory);


            //Act
            var resultRegattas = serviceSut.GetAllRegattas();

            //Assert
            Assert.Equal(resultRegattas.Count(), 2);
        }
    }
}