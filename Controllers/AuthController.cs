using APICoreManagementRepo.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using APICoreManagementRepo.DTOs.Auth;
using System.Threading.Tasks;
using APICoreManagementRepo.Models;
using WebAPI.Models;

namespace APICoreManagementRepo.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(AuthRegDTO request)
        {
            ServiceResponse<int> response = await _authServices.Register(
                new UserAuth { UserName = request.UserName }, request.Password
            );

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthLoginDTO request)
        {
            ServiceResponse<string> response = await _authServices.Login(request.UserName,request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}