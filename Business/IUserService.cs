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
        public void checkTravelMode(int ID, List<string> travelMode);
        public void SetTravelMode(int userId, int travelMode);
        public UserDTO Login(string  password, string name);
        public void SignUp(string name, string password, int idGroup, char idPersona);
        public UserDTO GetUser(int id);
        public void AddFriend(int id, string friendUsername);
        public List<UserDTO> GetFriendsLeaderboard(int id);

        public List<UserDTO>  GetUniversityLeaderboard(int id);

        public List<int> GetUniversityScore(int id);

        public List<UniversityDTO> GetUniversitiesLeaderboard();

        public void RemoveUsers();

        public List<UserDTO> GetUsers();

        public void RemoveUser(int id);

        public void RemovePoints(int id, int value);

        public string EndTrack(int ID, List<string> data);

        public void StartTrack(int ID);
    }
}
