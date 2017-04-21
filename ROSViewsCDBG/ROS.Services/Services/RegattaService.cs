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

        public IEnumerable<IRegattaRecord> FindRegattaHistoryByUserId(int id)
        {
            var regattas = _repository.GetAllWhereEntitiesMatchPredicate(
                regatta => regatta.Active && regatta.Entries.Any(
                    entry => entry.RegisteredUsers.Any(
                        user => user.Id == id)));

             return ConvertRegattasToRegattaRecords(regattas);
        }



        private List<IRegattaRecord> ConvertRegattasToRegattaRecords(IList<Regatta> regattas)
        {
            var regattaRecords = new List<IRegattaRecord>();

            foreach (var regatta in regattas)
            {
                regattaRecords.Add(RegattaRecordFactory.Instance.CreateRegattaRecord(regatta));
            }

            return regattaRecords;
        }
    }
}