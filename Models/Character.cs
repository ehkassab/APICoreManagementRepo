namespace WebAPI.Models
{
    public class User
    {
        public int Id {get;set;}
        public string Name {get;set;} = "Eslam";
        public int HitPoints {get;set;} = 100;
        public int Strength {get;set;} = 10;
        public int  Defense {get;set;} = 10;
        public int Intelligence {get;set;} = 10;
        public UserTypeEnum UserType {get;set;} = UserTypeEnum.Developer;
    }
}