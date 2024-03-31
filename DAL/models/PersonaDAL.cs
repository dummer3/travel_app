using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DAL.models
{
    public class PersonaDAL
    {
        [Key]
        public int IdPersona { get; set; }
        public string TravelScore { get; set; } = JsonSerializer.Serialize(new List<int>() {0, 0, 0, 0, 0 });
    }
}