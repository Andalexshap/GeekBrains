using System.ComponentModel;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApiLibrary.Abstraction;
using WebApiLibrary.DataStore.Models;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controler]")]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([Description("Аутентификация пользователя"),FromBody] LoginModel model)
        {
            var response = _userService.Aythentificate(model);
            if (response.Result)
                return NotFound($"{response.Errors.FirstOrDefault().Message}");


        }
    }
}
