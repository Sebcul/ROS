using ROSPersistence.ROSDB;

namespace ROS.Services.Models
{
    public class RegattaUserRecord : IRegattaUserRecord
    {
        private readonly IRegatta _regatta;

        public RegattaUserRecord(IRegatta regatta)
        {
            _regatta = regatta;
        }


        public string Name { get { return _regatta.Name; } }


        public string Location { get { return _regatta.Location; } }


        public string StartDate { get { return $"{_regatta.StartTime:u}"; } }

        public string EndDate { get { return $"{_regatta.EndTime:u}"; } }
    }
}