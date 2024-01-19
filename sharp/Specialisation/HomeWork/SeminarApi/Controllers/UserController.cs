using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SeminarApi.Abstraction;

namespace SeminarApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(string login, string password)
        {
            var token = _userService.CheckUserRole(login, password);
            if (!token.IsNullOrEmpty())
                return Ok(token);

            return NotFound("User not found");
        }
    }
}
