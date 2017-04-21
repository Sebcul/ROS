using Ros.Services.Services;
using Ros.Services.Services.Interfaces;
using ROS.Services.Services;
using ROS.Services.Services.Interfaces;
using ROSPersistence.Repository;

namespace ROS.Services
{
    public class ServiceLocator
    {
        private static readonly object CreationLock = new object();
        private readonly IRepositoryFactory _repositoryFactory;
        private static ServiceLocator _instance;
        public static ServiceLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (CreationLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ServiceLocator();
                        }
                    }
                }
                return _instance;
            }
        }

        public ServiceLocator()
        {
            _repositoryFactory = RepositoryFactory.Instance;
        }

        public static IAddUserService AddUserService => new AddUserService(_instance._repositoryFactory);

        public static IUserService UserService => new UserService(_instance._repositoryFactory);

        public static IBoatService BoatService => new BoatService(_instance._repositoryFactory);

        public static IEntryService EntryService => new EntryService(_instance._repositoryFactory);

        public static ILoginService LoginService => new LoginService(_instance._repositoryFactory);

        public static IPasswordService PasswordService => new PasswordService(_instance._repositoryFactory);

        public static IRegattaService RegattaService => new RegattaService(_instance._repositoryFactory);

        public static IResultService ResultService => new ResultService(_instance._repositoryFactory);

        public static ITeamService TeamService => new TeamService(_instance._repositoryFactory);

    }
}
