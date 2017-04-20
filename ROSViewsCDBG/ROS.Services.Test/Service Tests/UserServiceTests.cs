using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Moq;
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

            var repositoryFactoryStub = A.RepositoryFactory()
                .ThatReturnsARepositoryWithTestUsers(x => x.Active, data).Build();

            //Act
            var entitiesResult =
                repositoryFactoryStub.CreateRepository<User>().GetAllWhereEntitiesMatchPredicate(x => x.Active);

            var containsAllActiveEntities = entitiesResult.All(user => data.Contains(user));

            //Assert
            Assert.Equal(true, containsAllActiveEntities);

        }
    }

    public class A
    {
        public static RepositoryFactoryBuilder RepositoryFactory()
        {
            return new RepositoryFactoryBuilder();
        }
    }

    public class RepositoryFactoryBuilder
    {
        private IRepositoryFactory _repositoryFactory;


        public IRepositoryFactory Build() => _repositoryFactory;


        public RepositoryFactoryBuilder ThatReturnsARepositoryWithTestUsers<TEntity>(Expression <Func<TEntity, bool>> predicate,
            List<TEntity> testData) where TEntity : class
        {
       
            var stubSet = new Mock<DbSet<TEntity>>().SetupData(testData);
            stubSet.Setup(set => set).Returns(stubSet.Object);

            var stubContext = new Mock<DbContext>();
            stubContext.Setup(ctx => ctx.Set<TEntity>()).Returns(stubSet.Object);

            var stubRepository = new Mock<IRepository<TEntity>>();
            stubRepository.Setup(stub => stub.GetAllWhereEntitiesMatchPredicate(predicate))
                .Returns(stubSet.Object.Where(predicate).ToList);
            

            var stubFactory = new Mock<IRepositoryFactory>();
            stubFactory.Setup(stub => stub.CreateRepository<TEntity>()).Returns(stubRepository.Object);


            _repositoryFactory = stubFactory.Object;

            return this;
        }

    }
}