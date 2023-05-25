using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }

       public int Score { get; set; }

       public int Points { get;set; }

        public int TravelMode { get; set; } = 0;

        public string Name { get; set; } = "User";
        public int IdPersona { get; set; }
        public int IdUniversity { get; set; }

        public List<UserDTO> Friends { get; set; } = new List<UserDTO>();
        public int IdUID { get; set; } = -1;

    }
}