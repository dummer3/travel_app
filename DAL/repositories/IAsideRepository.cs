using DAL.models;
using DTO;

namespace DAL.repositories
{
    public interface IAsideRepository
    {
        UniversityDAL CreateGroup(string name);
        PersonaDAL CreatePersona(List<int> persona);
        UIDDAL CreateUID(string UID);

        UniversityDTO GetGroup(int id);
        PersonaDTO GetPersona(char id);

        UIDDAL GetUID(int id);
    }
}