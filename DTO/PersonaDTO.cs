namespace DTO
{
    public class PersonaDTO
    {
        public char IdPersona { get; set; }
        public List<int> TravelScore { get; set; } = new List<int>(4);
    }
}