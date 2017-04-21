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


        public RepositoryFactoryBuilder ThatReturnsAFakeRepositoryWithTestUsers<TEntity>(List<TEntity> testData) where TEntity : class
        {
            var stubFactory = new Mock<IRepositoryFactory>();
            stubFactory.Setup(factory => factory.CreateRepository<TEntity>()).Returns(new RepositoryFake<TEntity>(testData));

            _repositoryFactory = stubFactory.Object;

            return this;
        }

    }
}