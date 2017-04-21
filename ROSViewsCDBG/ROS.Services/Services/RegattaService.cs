using System;
using System.Collections.Generic;
using System.Linq;
using ROS.Services.Factories;
using ROS.Services.Models;
using ROS.Services.Services.Interfaces;
using ROSPersistence.Repository;
using ROSPersistence.ROSDB;

namespace ROS.Services.Services
{
    public class RegattaService : IRegattaService
    {
        private readonly IRepository<Regatta> _repository;

        public RegattaService(IRepositoryFactory repositoryFactory)
        {
            _repository = repositoryFactory.CreateRepository<Regatta>();
        }

        public IEnumerable<IRegattaUserRecord> FindRegattasParticipatedInByUserId(int id)
        {
            var regattas = _repository.GetAllWhereEntitiesMatchPredicate(
                regatta => regatta.Active && regatta.Entries.Any(
                    entry => entry.RegisteredUsers.Any(
                        user => user.Id == id)));

             return ConvertRegattasToRegattaUserRecords(regattas);
        }

        private List<IRegattaUserRecord> ConvertRegattasToRegattaUserRecords(IList<Regatta> regattas)
        {
            var regattaRecords = new List<IRegattaUserRecord>();

            foreach (var regatta in regattas)
            {
                regattaRecords.Add(RegattaRecordFactory.Instance.CreateRegattaRecord(regatta));
            }

            return regattaRecords;
        }



        public IEnumerable<Regatta> GetAllRegattas()
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(regatta => regatta.Active);
        }


        public IEnumerable<Regatta> GetUpcomingRegattas()
        {
            return
                _repository.GetAllWhereEntitiesMatchPredicate(
                    regatta => regatta.Active && regatta.StartTime > DateTime.Now);
        }


        public IEnumerable<Regatta> GetPastRegattas()
        {
            return _repository.GetAllWhereEntitiesMatchPredicate(regatta => regatta.Active &&
                                                                            regatta.EndTime < DateTime.Now);
        }
    }
}