using Microsoft.AspNetCore.Mvc;
using UserApi.DataStore.Dto;
using UserApi.Services;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _repository;
        public UserController(IUserService repository)
        {
            _repository = repository;
        }

        [HttpPost("add")]
        public ActionResult AddUser(UserDto user)
        {
            _repository.AddUser(user);
            return Ok();
        }
        [HttpGet("exist")]
        public ActionResult ExistUser(string email)
        {
            return Ok(_repository.Exist(email));
        }
        [HttpGet("exist/{userId}")]
        public ActionResult ExistUser(Guid userId)
        {
            return Ok(_repository.Exist(userId));
        }
    }
}
