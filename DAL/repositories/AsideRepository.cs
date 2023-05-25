using DAL.models;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL.repositories
{

    public class AsideRepository : IAsideRepository 
    {
        private readonly Context _context;

        public AsideRepository(Context context)
        {
            _context = context;
        }

        public PersonaDAL CreatePersona(List<int> travelScore)
        {
            PersonaDAL newPersona = new()
            {
                TravelScore= JsonSerializer.Serialize(travelScore),
            };

            _context.Personas.Add(newPersona);
            _context.SaveChanges();

            return _context.Personas.First(persona => persona.TravelScore == JsonSerializer.Serialize(travelScore,(JsonSerializerOptions)null));
        }

        public UIDDAL CreateUID(string UID)
        {
            UIDDAL newUID= new()
            {
                UID = UID
            };

            _context.UIDs.Add(newUID);
            _context.SaveChanges();

            return _context.UIDs.First(uid => uid.UID == UID);
        }

        public UniversityDAL CreateGroup(string name)
        {
            UniversityDAL newGroup = new()
            {
                Name = name,
            };

            _context.Universities.Add(newGroup);
            _context.SaveChanges();

            return _context.Universities.First(uni => uni.Name == name);
        }

        public UniversityDTO GetGroup(int id)
        {
            return _context.Universities.First(group => group.IdUniversity == id).ToDTO();
        }

        public PersonaDTO GetPersona(char id)
        {
            return _context.Personas.First(persona => persona.IdPersona == (int)(id - 'A' + 1)).ToDTO();
        }

        public UIDDAL GetUID(int id)
        {
            return _context.UIDs.First(persona => persona.IdUID == id);
        }
    }


}
