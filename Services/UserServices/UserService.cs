using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICoreManagementRepo.Models;
using WebAPI.Models;

namespace WebAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>{
            new User(),new User{Id = 1,Name = "A"},new User{Id = 2,Name = "B"},new User{Id = 3,Name = "C"},new User{Id = 4,Name = "D"}
        };
        
        public async Task<ServiceResponse<List<User>>> AddUser(User newUser)
        {
            ServiceResponse<List<User>> result = new ServiceResponse<List<User>>();
            result.Data = users;
            return result;
        }

        public async Task<ServiceResponse<List<User>>> GetAllUsers()
        {
             ServiceResponse<List<User>> result = new ServiceResponse<List<User>>();
            result.Data = users;
            return result;
        }

        public async Task<ServiceResponse<User>> GetUserById(int id)
        {
            ServiceResponse<User> result = new ServiceResponse<User>();
            result.Data = users.FirstOrDefault(t=>t.Id == id);
            return result;
        }
    }    
}