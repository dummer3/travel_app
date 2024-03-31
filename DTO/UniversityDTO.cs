namespace DTO
{
    public class UniversityDTO
    {
        public int idUniversity { get; set; }
        public string universityName { get; set; } = "University";
        public int averageScore { get; set; } = 0;

        public int numberOfPeople { get; set; } = 0;
        public string image { get; set; } = "/assets/";
    }
}