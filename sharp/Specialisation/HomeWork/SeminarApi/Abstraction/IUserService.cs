using SeminarApi.DataStore.Entity;

namespace SeminarApi.Abstraction
{
    public interface IUserService
    {
        public Guid UserAdd(string name, string password, UserRole roleId);
        public string CheckUserRole(string name, string password);


    }
}
