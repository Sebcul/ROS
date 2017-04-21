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
    class EntryService : IEntryService
    {
        private readonly IRepository<Entry> _repository;

        public EntryService(IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.CreateRepository<Entry>();
        }
    }
}
