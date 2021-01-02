using System.Collections.Generic;

namespace WebAPI.Models
{
    public class UserAuth
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<User> Users { get; set; }
    }
}