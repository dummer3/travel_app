using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DAL.models;
using DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace DAL.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        
        public UserRepository(Context context)
        {
            _context = context;
        }

        // Maybe not so useful, we can load all the user when he log, and keep all the data inside a useState
        public int GetTravelMode(int id)
        {
            return _context.Users.First(user => user.IdUser == id).TravelMode;
        }

        // Same
        public int GetScore(int id)
        {
            return _context.Users.First(user => user.IdUser == id).Score;
        }

        public void UpdateScore(string UID, int travelMode)
        {
            UserDAL? user = _context.Users.Include(user => user.Persona).FirstOrDefault(user => user.IdUID == _context.UIDs.First(uid => uid.UID == UID).IdUID);


            Console.WriteLine("UID " + UID + " travelMode " + travelMode + " previous " + user.TravelMode + "ID " + user.IdUser);
            Console.WriteLine(travelMode != user.TravelMode);

            if (user == null)
                throw new ArgumentException("Critical Error: user not recognized, please log again ");


            int scoretoAdd = travelMode != user.TravelMode ? 0 : JsonSerializer.Deserialize<List<int>>(user.Persona.TravelScore)[travelMode-1];

            Console.WriteLine(scoretoAdd);
            user.Score += scoretoAdd;
            user.Point += scoretoAdd;

            user.TravelMode = -travelMode;
            _context.SaveChanges();
        }

        public void SetTravelMode(int id, int travelMode)
        {
            UserDAL? user = _context.Users.FirstOrDefault(user => user.IdUser == id);
            
            if (user == null)
                throw new ArgumentException("Critical Error: user not recognized, please log again ");
           
            user.TravelMode = travelMode;
            _context.SaveChanges();
        }

        public UserDAL GetUserFromUID(int UID)
        {
            UserDAL? user = _context.Users.Include(user => user.University).Include(user => user.Persona).FirstOrDefault(user => user.IdUID == UID);
            Console.WriteLine(_context.UIDs.First(u => u.IdUID == UID).UID);
            if (user == null)
                throw new ArgumentException("Error: The UID you enter doesn't exist");
            
            return user;
        }

        public void CreateUser(string name,int idUID, int idGroup,char idPersona)
        {
            UniversityDAL? group = _context.Universities.FirstOrDefault(group => group.IdUniversity == idGroup);
            PersonaDAL? persona = _context.Personas.FirstOrDefault(persona => persona.IdPersona == idPersona + 1 - 'A');

            if (group == null)
                throw new ArgumentException("Error: the group does not exist");
            if (persona == null)
                throw new ArgumentException("Error: the persona does not exist");

            UserDAL newUser = new()
            {
                Name = name,
                IdUID = idUID,
                University = group,
                Persona = persona
            };

            try
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
            }
            catch(SqlAlreadyFilledException)
            {
                throw new ArgumentException("UID alrady taken");
            }
        }

        // Just for API test
        public UserDTO GetUser(int id)
        { 
            return _context.Users.Include(user => user.Persona).Include(user => user.University).Include(user => user.Friends).First(user => user.IdUser== id).ToDTO();
        }

        public void AddFriend(int id, int friendIdUID)
        {
            UserDAL friend = _context.Users.Include(user => user.Friends).First(user => user.IdUID == friendIdUID);
            UserDAL user = _context.Users.Include(user => user.Friends).First(user => user.IdUser == id);

            if(friend == null)
                throw new ArgumentException("Error: The UID you enter doesn't exist");
            if (user == null)
                throw new ArgumentException("Critical Error: user not recognized, please log again ");

            user.Friends.Add(friend);
            friend.Friends.Add(user);
            _context.SaveChanges();
        }

        public List<UserDTO> GetFriendsLeaderboard(int id)
        {
            UserDAL? user = _context.Users.Include(user => user.Friends).FirstOrDefault(user => user.IdUser == id);

            if (user == null)
                throw new ArgumentException("Error: user not recognized, please log again ");

            return user.Friends.Append(user).ToList().ConvertAll<UserDTO>(friend => friend.ToDTO()).OrderByDescending(item => item.Score).ToList();
        }

        public List<UserDTO> GetUniversityLeaderboard(int id)
        {
            if (_context.Universities.First((group) => group.IdUniversity == id) == null)
                throw new ArgumentException("Error: group not recognized, please log again ");

            return _context.Users
                .Include(user => user.University)
                .Where(user => user.University.IdUniversity==id)
                .ToList().ConvertAll(friend => friend.ToDTO())
                .OrderByDescending(item => item.Score)
                .ToList();
        }

        public List<UniversityDTO> GetUniversitiesLeaderboard()
        {

             List<UniversityDTO> list = _context.Users.Include(user => user.University).
                GroupBy(user => user.University)
                .Select(university => 
                new UniversityDTO { 
                    idUniversity = university.Key.IdUniversity,
                    universityName = university.Key.Name, 
                    numberOfPeople = university.Count(), 
                    averageScore = university.Sum(user => user.Score) / university.Count(),
                    image = university.Key.ImagePath
                })
                .OrderByDescending(univ => univ.averageScore).ToList();

            list.ForEach(univ => Console.WriteLine("name " + univ.universityName));

            if (list.Count < 5)
            {
                _context.Universities.ToList().ForEach(univ => Console.WriteLine("name " + univ.Name));

                List<UniversityDTO> addList = _context.Universities.ToList().ConvertAll(univ => univ.ToDTO())
                    .Where(univ => !list.Exists(u => u.idUniversity == univ.idUniversity)).ToList();

                list = list.Concat(addList.GetRange(0, 5 - list.Count)).ToList();
            }
            return list.GetRange(0,5);

        }

        public void RemovePoints(int idUser,int valueToRemove)
        {
            UserDAL? user = _context.Users.Include(user => user.Friends).FirstOrDefault(user => user.IdUser == idUser);

            if (user == null)
                throw new ArgumentException("Critical Error: user not recognized, please log again ");

            user.Point -= valueToRemove > user.Point ? user.Point : valueToRemove; 
            _context.SaveChanges();
        }
    }
}
