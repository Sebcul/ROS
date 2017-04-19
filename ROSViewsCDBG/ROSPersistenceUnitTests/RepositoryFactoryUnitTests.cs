using ROSPersistence.Repository;
using ROSPersistence.ROSDB;
using Xunit;

namespace ROSPersistenceUnitTests
{
    public class RepositoryFactoryUnitTests
    {

        [Fact]
        public void Should_NotBeNull_When_InstanceIsCalled()
        {
            //Arrange
            var repositoryFactorySut = RepositoryFactory.Instance;

            //Act
            

            //Assert
            Assert.NotNull(repositoryFactorySut);
        }


        [Fact] //Integration Test
        public void Should_NotReturnNull_When_CreateRepositoryIsCalled()
        {
            //Arrange
            var repositoryFactorySut = RepositoryFactory.Instance;

            //Act
            var repository = repositoryFactorySut.CreateRepository<User>();

            //Assert
            Assert.NotNull(repository);
        }
        
    }
}