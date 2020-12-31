using WebAPI.Models;

namespace APICoreManagementRepo.DTOs.User
{
    public class GetUserDTO
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public int HitPoints {get;set;}
        public int Strength {get;set;}
        public int  Defense {get;set;}
        public int Intelligence {get;set;}
        public UserTypeEnum UserType {get;set;}
    }
}