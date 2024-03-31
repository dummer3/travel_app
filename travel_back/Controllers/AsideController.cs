using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using DAL.models;

namespace travel_app.Controllers
{
    [Route("Aside")]
    [ApiController]
    public class AsideController : Controller
    {

        private readonly IAsideService _asideService;

        public AsideController(IAsideService asideService)
        {
            _asideService = asideService;
        }

        [HttpPost("create/group")]
        public UniversityDAL CreateUniversity([FromForm] string name)
        {
            return _asideService.CreateUniversity(name);
        }

        [HttpPost("create/persona")]
        public PersonaDAL CreatePersona([FromForm] List<int> travelScore)
        {
           return _asideService.CreatePersona(travelScore);
        }

        [HttpGet("get/group")]
        public UniversityDTO GetUniversity(int id)
        {
            return _asideService.GetUniversity(id);
        }
        [HttpGet("get/persona")]
        public PersonaDTO GetPersona(char id)
        {
        return _asideService.GetPersona(id);
        }
    }
}
