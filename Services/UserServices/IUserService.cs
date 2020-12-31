using System.Collections.Generic;
using System.Threading.Tasks;
using APICoreManagementRepo.Models;
using WebAPI.Models;
using APICoreManagementRepo.DTOs.User;

namespace WebAPI.Services.UserServices
{
    public interface IUserService
    {
         Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers();
         Task<ServiceResponse<GetUserDTO>> GetUserById(int id);
         Task<ServiceResponse<List<GetUserDTO>>> AddUser(PostUserDTO newUser);
    }
}