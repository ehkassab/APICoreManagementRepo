using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>{
            new User(),new User{Id = 1,Name = "Ahmed"}
        };

        public System.Collections.Generic.List<User> AddUser(User newUser)
        {
            return users;
        }

        public System.Collections.Generic.List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserById(int id)
        {
           return users.FirstOrDefault(t=>t.Id == id);
        }
    }
}