using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DAL.repositories;
using DTO;

namespace DAL.models
{
    public static class ExtendsMethods
    {
        public static UniversityDTO ToDTO(this UniversityDAL group)
        {
            return new UniversityDTO
            {
                universityName = group.Name,
                idUniversity = group.IdUniversity,
                image = group.ImagePath
            };
        }
        public static PersonaDTO ToDTO(this PersonaDAL persona)
        {
            return new PersonaDTO
            {
                IdPersona = (char)(persona.IdPersona - 1 + 'A'),
                TravelScore = JsonSerializer.Deserialize<List<int>>(persona.TravelScore, (JsonSerializerOptions)null)
            };
        }

        public static UserDTO ToDTO(this UserDAL user)
        {
            Console.WriteLine(user.Score);
            return new UserDTO
            {
                Score = user.Score,
                Points = user.Point,
                Name = user.Name,
                IdUser = user.IdUser,
                IdUID = user.IdUID,
                TravelMode = user.TravelMode,

                IdUniversity = user.University != null ? user.University.IdUniversity:-1,
                IdPersona = user.Persona != null ? user.Persona.IdPersona: -1,
                Friends = user.Friends.ConvertAll<UserDTO>(friend => friend.ToDTO()),
            };
        }
    }
}
