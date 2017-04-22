using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROSPersistence.ROSDB;

namespace Ros.Services.Services.Interfaces
{
    public interface ITeamService
    {
        void DeleteTeam(Team team);

        void UpdateTeam(Team team);

        void AddTeam(Team team);

        IEnumerable<Team> GetAllTeams();

        ITeam GetTeamByName(string name);
    }
}
