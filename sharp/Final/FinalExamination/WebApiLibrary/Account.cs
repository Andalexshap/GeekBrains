using WebApiLibrary.DataStore.Models;

namespace WebApiLibrary
{
    public class Account : UserModel
    {
        private string? Token { get; set; }

        public string RefreshToken(string newToken)
        {
            Token = newToken;
            return Token;
        }
        public string GetAccessToken() => Token;
    }
}
