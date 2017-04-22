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

        public void DeleteTeam(Team team)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(Team team)
        {
            _repository.UpdateEntity(team);
        }

        public void AddTeam(Team team)
        {
            _repository.InsertEntity(team);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(Team => Team.Active);
        }

        public ITeam GetTeamByName(string name)
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(Team => Team.Name == name).FirstOrDefault();
        }
    }
}
