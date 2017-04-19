using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentAssertions;
using Moq;
using Ros.Domain.Aggregate_Roots.Boat;
using Ros.Domain.Aggregate_Roots.Boat.Value_Objects;
using Ros.Domain.Aggregate_Roots.Interfaces;
using Ros.Domain.Global_Value_Objects;
using Ros.Domain.Validators;
using Ros.Persistence.Repositories.Interfaces;
using Ros.Services.Services.Interfaces;
using Xunit;

namespace Ros.Service.UnitTests.Service_Tests
{
    public class BoatServiceTests
    {
        public class FakeRepository<T> : IRepository<T> where T : DomainBoat
        {
            private Dictionary<int, T> _data = new Dictionary<int, T>();

            public void Add(T entity)
            {
                _data[entity.Id] = entity;
            }

            public void Delete(T entity)
            {
                _data.Remove(entity.Id);
            }

            public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
            {
                throw new NotImplementedException();
            }

            public T Get(int id)
            {
                var entity = default(T);
                _data.TryGetValue(id, out entity);
                return entity;
            }

            public IList<T> GetAllWhereEntitiesMatchPredicate(Expression<Func<T, bool>> predicate)
            {
                throw new NotImplementedException();
            }

            public void UpdateEntity(T entity)
            {
                throw new NotImplementedException();
            }

            public void InsertEntity(T entity)
            {
                throw new NotImplementedException();
            }
        }

        public class BoatService : IBoatService
        {
            private FakeRepository<DomainBoat> fakeRepository;

            public BoatService(FakeRepository<DomainBoat> fakeRepository)
            {
                this.fakeRepository = fakeRepository;
            }

            public void DeleteEntity(DomainBoat domainBoat)
            {
                throw new NotImplementedException();
            }

            public IList<IDomainBoat> GetAllBoatsThatMatchPredicate(Expression<Func<IDomainBoat, bool>> predicate)
            {
                throw new NotImplementedException();
            }

            public void UpdateEntity(DomainBoat domainBoat)
            {
                throw new NotImplementedException();
            }

            public void InsertEntity(DomainBoat domainBoat)
            {
                throw new NotImplementedException();
            }

            public void AddEntity(DomainBoat domainBoat)
            {
                fakeRepository.Add(domainBoat);
            }
        }

        public BoatService boatService;
        public FakeRepository<DomainBoat> fakeRepository;

        [Fact]
        public void AddShouldSetObjectIntoDB_WithHandicapEdited_Test()
        {
            // Arrange
            var domainBoat1 = new DomainBoat(1,
                new BoatName("Helsike",
                new StringValidator((1, 50, ""))), 1,
                new Model("99tvåhundra",
                new StringValidator((1, 50, ""))), 10.5, new Description("sadsads"), true,
                new HashSet<IDomainEntry>());
            var domainBoat2 = new DomainBoat(2,
                new BoatName("Helsikesss",
                new StringValidator((1, 50, ""))), 1,
                new Model("99tvåhundratvå",
                new StringValidator((1, 50, ""))), 2.5, new Description("dsad"), true,
                new HashSet<IDomainEntry>());
            fakeRepository = new FakeRepository<DomainBoat>();
            boatService = new BoatService(fakeRepository);
            // Act
            boatService.AddEntity(domainBoat1);
            boatService.AddEntity(domainBoat2);
            // Assert
            fakeRepository.Get(1).Handicap.Should().Be(10.5);
            fakeRepository.Get(2).Handicap.Should().Be(2.5);
        }

        [Fact]
        public void GetShouldReturnNotImplementedDB_Test()
        {
            // Arrange
            var domainBoat1 = new DomainBoat(1,
                new BoatName("Helsike",
                new StringValidator((1, 50, ""))), 1,
                new Model("99tvåhundra",
                new StringValidator((1, 50, ""))), 10.5, new Description("sadsads"), true,
                new HashSet<IDomainEntry>());
            var domainBoat2 = new DomainBoat(2,
                new BoatName("Helsikesss",
                new StringValidator((1, 50, ""))), 1,
                new Model("99tvåhundratvå",
                new StringValidator((1, 50, ""))), 2.5, new Description("dsad"), true,
                new HashSet<IDomainEntry>());
            fakeRepository = new FakeRepository<DomainBoat>();
            boatService = new BoatService(fakeRepository);
            // Act
            boatService.AddEntity(domainBoat1);
            boatService.AddEntity(domainBoat2);
            // Assert
            Assert.Throws<NotImplementedException>(() => fakeRepository.GetAllWhereEntitiesMatchPredicate(p => p.Name.Equals("Helsike")).Count);
        }

        [Fact]
        public void DeleteShouldArchiveObjectInDB_Test()
        {
            // Arrange
            var domainBoat1 = new DomainBoat(1,
                new BoatName("Helsike",
                new StringValidator((1, 50, ""))), 1,
                new Model("99tvåhundra",
                new StringValidator((1, 50, ""))), 10.5, new Description(""), true,
                new HashSet<IDomainEntry>());
            var domainBoat2 = new DomainBoat(2,
                new BoatName("Helsike",
                new StringValidator((1, 50, ""))), 1,
                new Model("99tvåhundra",
                new StringValidator((1, 50, ""))), 2.5, new Description(""), true,
                new HashSet<IDomainEntry>());
            // Act
            // Act
            fakeRepository = new FakeRepository<DomainBoat>();
            fakeRepository.Add(domainBoat1);
            fakeRepository.Add(domainBoat2);
            fakeRepository.Delete(domainBoat1);
            // Assert
            Assert.Throws<Exception>(() => fakeRepository.Get(1));
        }

        [Fact]
        public void GetShouldReturnEntity_Test()
        {
            // Arrange
            var domainBoat1 = new Mock<IDomainBoat>();
            // Act
            fakeRepository = new FakeRepository<DomainBoat>();
            // Assert
            
        }
    }
}
