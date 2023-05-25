using System.ComponentModel.DataAnnotations;

namespace DAL.models
{
    public class UserDAL
    {
        [Key]
        public int IdUser { get; set; }
        public int Score { get; set; } = 20;
        public int Point { get; set; } = 20;
        public int IdUID { get; set; } = -1;
        public int TravelMode { get; set; } = 0;
        public string Name { get; set; } = "user";
        public PersonaDAL Persona { get; set; } = new PersonaDAL();
        public UniversityDAL University { get; set; } = new UniversityDAL();

        public List<UserDAL> Friends { get;set; } = new List<UserDAL>();
    }
}