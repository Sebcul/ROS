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

        public IAddUserService AddUserService => new AddUserService(_instance._repositoryFactory);

        public IUserService UserService => new UserService(_instance._repositoryFactory);

        public IBoatService BoatService => new BoatService(_instance._repositoryFactory);

        public IEntryService EntryService => new EntryService(_instance._repositoryFactory);

        public ILoginService LoginService => new LoginService(_instance._repositoryFactory);

        public IPasswordService PasswordService => new PasswordService(_instance._repositoryFactory);

        public IRegattaService RegattaService => new RegattaService(_instance._repositoryFactory);

        public IResultService ResultService => new ResultService(_instance._repositoryFactory);

        public ITeamService TeamService => new TeamService(_instance._repositoryFactory);

    }
}
