using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApiLibrary;
using WebApiLibrary.Abstraction;
using WebApiLibrary.DataStore.Entities;
using WebApiLibrary.DataStore.Models;
using WebApiLibrary.rsa;

namespace UserApi.Services
{
    public class UserService : IUserService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private Account _account;

        public UserService(Account account, IConfiguration configuration, IMapper mapper, IDbContextFactory<AppDbContext> contextFactory)
        {
            _configuration = configuration;
            _mapper = mapper;
            _account = account;
            _contextFactory = contextFactory;
        }
        public async Task<UserResponse> Authentificate(LoginModel model)
        {
            UserEntity user = null;

            var context = await _contextFactory.CreateDbContextAsync();

            user = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == model.Email);
            if (user == null)
            {
                return UserResponse.UserNotFound();
            }

            if (CheckPassword(user.Salt, model.Password, user.Password))
            {
                _account = _mapper.Map<Account>(user);
                _account.RefreshToken(GenerateToken(_account));

                return UserResponse.OK();
            }

            return UserResponse.PasswordWrong();
        }

        public UserResponse AddAdmin(RegistrationModel model)
        {
            using (_context)
            {
                var userExist = _context.Users.Count(x => x.RoleType.Role == UserRole.Administrator);
                if (userExist > 0)
                    return UserResponse.AddAdminError();

                var entity = _mapper.Map<UserEntity>(model);

                entity.RoleType = new RoleEntity
                {
                    Role = UserRole.Administrator
                };

                _context.Users.Add(entity);
                _context.SaveChanges();
            }

            return UserResponse.OK();
        }

        public UserResponse AddUser(RegistrationModel model)
        {
            using (_context)
            {
                var userExist = _context.Users.FirstOrDefault(x => x.Email == model.Email.ToLower());

                if (userExist != null)
                    return UserResponse.UserExist();

                var entity = _mapper.Map<UserEntity>(model);
                entity.RoleType = new RoleEntity { Role = UserRole.User };

                _context.Users.Add(entity);
                _context.SaveChanges();
            }

            return UserResponse.OK();
        }


        public UserResponse DeleteUser(Guid? userId, string? email)
        {
            if (_account.Role != UserRole.Administrator)
                return UserResponse.AccessDenied();

            using (_context)
            {
                var query = _context.Users.AsQueryable();
                if (!string.IsNullOrEmpty(email))
                    query = query.Where(x => x.Email == email);
                if (userId.HasValue)
                    query = query.Where(x => x.Id == userId);


                var userExist = query.FirstOrDefault();

                if (userExist == null)
                    return UserResponse.UserNotFound();

                if (userExist.RoleType.Role == UserRole.Administrator)
                    return new UserResponse
                    {
                        Result = false,
                        Errors = new List<ErrorModel> { new ErrorModel { Message = "Нельзя удалить администратора" } }
                    };

                _context.Users.Remove(userExist);
                _context.SaveChanges();
            }

            return UserResponse.OK();
        }

        public UserResponse GetUser(Guid? userId, string? email)
        {
            var user = new UserEntity();

            using (_context)
            {
                var query = _context.Users.AsQueryable();
                if (!string.IsNullOrEmpty(email))
                    query = query.Where(x => x.Email == email);
                if (userId.HasValue)
                    query = query.Where(x => x.Id == userId);

                user = query.FirstOrDefault();
            }

            if (user == null)
                return UserResponse.UserNotFound();

            if (_account.Role == UserRole.Administrator || _account.Id == userId)
                return new UserResponse
                {
                    Result = true,
                    Users = new List<UserModel> { _mapper.Map<UserModel>(user) }
                };

            return UserResponse.AccessDenied();
        }

        public UserResponse GetUsers()
        {
            var users = new List<UserModel>();

            if (_account.Role != UserRole.Administrator)
                return UserResponse.AccessDenied();

            using (_context)
            {
                users.AddRange(_context.Users.Select(x => _mapper.Map<UserModel>(x)).ToList());
            }

            return new UserResponse
            {
                Result = true,
                Users = users
            };
        }

        private string GenerateToken(Account model)
        {
            var key = new RsaSecurityKey(RSAService.GetPrivateKey());
            var credential = new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature);
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

        private bool CheckPassword(byte[] salt, string password, byte[] dbPassword)
        {
            var data = Encoding.ASCII.GetBytes(password).Concat(salt).ToArray();
            SHA512 shaM = new SHA512Managed();
            var pass = shaM.ComputeHash(data);

            return dbPassword.SequenceEqual(pass);
        }

    }
}
