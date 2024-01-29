using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiLibrary;
using WebApiLibrary.Abstraction;
using WebApiLibrary.DataStore.Models;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private Account _account;


        public UserController(IUserService userService, Account account)
        {
            _account = account;
            _userService = userService;

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([Description("Аутентификация пользователя"), FromBody] LoginModel model)
        {
            if (_account.GetAccessToken() != null)
                return BadRequest("вы уже вошли в систему");
            var response = _userService.Aythentificate(model);
            if (!response.Result)
                return NotFound(response.Errors.FirstOrDefault()?.Message);

            return Ok();


        }

        [HttpPost("logout")]
        public ActionResult LogOut()
        {
            _account = null;
            return Ok();
        }
    }
}
