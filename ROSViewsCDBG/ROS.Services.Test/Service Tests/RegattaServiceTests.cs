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
            var regattaHistoryResult = regattaServiceSut.FindRegattasParticipatedInByUserId(33);

            //Assert
            Assert.True(regattaHistoryResult.First().Name == "Westcoast S-Regatta 2016");
            Assert.True(regattaHistoryResult.Last().Name == "Eastcoast S-Regatta 2016");
        }


        [Fact]
        public void Should_ReturnSixRegattas_When_GetAllRegattasIsCalled()
        {
            //Arrange
            var stubRepositoryFactory =
                A.RepositoryFactory()
                    .ThatReturnsAFakeRepositoryWithTestEntities(TestDataFactory.CreateRegattaTestData()).Build();

            var serviceSut = new RegattaService(stubRepositoryFactory);


            //Act
            var resultRegattas = serviceSut.GetAllRegattas();

            //Assert
            Assert.Equal(6, resultRegattas.Count());
        }


        [Fact]
        public void Should_ReturnTwoRegattas_When_GetUpcomingRegattasIsCalled()
        {
            //Arrange
            var stubRepositoryFactory =
                A.RepositoryFactory()
                    .ThatReturnsAFakeRepositoryWithTestEntities(TestDataFactory.CreateRegattaTestData())
                    .Build();

            var regattaServiceSut = new RegattaService(stubRepositoryFactory);

            //Act
            var resultRegattas = regattaServiceSut.GetUpcomingRegattas();

            //Assert
            Assert.Equal(2, resultRegattas.Count());
        }


        [Fact]
        public void Should_ReturnTwoRegattas_When_GetPastRegattasIsCalled()
        {
            //Arrange
            var stubRepositoryFactory =
                A.RepositoryFactory()
                    .ThatReturnsAFakeRepositoryWithTestEntities(TestDataFactory.CreateRegattaTestData())
                    .Build();

            var regattaServiceSut = new RegattaService(stubRepositoryFactory);

            //Act
            var resultRegattas = regattaServiceSut.GetPastRegattas();


            //Assert
            Assert.Equal(2, resultRegattas.Count());
        }


        [Fact]
        public void Should_ReturnTwoRegattas_When_OngoingRegattasIsCalled()
        {
            //Arrange
            var stubRepositoryFactory =
                A.RepositoryFactory()
                    .ThatReturnsAFakeRepositoryWithTestEntities(TestDataFactory.CreateRegattaTestData())
                    .Build();

            var regattaServiceSut = new RegattaService(stubRepositoryFactory);

            //Act
            var resultRegattas = regattaServiceSut.GetOngoingRegattas();

            //Assert
            Assert.Equal(2, resultRegattas.Count());
        }
    }
}