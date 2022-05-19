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
        private IServiceManager _serviceManager;
        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        //get all users
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            return Ok(_serviceManager.UserService.GetAllUsers());
        }

        //get one user
        [HttpGet]
        [Route("get")]
        public IActionResult GetUser(int Id)
        {
            if (_serviceManager.UserService.GetUserByID(Id) != null)
                return Ok(_serviceManager.UserService.GetUserByID(Id));
            else
                return NotFound("User doesn't exists!");
        }

        //add user
        [HttpPost("add")]
        public IActionResult AddUser(UserDto user)
        {

            return Ok(_serviceManager.UserService.AddUser(user));
        }
        //remove user
        [HttpDelete("{Id}")]
        public IActionResult RemoveUser(int Id)
        {
            return Ok(_serviceManager.UserService.RemoveUser(Id));
        }
        //update user
        [HttpPut("update")]
        public IActionResult UpdateUser(UserDto user)
        {

            return Ok( _serviceManager.UserService.UpdateUser(user));
        }

    }
}
