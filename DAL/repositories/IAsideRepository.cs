using DAL.models;
using DTO;

namespace DAL.repositories
{
    public interface IAsideRepository
    {
        UniversityDAL CreateGroup(string name);
        PersonaDAL CreatePersona(List<int> persona);
        UniversityDTO GetGroup(int id);
        PersonaDTO GetPersona(char id);

    }
}