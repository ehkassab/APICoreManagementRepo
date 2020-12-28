using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>{
            new User(),new User{Id = 1,Name = "A"},new User{Id = 2,Name = "B"},new User{Id = 3,Name = "C"},new User{Id = 4,Name = "D"}
        };
        
        public async Task<List<User>> AddUser(User newUser)
        {
            return users;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return users;
        }

        public async Task<User> GetUserById(int id)
        {
           return users.FirstOrDefault(t=>t.Id == id);
        }
    }
}