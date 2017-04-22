using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROS.Services.Models;
using ROSPersistence.ROSDB;

namespace ROS.Services.Factories
{
    class ModelFactory : IModelFactory
    {
        public static readonly IModelFactory Instance = new ModelFactory();

        private ModelFactory() { }

        public IRegattaUserRecord CreateRegattaRecord(IRegatta regatta)
        {
            return new RegattaUserRecord(regatta);
        }

        public IUserInfo CreateUserInfo(IUser user)
        {
            return new UserInfo(user);
        }
        
    }
}
