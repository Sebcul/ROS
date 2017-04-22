using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using Ros.Services.Services.Interfaces;
using ROSPersistence.Repository;
using ROSPersistence.ROSDB;
using Xunit;

namespace ROS.Services.Test.ServiceTests
{
    public class BoatServiceTests
    {
        public class FakeRepository<T> : IRepository<T> where T : Boat
        {
            private Dictionary<int, T> _data = new Dictionary<int, T>();

            // For using Expression to get data
            private readonly IQueryable<T> _queryableData;

            public FakeRepository()
            {
                
            }

            public FakeRepository(List<T> queryableData)
            {
                _queryableData = queryableData.AsQueryable();
            }

            public void Add(T entity)
            {
                _data[entity.Id] = entity;
            }

            public void Delete(T entity)
            {
                _data.Remove(entity.Id);
            }

            public T Get(int id)
            {
                var entity = default(T);
                _data.TryGetValue(id, out entity);
                return entity;
            }

            public IList<T> GetAllWhereEntitiesMatchPredicate(Expression<Func<T, bool>> predicate)
            {
                return _queryableData.AsQueryable().Where(predicate).ToList();
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
            private readonly FakeRepository<Boat> fakeRepository;

            public BoatService(FakeRepository<Boat> fakeRepository)
            {
                this.fakeRepository = fakeRepository;
            }

            public void DeleteBoat(Boat boat)
            {
                fakeRepository.Delete(boat);
            }

            public void UpdateBoat(Boat boat)
            {
                fakeRepository.UpdateEntity(boat);
            }

            public void AddBoat(Boat boat)
            {
                fakeRepository.Add(boat);
            }

            public Boat GetBoat(int id)
            {
                return fakeRepository.Get(id);
            }

            public IEnumerable<Boat> GetAllBoats()
            {
                return fakeRepository.GetAllWhereEntitiesMatchPredicate(x => x.Active);
            }

            public IBoat GetBoatByName(string name)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Boat> GetAllBoatsWithHandicap(int handicap)
            {
                throw new NotImplementedException();
            }
        }

        public BoatService boatService;
        public FakeRepository<Boat> fakeRepository;

        [Fact]
        public void AddShouldSetObjectIntoDB_WithHandicapEdited_Test()
        {
            // Arrange
            var boat1 = new Boat
            {
                Active = true,
                Description = "A boat",
                Entries = null,
                Handicap = 10.5,
                Id = 1,
                Model = null,
                Name = "SomeBoat",
                SailNo = 122
            };
            var boat2 = new Boat
            {
                Active = true,
                Description = "A boat",
                Entries = null,
                Handicap = 2.5,
                Id = 2,
                Model = null,
                Name = "SomeBoat",
                SailNo = 122
            };
            fakeRepository = new FakeRepository<Boat>();
            boatService = new BoatService(fakeRepository);
            // Act
            boatService.AddBoat(boat1);
            boatService.AddBoat(boat2);
            // Assert
            fakeRepository.Get(1).Handicap.Should().Be(10.5);
            fakeRepository.Get(2).Handicap.Should().Be(2.5);
        }

        [Fact]
        public void GetShouldReturnNotImplementedDB_Test()
        {
            // Arrange
            var boat1 = new Boat
            {
                Active = true,
                Description = "A boat",
                Entries = null,
                Handicap = 10.5,
                Id = 1,
                Model = null,
                Name = "Helsike",
                SailNo = 122
            };
            var boat2 = new Boat
            {
                Active = true,
                Description = "A boat",
                Entries = null,
                Handicap = 2.5,
                Id = 2,
                Model = null,
                Name = "Helsike",
                SailNo = 122
            };
            fakeRepository = new FakeRepository<Boat>();
            boatService = new BoatService(fakeRepository);
            // Act
            boatService.AddBoat(boat1);
            boatService.AddBoat(boat2);
            // Assert
            Assert.Throws<NotImplementedException>(() => fakeRepository.GetAllWhereEntitiesMatchPredicate(p => p.Name.Equals("Helsike")).Count);
        }

        [Fact]
        public void DeleteShouldArchiveObjectInDB_Test()
        {
            // Arrange
            var boat1 = new Boat
            {
                Active = true,
                Description = "A boat",
                Entries = null,
                Handicap = 10.5,
                Id = 1,
                Model = null,
                Name = "SomeBoat",
                SailNo = 122
            };
            var boat2 = new Boat
            {
                Active = true,
                Description = "A boat",
                Entries = null,
                Handicap = 2.5,
                Id = 2,
                Model = null,
                Name = "SomeBoat2",
                SailNo = 122
            };
            fakeRepository = new FakeRepository<Boat>();
            boatService = new BoatService(fakeRepository);
            // Act
            boatService.AddBoat(boat1);
            boatService.AddBoat(boat2);
            boatService.DeleteBoat(boat1);
            // Assert
            boatService.GetBoatByName("SomeBoat");
            Assert.Equal(null, boatService.GetBoatByName("SomeBoat"));
        }

        //    [Fact]
        //    public void GetShouldReturnEntity_Test()
        //    {
        //        // Arrange
        //        var boat1 = new Mock<Iboat>();
        //        // Act
        //        fakeRepository = new FakeRepository<Boat>();
        //        // Assert

        //    }
    }
}
