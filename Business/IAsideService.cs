using DAL.models;
using DTO;

namespace Business
{
    public interface IAsideService
    {
        UniversityDAL CreateUniversity(string name);
        PersonaDAL CreatePersona(List<int> travelScore);
        UniversityDTO GetUniversity(int id);
        PersonaDTO GetPersona(char id); 
    }
}