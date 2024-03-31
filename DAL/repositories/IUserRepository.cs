using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Globalization;

namespace DAL.repositories
{
    public interface IUserRepository
    {
        public int GetTravelMode(int id);
        public int GetScore(int id);
        public void UpdateScore(int ID, List<string> data);
        public void SetTravelMode(int id, int travelMode);
        public UserDAL GetUserFromUserName(string username);
        public void CreateUser(string name, string password, int idGroup, char idPersona);
        public UserDTO GetUser(int id);
        public void AddFriend(int id, string friendUserName);
        public List<UserDTO> GetFriendsLeaderboard(int id);
        public List<UserDTO> GetUniversityLeaderboard(int id);
        public List<int> GetUniversityScore(int id);

        public List<UserDTO> GetUsers();
        public List<UniversityDTO> GetUniversitiesLeaderboard();

        public void RemoveUsers();

        public void RemoveUser(int id);

        public void RemovePoints(int id, int value);

        public void StartTrack(int ID);

        public string EndTrack(int ID, List<string> data);

    }
}
