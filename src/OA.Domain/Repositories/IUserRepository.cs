using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain.Repositories
{
    public interface IUserRepository
    {
        //getall
        public List<User> GetAllUsers();
        //get by id
        public User GetUserById(int id);
        //get by username and password
        public User GetByUsernameAndPassword(string username, string password);
        //add
        public void Insert(User user);
        //remove
        public void Remove(int id);
        //update
        public void Update(User user);
    }
}
