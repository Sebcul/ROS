using Ros.Services.Services;
using Ros.Services.Services.Interfaces;
using ROSPersistence.Repository;
using ROSPersistence.ROSDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ROS.Services.Test.Service_Tests
{
    public class EntryServiceTests
    {
        public class FakeRepository<T> : IRepository<T> where T : Entry
        {
            private Dictionary<int, T> _data = new Dictionary<int, T>();

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

        public class EntryService : IEntryService
        {
            private readonly FakeRepository<Entry> fakeRepository;

            public EntryService(FakeRepository<Entry> fakeRepository)
            {
                this.fakeRepository = fakeRepository;
            }

            public void DeleteEntry(Entry entry)
            {
                fakeRepository.Delete(entry);
            }

            public void UpdateEntry(Entry entry)
            {
                fakeRepository.UpdateEntity(entry);
            }

            public void AddEntry(Entry entry)
            {
                fakeRepository.Add(entry);
            }

            public Entry GetEntry(int id)
            {
                return fakeRepository.Get(id);
            }

            public List<Entry> GetAllEnteries()
            {
                return fakeRepository.GetAllWhereEntitiesMatchPredicate(x => x.Active).ToList();
            }

        }

        public EntryService entryService;
        public FakeRepository<Entry> fakeRepository;

        [Fact]
        public void ShouldBeAble_ToGet_RightRegattaId_From_EntryId()
        {
            // Arrange
            var entry1 = new Entry
            {
                Active = true,
                Description = "Anmälan",              
                Id = 1,
                No = 1,
                RegistrationDate = DateTime.Now,
                TotalSumPaid = null,
                SkipperId = 1,
                BoatId = 1,
                RegattadId = 1,
                EventsFees = null,
                RegisteredUsers = null,
                RegattasFees = null,
                Teams = null              
             
            };
            var entry2 = new Entry
            {
                Active = true,
                Description = "Hej",
                Id = 2,
                No = 2,
                RegistrationDate = DateTime.Now,
                TotalSumPaid = null,
                SkipperId = 2,
                BoatId = 2,
                RegattadId = 2,
                EventsFees = null,
                RegisteredUsers = null,
                RegattasFees = null,
                Teams = null
            };
            fakeRepository = new FakeRepository<Entry>();
            entryService = new EntryService(fakeRepository);

            // Act
            entryService.AddEntry(entry1);
            entryService.AddEntry(entry2);

            // Assert
            fakeRepository.Get(1).RegattadId.Equals(1);
            fakeRepository.Get(2).RegattadId.Equals(2);
        }
       

    }
}
