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
        public void UpdateScore(string UID, int change);
        public void SetTravelMode(int id, int travelMode);
        public UserDAL GetUserFromUID(int  idUID);
        public void CreateUser(string name, int idUID, int idGroup, char idPersona);
        public UserDTO GetUser(int id);
        public void AddFriend(int id, int friendIdUID);
        public List<UserDTO> GetFriendsLeaderboard(int id);
        public List<UserDTO> GetUniversityLeaderboard(int id);

        public List<UniversityDTO> GetUniversitiesLeaderboard();

    }
}
