using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
     [Route("[controller]")]
    public class UserController : ControllerBase
    {
        // private static Character user = new Character();
        private static List<User> users = new List<User>{
            new User(),new User{Id = 1,Name = "Ahmed"}
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(users.FirstOrDefault(t=>t.Id == id));
        }
    }
}