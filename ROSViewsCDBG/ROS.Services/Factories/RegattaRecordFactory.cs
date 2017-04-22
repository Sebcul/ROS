using ROS.Services.Models;
using ROSPersistence.ROSDB;

namespace ROS.Services.Factories
{
    public class RegattaRecordFactory
    {
        public static readonly RegattaRecordFactory Instance = new RegattaRecordFactory();

        private RegattaRecordFactory() { }

        public IRegattaUserRecord CreateRegattaRecord(Regatta regatta)
        {
            return new RegattaUserRecord(regatta);
        }
    }
}