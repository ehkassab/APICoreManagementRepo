using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Services.UserServices
{
    public interface IUserService
    {
         List<User> GetAllUsers();
         
         User GetUserById();

         List<User> AddUser(User newUser);
    }
}