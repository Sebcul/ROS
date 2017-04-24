using System.Collections.Generic;
using ROS.Services.Models;
using ROSPersistence.ROSDB;

namespace ROS.Services.Services.Interfaces
{
    public interface IRegattaService
    {
        IEnumerable<IRegattaUserRecord> FindRegattasParticipatedInByUserId(int id);
        IEnumerable<Regatta> GetAllRegattas();
        IEnumerable<Regatta> GetOngoingRegattas();
        IEnumerable<Regatta> GetPastRegattas();
        IEnumerable<Regatta> GetUpcomingRegattas();
        IEnumerable<IRegattaUserRecord> FindUsersOngoingRegattasById(int id);
        IEnumerable<IRegattaUserRecord> FindUsersUpcomingRegattasByUserId(int id);
        void AddRegatta(Regatta regatta);
    }
}