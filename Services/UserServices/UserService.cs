using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICoreManagementRepo.DTOs.User;
using APICoreManagementRepo.Models;
using AutoMapper;
using WebAPI.Models;

namespace WebAPI.Services.UserServices
{
    public class UserService : IUserService
    {

        private readonly IMapper _mapper;
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }
        private static List<User> users = new List<User>{
            new User(),
            new User{Id = 1,Name = "A", UserType = UserTypeEnum.Developer},
            new User{Id = 2,Name = "B", UserType = UserTypeEnum.Admin},
            new User{Id = 3,Name = "C", UserType = UserTypeEnum.Manager},
            new User{Id = 4,Name = "D", UserType = UserTypeEnum.Manager}
        };
        
        public async Task<ServiceResponse<List<GetUserDTO>>> AddUser(PostUserDTO newUser)
        {
            ServiceResponse<List<GetUserDTO>> result = new ServiceResponse<List<GetUserDTO>>();
            users.Add(_mapper.Map<User>(newUser));
            result.Data = users.Select(c=> _mapper.Map<GetUserDTO>(c)).ToList();
            return result;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers()
        {
             ServiceResponse<List<GetUserDTO>> result = new ServiceResponse<List<GetUserDTO>>();
            result.Data = users.Select(c=> _mapper.Map<GetUserDTO>(c)).ToList();
            return result;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUserById(int id)
        {
            ServiceResponse<GetUserDTO> result = new ServiceResponse<GetUserDTO>();
            result.Data = _mapper.Map<GetUserDTO>(users.FirstOrDefault(t=>t.Id == id));
            return result;
        }
    }    
}