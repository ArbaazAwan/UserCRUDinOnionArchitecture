using Domain.Model;
using OA.Domain.Repositories;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Prensentation.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Insert(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void Remove(int id)
        {
           var user = _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Users.Remove(user);
        }

        public void Update(User user)
        {
           var userValue = _dbContext.Users.Where(x=>x.Id == user.Id).FirstOrDefault();
            if(user!=null)
            {
                userValue.UserName = user.UserName;
                userValue.UserEmail = user.UserEmail;
                userValue.UserPhone = user.UserPhone;
                userValue.UserAddress = user.UserAddress;
                _dbContext.SaveChanges();
            }
        }
    }
}
