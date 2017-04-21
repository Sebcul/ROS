using ROSPersistence.ROSDB;

namespace ROS.Services.Models
{
    public class RegattaUserRecord : IRegattaUserRecord
    {
        private readonly Regatta _regatta;


        public RegattaUserRecord(Regatta regatta)
        {
            _regatta = regatta;
        }


        public string Name { get { return _regatta.Name; } }


        public string StartDate { get { return $"{_regatta.StartTime:u}"; } }

        public string EndDate { get { return $"{_regatta.EndTime:u}"; } }

    }
}