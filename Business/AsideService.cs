using DAL.models;
using DAL.repositories;
using DTO;

namespace Business
{
    public class AsideService : IAsideService
    {
        private readonly IAsideRepository _repo;
        public AsideService(IAsideRepository repo)
        {
            _repo = repo;
        }

        public PersonaDAL CreatePersona(List<int> travelScore)
        {
            return _repo.CreatePersona(travelScore);
        }

        public UniversityDAL CreateUniversity(string name)
        {
            return _repo.CreateGroup(name);
        }

       public UniversityDTO GetUniversity(int id)
        {
            return _repo.GetGroup(id);
        }

        public PersonaDTO GetPersona(char id)
        {
            return _repo.GetPersona(id);
        }

    }
}
