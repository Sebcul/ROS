using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
using ROSPersistence.Repository;
using ROSPersistence.ROSDB;
using Xunit;

namespace ROSPersistenceUnitTests
{
    public class RepositoryUnitTests
    {

        [Fact]
        public void Should_NotBeNull_When_RepositoryIsInstantiated()
        {
            //Arrange

            var repositorySut = A.GenericRepositoryOfUser().WithDummyContext().Build();

            //Act
           

            //Assert
            Assert.NotNull(repositorySut);
        }


        [Fact]
        public void Should_RetrieveAllEntities_When_NotNullIsDefinedAsPredicate()
        {
            //Arrange
            var repositorySut = A.GenericRepositoryOfUser().WithStubbedContextContainingBasicTestData().Build();

            //Act
            var entities = repositorySut.GetAllWhereEntitiesMatchPredicate(user => user != null);

            //Assert
            Assert.Equal(5, entities.Count);

        }


        [Fact]
        public void Should_RetrieveAllActiveEntities_When_ActiveIsPredicate()
        {
            //Arrange
            var repositorySut = A.GenericRepositoryOfUser().WithStubbedContextContainingBasicTestData().Build();

            //Act
            var entityCollection = repositorySut.GetAllWhereEntitiesMatchPredicate(user => user.Active);
            var containsActiveEntitiesOnly = entityCollection.Any(user => !user.Active);
            containsActiveEntitiesOnly = entityCollection.Any(user => user.Active);

            //Assert
            Assert.Equal(true, containsActiveEntitiesOnly);


        }


        [Fact]
        public void Should_RetrieveAllInactiveEntities_When_IsNotActiveIsPredicate()
        {
            //Arrange
            var repositorySut = A.GenericRepositoryOfUser().WithStubbedContextContainingBasicTestData().Build();

            //Act
            var entityCollection = repositorySut.GetAllWhereEntitiesMatchPredicate(user => !user.Active);
            var containsInactiveEntitiesOnly = entityCollection.Any(user => user.Active);
            containsInactiveEntitiesOnly = entityCollection.Any(user => !user.Active);

            //Assert
            Assert.Equal(true, containsInactiveEntitiesOnly);
        }


        [Theory]
        [InlineData("John", 1)]
        [InlineData("Eric", 2)]
        [InlineData("Martin", 3)]
        [InlineData("Kent", 4)]
        [InlineData("Uncle", 5)]
        public void Should_RetrieveACollectionOfTheEntityWithExpectedId_When_FirstNameIsPredicate(string firstName, int expectedId)
        {
            //Arrange
            var repositorySut = A.GenericRepositoryOfUser().WithStubbedContextContainingBasicTestData().Build();

            //Act
            var resultId = repositorySut.GetAllWhereEntitiesMatchPredicate(user => user.FirstName == firstName).First().Id;

            //Assert
            Assert.Equal(expectedId, resultId);
        }
        
    }

    public class A
    {

        public static GenericRepositoryOfUserBuilder GenericRepositoryOfUser()
        {
            return new GenericRepositoryOfUserBuilder();
        }
    }


    public class GenericRepositoryOfUserBuilder
    {
        private Repository<User> _repository;

        
        public Repository<User> Build()
        {
            return _repository;
        }

        public GenericRepositoryOfUserBuilder WithDummyContext()
        {
            _repository = new Repository<User>(new Mock<ROSDB>().Object);
            return this;
        }

        public GenericRepositoryOfUserBuilder WithStubbedContextContainingBasicTestData()
        {

            var data = new List<User>
            {
                new User {Id = 1, Active = true, FirstName = "John", LastName = "Doe"},
                new User {Id = 2, Active = true, FirstName = "Eric", LastName = "Evans"},
                new User {Id = 3, Active = false, FirstName = "Martin", LastName = "Fowler"},
                new User {Id = 4, Active = true, FirstName = "Kent", LastName = "Beck"},
                new User {Id = 5, Active = true, FirstName = "Uncle", LastName = "Bob"}
            };

            var mockSet = new Mock<DbSet<User>>().SetupData(data);
            mockSet.Setup(set => set.AsNoTracking()).Returns(mockSet.Object);

            var mockContext = new Mock<DbContext>();
            mockContext.Setup(ctx => ctx.Set<User>()).Returns(mockSet.Object);

            _repository = new Repository<User>(mockContext.Object);

            return this;
        }

        
    }
}
