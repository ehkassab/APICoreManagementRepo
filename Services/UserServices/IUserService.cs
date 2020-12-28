using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services.UserServices
{
    public interface IUserService
    {
         Task<List<User>> GetAllUsers();
         
         Task<User> GetUserById(int id);

         Task<List<User>> AddUser(User newUser);
    }
}