using AutoMapper;
using WebAPI.Models;
using APICoreManagementRepo.DTOs.User;

namespace APICoreManagementRepo
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User,GetUserDTO>();
            CreateMap<PostUserDTO,User>();
        }
    }
}