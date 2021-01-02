using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APICoreManagementRepo.Data;
using APICoreManagementRepo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models;

namespace APICoreManagementRepo.Services.Auth
{
    public class AuthServices : IAuthServices
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthServices(DataContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(string userName, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            UserAuth auth = await _context.Auths.FirstOrDefaultAsync(x=>x.UserName.ToLower() == userName.ToLower());
            if(auth == null)
            {
                response.Success = false;
                response.Message = "User Not Found";
            }
            else if (!VerifyPasswordHash(password,auth.PasswordHash,auth.PasswordSalt))
            {
                response.Success =false;
                response.Message = "Wrong Password";
            }
            else
            {
                response.Data = CreateToken(auth);
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(UserAuth user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await UserExist(user.UserName))
            {
                response.Success = false;
                response.Message = "UserAlreadyExist";
                return response;
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _context.Auths.AddAsync(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExist(string userName)
        {
            if(await _context.Auths.AnyAsync(x=>x.UserName.ToLower() == userName.ToLower()))
            {
                return true;
            } 
            return false;
        }

        private void CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i=0; i<computeHash.Length;i++)
                {
                    if(computeHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CreateToken(UserAuth user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value)
            );
            
            SigningCredentials creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokendesc = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHand = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHand.CreateToken(tokendesc);
            return tokenHand.WriteToken(token);
        }
    }
}