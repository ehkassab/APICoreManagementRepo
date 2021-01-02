using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICoreManagementRepo.Data;
using APICoreManagementRepo.DTOs.User;
using APICoreManagementRepo.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Services.UserServices
{
    public class UserService : IUserService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UserService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
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
            await _context.User.AddAsync(_mapper.Map<User>(newUser));
            await _context.SaveChangesAsync();
            result.Data = _context.User.Select(c=> _mapper.Map<GetUserDTO>(c)).ToList();
            return result;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUsers()
        {
            ServiceResponse<List<GetUserDTO>> result = new ServiceResponse<List<GetUserDTO>>();
            List<User> dbUSers = await _context.User.ToListAsync();
            result.Data = dbUSers.Select(c => _mapper.Map<GetUserDTO>(c)).ToList();
            return result;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUserById(int id)
        {
            ServiceResponse<GetUserDTO> result = new ServiceResponse<GetUserDTO>();
            User dbuser = await _context.User.FirstOrDefaultAsync(y=>y.Id == id);
            result.Data = _mapper.Map<GetUserDTO>(dbuser);
            return result;
        }
    }    
}