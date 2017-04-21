using System.Collections.Generic;
using Moq;
using ROS.Services.Test.Service_Tests;
using ROSPersistence.Repository;

namespace ROS.Services.Test.Test_Utilities
{

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


        public RepositoryFactoryBuilder ThatReturnsAFakeRepositoryWithTestEntities<TEntity>(List<TEntity> testData) where TEntity : class
        {
            var stubFactory = new Mock<IRepositoryFactory>();
            stubFactory.Setup(factory => factory.CreateRepository<TEntity>()).Returns(new RepositoryFake<TEntity>(testData));

            _repositoryFactory = stubFactory.Object;

            return this;
        }


        public RepositoryFactoryBuilder ThatReturnsAMockRepositoryThatTracksCallsToTheUpdateEntityFunction<TEntity>(
            out Mock<IRepository<TEntity>> mock) 
            where TEntity : class
        {
            var mockRepository = new Mock<IRepository<TEntity>>();
            mockRepository.Setup(repository => repository.UpdateEntity(It.IsAny<TEntity>())).Verifiable();

            mock = mockRepository;

            var mockFactory = new Mock<IRepositoryFactory>();
            mockFactory.Setup(factory => factory.CreateRepository<TEntity>()).Returns(mockRepository.Object);

            _repositoryFactory = mockFactory.Object;

            return this;
        }
    }
}