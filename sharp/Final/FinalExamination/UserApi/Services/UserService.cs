using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using WebApiLibrary.Abstraction;
using WebApiLibrary.DataStore.Models;
using WebApiLibrary.DataStore.Response;

namespace UserApi.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
        public UserResponse Aythentificate(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public UserResponse AddUser(UserModel model)
        {
            throw new NotImplementedException();
        }


        public UserResponse DeleteUser(Guid? userId, string? email)
        {
            throw new NotImplementedException();
        }

        public Guid GetCurrentUserId()
        {
            throw new NotImplementedException();
        }

        public UserResponse GetUser(Guid? userId, string? email)
        {
            throw new NotImplementedException();
        }

        public UserResponse GetUsers()
        {
            throw new NotImplementedException();
        }

        public UserResponse Register(RegistrationModel model)
        {
            throw new NotImplementedException();
        }
        private string GenerateToken(UserModel model)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.Role, model.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, model.Id.ToString())
            };
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credential);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
