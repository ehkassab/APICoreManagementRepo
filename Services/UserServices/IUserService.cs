using System.Collections.Generic;
using System.Threading.Tasks;
using APICoreManagementRepo.Models;
using WebAPI.Models;

namespace WebAPI.Services.UserServices
{
    public interface IUserService
    {
         Task<ServiceResponse<List<User>>> GetAllUsers();
         Task<ServiceResponse<User>> GetUserById(int id);
         Task<ServiceResponse<List<User>>> AddUser(User newUser);
    }
}