using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IUserService
    {
        public int GetScore(int userId);
        public void CompareTravelMethod(string UID, int travelMode);
        public void SetTravelMode(int userId, int travelMode);
        public UserDTO Login(int  idUID, string name);
        public void SignUp(string name, int idUID, int idGroup, char idPersona);
        public UserDTO GetUser(int id);
        public void AddFriend(int id, int friendIdUID);
        public List<UserDTO> GetFriendsLeaderboard(int id);

        public List<UserDTO> GetUniversityLeaderboard(int id);

        public List<UniversityDTO> GetUniversitiesLeaderboard();
    }
}
