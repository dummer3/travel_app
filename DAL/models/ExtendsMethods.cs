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
                UserName = user.UserName,
                IdUser = user.IdUser,
                PassWord = user.Password,
                TravelMode = user.TravelMode,

                IdUniversity = user.University != null ? user.University.IdUniversity:-1,
                IdPersona = (char)(user.Persona != null ? user.Persona.IdPersona + 'A' -1: '0'),
                Friends = user.Friends.ConvertAll<UserDTO>(friend => friend.ToDTO()),
            };
        }
    }
}
