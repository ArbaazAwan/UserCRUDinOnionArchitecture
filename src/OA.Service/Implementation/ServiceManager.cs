using OA.Domain.Repositories;
using OA.Service.Abstraction;
using System;

namespace OA.Service.Implementation
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _lazyuserService;
        public ServiceManager(IRepositoryManager repositoryManger)
        {
            _lazyuserService = new Lazy<IUserService>(() => new UserServices(repositoryManger));
        }
        public IUserService UserService => _lazyuserService.Value;
    }
}