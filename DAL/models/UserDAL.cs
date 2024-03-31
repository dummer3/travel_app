using System.ComponentModel.DataAnnotations;

namespace DAL.models
{
    public class UserDAL
    {
        [Key]
        public int IdUser { get; set; }
        public int Score { get; set; }
        public int Point { get; set; }
        public string Password { get; set; }
        public int TravelMode { get; set; } = 0;
        public string UserName { get; set; } = "user";
        public PersonaDAL Persona { get; set; } = new PersonaDAL();
        public UniversityDAL University { get; set; } = new UniversityDAL();
        public List<UserDAL> Friends { get;set; } = new List<UserDAL>();
        public string JsonContent { get; set; } = "";
    }
}