using WebApiLibrary.DataStore.Models;
using WebApiLibrary.DataStore.Response;

namespace WebApiLibrary.Abstraction
{
    public interface IUserService
    {
        
        UserResponse Register(RegistrationModel model);
        UserResponse Aythentificate(LoginModel model);
        UserResponse AddUser(UserModel model);
        UserResponse GetUsers();
        UserResponse GetUser(Guid? userId, string? email);
        UserResponse DeleteUser(Guid? userId, string? email);
        Guid GetCurrentUserId();
    }
}
