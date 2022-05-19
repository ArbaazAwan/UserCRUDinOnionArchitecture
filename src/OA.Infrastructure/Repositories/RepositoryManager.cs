using OA.Domain.Repositories;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Prensentation.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUserRepository> _userRepository;
        public RepositoryManager(AppDbContext dbContext)
        {
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(dbContext));
        }
        public IUserRepository userRepository => _userRepository.Value;
    }
}
