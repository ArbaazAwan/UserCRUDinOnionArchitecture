using AutoMapper;
using Domain.Model;
using OA.Contracts;
using OA.Service.Abstraction;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : IUserService
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;
        public UserServices(AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
          
        }
        #region ADD USER
        //Add User
        public string AddUser(UserDto user)
        {
            try
            {
                var mappedUser =_mapper.Map<User>(user);
                _dbContext.Users.Add(mappedUser);
                _dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {
                return "Failure";
            }
        }
        #endregion

        #region GET ALL USERS
        //Get All Users
        public List<UserDto> GetAllUsers()
        {
            var users = _dbContext.Users.ToList();
            List<UserDto> usersDtos =new List<UserDto>();
            foreach (var user in users)
            {
                usersDtos.Add(_mapper.Map<UserDto>(user));
            }
            return usersDtos;
        }
        #endregion

        #region GET USER BY ID
        //Get user by ID
        public UserDto GetUserByID(int Id)
        {
            var user = _dbContext.Users.Where(a => a.Id == Id).FirstOrDefault();
            var userdto = _mapper.Map<UserDto>(user);
            return userdto;
        }
        #endregion

        #region REMOVE USER
        public string RemoveUser(int Id)
        {
            try
            {
                var user = _dbContext.Users.Where(x=>x.Id==Id).FirstOrDefault();
                _dbContext.Remove(user);
                _dbContext.SaveChanges();
                return "success";
            }
            catch (Exception)
            {
                return "Failure";
            }
        }
        #endregion

        #region UPDATE USER
        //update the user
        public string UpdateUser(UserDto user)
        {
            try
            {
                var userValue = _dbContext.Users.Where(x => x.Id == user.Id).FirstOrDefault();
                if (userValue != null)
                {
                    userValue.UserName = user.UserName;
                    userValue.UserEmail = user.UserEmail;
                    userValue.UserPhone = user.UserPhone;
                    userValue.UserAddress = user.UserAddress;
                    _dbContext.SaveChanges();
                    return "Success";
                }
                else
                    return "User Doesn't Exists";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}
