using Microsoft.AspNetCore.Mvc;
using OA.Contracts;
using OA.Service.Abstraction;
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
        private IUserService _userService;
        public UserController(IUserService userService )
        {
            _userService = userService;
        }

        //get all users
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAllUsers());
        }

        //get one user
        [HttpGet]
        [Route("get")]
        public IActionResult GetUser(int Id)
        {
            if (_userService.GetUserByID(Id) != null)
                return Ok(_userService.GetUserByID(Id));
            else
                return NotFound("User doesn't exists!");
        }

        //add user
        [HttpPost("add")]
        public IActionResult AddUser(UserDto user)
        {

            return Ok(_userService.AddUser(user));
        }
        //remove user
        [HttpDelete("{Id}")]
        public IActionResult RemoveUser(int Id)
        {
            return Ok(_userService.RemoveUser(Id));
        }
        //update user
        [HttpPut("update")]
        public IActionResult UpdateUser(UserDto user)
        {
            return Ok( _userService.UpdateUser(user));
        }

    }
}
