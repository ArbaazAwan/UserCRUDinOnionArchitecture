using Domain.Model;
using OA.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Abstraction
{
    public interface IUserService
    {
        //Add User
        public string AddUser(UserDto user);
        //Get All Users
        public List<DisplayUserDto> GetAllUsers();
        //Get user by ID
        public DisplayUserDto GetUserByID(int Id);
        //get user by username and password
        public User GetByUsernameAndPassword(string username, string password);
        //remove User
        public string RemoveUser(int Id);
        //update the user
        public string UpdateUser(UserDto user);
    }
}
