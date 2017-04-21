using ROSPersistence.ROSDB;

namespace ROS.Services.Models
{
    public class RegattaRecord : IRegattaRecord
    {
        private readonly Regatta _regatta;


        public RegattaRecord(Regatta regatta)
        {
            _regatta = regatta;
        }


        public string Name { get { return _regatta.Name; } }


        public string StartDate { get { return $"{_regatta.StartTime:u}"; } }

        public string EndDate { get { return $"{_regatta.EndTime:u}"; } }

    }
}