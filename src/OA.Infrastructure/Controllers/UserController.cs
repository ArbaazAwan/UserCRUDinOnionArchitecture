using AutoMapper;
using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Contracts;
using OA.Service.Abstraction;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserCRUD_demo_Project_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _user;
        public UserController(IUserService user )
        {
            _user = user;
        }

        //get all users
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            return Ok(_user.GetAllUsers());
        }

        //get one user
        [HttpGet]
        [Route("get")]
        public IActionResult GetUser(int Id)
        {
            return Ok(_user.GetUserByID(Id));
        }

        //add user
        [HttpPost("add")]
        public IActionResult AddUser(UserDto user)
        {

            return Ok(_user.AddUser(user));
        }
        //remove user
        [HttpDelete("{Id}")]
        public IActionResult RemoveUser(int Id)
        {
            return Ok(_user.RemoveUser(Id));
        }
        //update user
        [HttpPut("update")]
        public IActionResult UpdateUser(UserDto user)
        {
            return Ok( _user.UpdateUser(user));
        }

    }
}
