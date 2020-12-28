using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Services.UserServices
{
    public interface IUserService
    {
         List<User> GetAllUsers();
         
         User GetUserById(int id);

         List<User> AddUser(User newUser);
    }
}