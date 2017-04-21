using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ros.Services.Services.Interfaces;
using ROSPersistence.Repository;
using ROSPersistence.ROSDB;

namespace Ros.Services.Services
{
    public class EntryService : IEntryService
    {
        private readonly IRepository<Entry> _repository;

        public EntryService(IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.CreateRepository<Entry>();
        }

        public void DeleteEntry(Entry entry)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntry(Entry entry)
        {
            _repository.UpdateEntity(entry);
        }

        public void AddEntry(Entry entry)
        {
            _repository.InsertEntity(entry);
        }

        public List<Entry> GetAllEnteries()
        {
            return _repository.GetAllWhereEntitiesMatchPredicate((e => e.Active)).ToList();
        }
        public Entry GetEntry(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}
