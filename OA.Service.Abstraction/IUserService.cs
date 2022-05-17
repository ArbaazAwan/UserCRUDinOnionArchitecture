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
        public List<UserDto> GetAllUsers();
        //Get user by ID
        public UserDto GetUserByID(int Id);
        //remove User
        public string RemoveUser(int Id);
        //update the user
        public string UpdateUser(UserDto user);

    }
}
