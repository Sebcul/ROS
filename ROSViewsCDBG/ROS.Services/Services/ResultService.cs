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
    class ResultService : IResultService
    {
        private readonly IRepository<Result> _repository;
        public ResultService(IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.CreateRepository<Result>();
        }
    }
}
