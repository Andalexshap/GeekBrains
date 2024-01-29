using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiLibrary.DataStore.Models;

namespace WebApiLibrary.DataStore.Response
{
    public class UserResponse
    {
        public bool Result { get; set; }
        public List<Error> Errors = new List<Error>();
        public List<UserModel> Users = new List<UserModel>();
        public string Token { get; set; }
    }
}
