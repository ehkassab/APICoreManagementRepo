using System.Threading.Tasks;
using APICoreManagementRepo.Models;
using WebAPI.Models;

namespace APICoreManagementRepo.Services.Auth
{
    public interface IAuthServices
    {
         Task<ServiceResponse<int>> Register(UserAuth user, string password);
         Task<ServiceResponse<string>> Login(string userName, string password);
         Task<bool> UserExist(string userName);
    }
}