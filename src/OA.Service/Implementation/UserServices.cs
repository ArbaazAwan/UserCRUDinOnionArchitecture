using AutoMapper;
using Domain.Model;
using OA.Contracts;
using OA.Domain.Repositories;
using OA.Service.Abstraction;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class UserServices : IUserService
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;
        private IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository,AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userRepository = userRepository;
          
        }
        #region ADD USER
        //Add User
        public string AddUser(UserDto user)
        {
            try
            {
                var mappedUser =_mapper.Map<User>(user);
                //_dbContext.Users.Add(mappedUser);
                //_dbContext.SaveChanges();
                _userRepository.Insert(mappedUser);
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
            var users = _userRepository.GetAllUsers();
            var usersDtos =new List<UserDto>();
            foreach (var user in users)
            {
                usersDtos.Add(_mapper.Map<UserDto>(user)); //map and store in usersdto collecitons
            }
            return usersDtos;
        }
        #endregion

        #region GET USER BY ID
        //Get user by ID
        public UserDto GetUserByID(int Id)
        {
            var user = _userRepository.GetUserById(Id);
            var userdto = _mapper.Map<UserDto>(user); //mapping from user to userdto
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
                _userRepository.Remove(Id);
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
        public string UpdateUser(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                _userRepository.Update(user);
                //userValue.UserName = user.UserName;
                //userValue.UserEmail = user.UserEmail;
                //userValue.UserPhone = user.UserPhone;
                //userValue.UserAddress = user.UserAddress;
                //_dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}
