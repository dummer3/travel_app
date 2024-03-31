using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DAL.models;
using DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Globalization;

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

        public void UpdateScore(int ID, List<string> travelMode)
        {

            UserDAL? user = _context.Users.Include(user => user.Persona).FirstOrDefault(user => user.IdUser == ID);

            if (user == null)
                throw new ArgumentException("Critical Error: user not recognized, please log again ");

            int scoretoAdd = false ? 0 : JsonSerializer.Deserialize<List<int>>(user.Persona.TravelScore)[user.TravelMode];

            user.Score += scoretoAdd;
            user.Point += scoretoAdd;

            user.TravelMode = -user.TravelMode;
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

        public UserDAL GetUserFromUserName(string userName)
        {
            UserDAL? user = _context.Users.Include(user => user.University).Include(user => user.Persona).FirstOrDefault(user => user.UserName == userName);
            if (user == null)
                throw new ArgumentException("Error: The username you enter doesn't exist");

            return user;
        }

        public void CreateUser(string name, string password, int idGroup, char idPersona)
        {
            UniversityDAL? group = _context.Universities.FirstOrDefault(group => group.IdUniversity == idGroup);
            PersonaDAL? persona = _context.Personas.FirstOrDefault(persona => persona.IdPersona == (int) (idPersona - 'A') + 1);

            if (group == null)
                throw new ArgumentException("Error: the group does not exist");
            if (persona == null)
                throw new ArgumentException("Error: the persona does not exist");



            UserDAL newUser = new()
            {
                UserName = name,
                Password = password,
                University = group,
                Persona = persona,
                Score = JsonSerializer.Deserialize<List<int>>(persona.TravelScore)[0],
                Point = JsonSerializer.Deserialize<List<int>>(persona.TravelScore)[0]
            };
            try
            {
                _context.Users.Add(newUser);
                _context.SaveChanges();
            }
            catch (SqlAlreadyFilledException)
            {
                throw new ArgumentException("Username alrady taken");
            }
        }

        // Just for API test
        public UserDTO GetUser(int id)
        {
            return _context.Users.Include(user => user.Persona).Include(user => user.University).Include(user => user.Friends).First(user => user.IdUser == id).ToDTO();
        }

        public void AddFriend(int id, string friendUserName)
        {
            UserDAL friend = _context.Users.Include(user => user.Friends).First(user => user.UserName == friendUserName);
            UserDAL user = _context.Users.Include(user => user.Friends).First(user => user.IdUser == id);

            if (friend == null)
                throw new ArgumentException("Error: The UserName you enter doesn't exist");
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
                .Where(user => user.University.IdUniversity == id)
                .ToList().ConvertAll(friend => friend.ToDTO())
                .OrderByDescending(item => item.Score)
                .ToList();
        }

        public List<int> GetUniversityScore(int id)
        {
            if (_context.Universities.First((group) => group.IdUniversity == id) == null)
                throw new ArgumentException("Error: group not recognized, please log again ");

            List<UserDTO> l = GetUniversityLeaderboard(id);
            return new List<int> { l.Sum(user => user.Score), l.Sum(user => user.Score)/(int) MathF.Max(1,l.Count) };
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
            return list.GetRange(0, 5);

        }



        public List<UserDTO> GetUsers()
        {
            return _context.Users.Include(user => user.University)
                .Include(user => user.Persona).ToList().ConvertAll(user => user.ToDTO());
        }

        public void RemovePoints(int idUser, int valueToRemove)
        {
            UserDAL? user = _context.Users.Include(user => user.Friends).FirstOrDefault(user => user.IdUser == idUser);

            if (user == null)
                throw new ArgumentException("Critical Error: user not recognized, please log again ");

            user.Point -= valueToRemove > user.Point ? user.Point : valueToRemove;
            _context.SaveChanges();
        }

        public void RemoveUsers()
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM Users; DBCC CHECKIDENT ('Users', RESEED, 0)");
            _context.SaveChanges();
        }

        public void RemoveUser(int id)
        {
            _context.Database.ExecuteSqlRaw("DELETE FROM Users WHERE idUser=" + id + "; DBCC CHECKIDENT ('Users', RESEED, 0)");
            _context.SaveChanges();
        }


        public void StartTrack(int ID)
        {
            UserDAL user = _context.Users.First(user => user.IdUser == ID);
           
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo
            {
                //python interprater location
                FileName = @"C:\\Program Files (x86)\\Microsoft Visual Studio\\Shared\\Python39_64\\python.exe",
                //argument with file name and input parameters
                Arguments = string.Format("{0} {1}", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\app\APIrequest.py")),
                UseShellExecute = false,// Do not use OS shell
                CreateNoWindow = true, // We don't need new window
                RedirectStandardOutput = true,// Any output, generated by application will be redirected back
                RedirectStandardError = true, // Any error in standard output will be redirected back (for example exceptions)
                LoadUserProfile = true
            };
            using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    user.JsonContent = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                }
            }

            _context.SaveChanges();
        }

        public string EndTrack(int ID, List<string> data)
        {
            UserDAL user = _context.Users.First(user => user.IdUser == ID);
            string result = "";

            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo
            {
                //python interprater location
                FileName = @".../python.exe",
                //argument with file name and input parameters
                Arguments = string.Format("{0} {1} {2}", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pythonFile.py"), user.JsonContent, user.TravelMode),
                UseShellExecute = false,// Do not use OS shell
                CreateNoWindow = true, // We don't need new window
                RedirectStandardOutput = true,// Any output, generated by application will be redirected back
                RedirectStandardError = true, // Any error in standard output will be redirected back (for example exceptions)
                LoadUserProfile = true
            };
            using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                }
            }

            return result;
        }
    }
}
