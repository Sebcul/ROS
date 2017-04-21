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
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _repository;
        public TeamService(IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.CreateRepository<Team>();
        }
    }
}
