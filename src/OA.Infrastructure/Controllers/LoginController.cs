using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Abstraction;
using System.Collections.Generic;
using System.Security.Claims;

namespace UserCRUD_demo_Project_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController:ControllerBase
    {
        private IServiceManager _serviceManager;
        public LoginController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        //login user
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            if (User.Identity.IsAuthenticated)
                return Unauthorized("you are already logged in please log out first!");
            var user = _serviceManager.UserService.GetByUsernameAndPassword(username, password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,user.UserRole),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = true });
                return Ok("you are logged in!");
            }
            else
                return Unauthorized("invalid username or password!");

        }

        //logout user
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized("You are already logged Out!");
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Logged out Successfully!");
        }
    }
}
