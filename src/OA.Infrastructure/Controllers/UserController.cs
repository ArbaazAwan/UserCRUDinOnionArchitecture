using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OA.Contracts;
using OA.Service.Abstraction;
using System.Collections.Generic;
using System.Security.Claims;

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
            //if (User.Identity.IsAuthenticated)
                return Ok(_serviceManager.UserService.GetAllUsers());
            //return Unauthorized("you are not Authorized!:Please Login");
        }

        //get one user
        [HttpGet]
        [Route("get")]
        public IActionResult GetUser(int Id)
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized("You are not Authorized!:Please Login");
            var user = _serviceManager.UserService.GetUserByID(Id);
            if (user != null)
            {   
                    return Ok(_serviceManager.UserService.GetUserByID(Id));
            }
            else
                return NotFound("User doesn't exists!");
        }

        //add user
        [HttpPost("add")]
        public IActionResult AddUser(UserDto user)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                return Ok(_serviceManager.UserService.AddUser(user));
            return Unauthorized("You are not Authorized to add a user!");
            
        }
        //remove user
        [HttpDelete("{Id}")]
        public IActionResult RemoveUser(int Id)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                return Ok(_serviceManager.UserService.RemoveUser(Id));
            return Unauthorized("You are not Authorized to remove a user!");
            
        }
        //update user
        [HttpPut("update")]
        public IActionResult UpdateUser(UserDto user)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                return Ok( _serviceManager.UserService.UpdateUser(user));
            return Unauthorized("You are not Authorized to update a user!");
            
        }

    }
}
