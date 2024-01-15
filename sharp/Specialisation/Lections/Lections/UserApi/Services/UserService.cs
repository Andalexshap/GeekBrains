using AutoMapper;
using UserApi.DataStore;
using UserApi.DataStore.Dto;

namespace UserApi.Services
{
    public interface IUserService
    {
        void AddUser(UserDto user);
        bool Exist(string email);
        bool Exist(Guid id);
    }
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public UserService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddUser(UserDto user)
        {
            using (_context)
            {
                var entity = _mapper.Map<UserEntity>(user);
                _context.Users.Add(entity);
                _context.SaveChanges();
            }
        }

        public bool Exist(string email)
        {
            using (_context)
                return _context.Users.FirstOrDefault(x => x.Active && x.Email == email) != null;
        }

        public bool Exist(Guid id)
        {
            using (_context)
                return _context.Users.FirstOrDefault(x => x.Active && x.Id == id) != null;
        }
    }
}
