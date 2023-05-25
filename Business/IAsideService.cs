using DAL.models;
using DTO;

namespace Business
{
    public interface IAsideService
    {
        UniversityDAL CreateUniversity(string name);
        PersonaDAL CreatePersona(List<int> travelScore);
        UIDDAL CreateUID(string UID);

        UniversityDTO GetUniversity(int id);
        PersonaDTO GetPersona(char id);

        UIDDAL GetUID(int id);
    }
}