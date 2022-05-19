using Domain.Model;
using Mapster;
using OA.Contracts;
using OA.Domain.Repositories;
using OA.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Implementation
{
    internal sealed class UserServices : IUserService
    {
        private IRepositoryManager _repositoryManager;
        public UserServices(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;

        }
        #region ADD USER
        public string AddUser(UserDto user)
        {
            try
            {
                var mappedUser = user.Adapt<User>();
                //_dbContext.Users.Add(mappedUser);
                //_dbContext.SaveChanges();
                _repositoryManager.userRepository.Insert(mappedUser);
                return "Success";
            }
            catch (Exception)
            {
                return "Failure";
            }
        }
        #endregion

        #region GET ALL USERS
        public List<UserDto> GetAllUsers()
        {
            try
            {
                var users = _repositoryManager.userRepository.GetAllUsers();
                var usersDtos = new List<UserDto>();

                foreach (var user in users)
                {
                    if (user != null)
                        usersDtos.Add(user.Adapt<UserDto>()); //map and store in usersdto collecitons
                }
                return usersDtos;
            }
            catch (Exception)
            {
                throw;
            }
            

        }
        #endregion

        #region GET USER BY ID
        public UserDto GetUserByID(int Id)
        {
            var user = _repositoryManager.userRepository.GetUserById(Id);
            var userdto = user.Adapt<UserDto>(); //mapping from user to userdto
            return userdto;
        }
        #endregion

        #region REMOVE USER
        public string RemoveUser(int Id)
        {
            try
            {
                //var user = _dbContext.Users.Where(x=>x.Id==Id).FirstOrDefault();
                //_dbContext.Remove(user);
                //_dbContext.SaveChanges();
                _repositoryManager.userRepository.Remove(Id);
                return "User Removed Successfully!";
            }
            catch (Exception)
            {
                return "Failure";
            }
        }
        #endregion

        #region UPDATE USER
        public string UpdateUser(UserDto userDto)
        {
            try
            {
                var user = userDto.Adapt<User>();
                if (user != null)
                {
                    _repositoryManager.userRepository.Update(user);
                    //userValue.UserName = user.UserName;
                    //userValue.UserEmail = user.UserEmail;
                    //userValue.UserPhone = user.UserPhone;
                    //userValue.UserAddress = user.UserAddress;
                    //_dbContext.SaveChanges();
                    return "User has been Updated";
                }
                else
                    return "Something went wrong or user doesn't exists!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}
