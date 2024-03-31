using Azure;
using DAL.models;
using DAL.repositories;
using DTO;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Reflection.Metadata;

namespace Business
{

    public class UserService : IUserService
    {
        private IUserRepository _userRepo;
        
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        // Optional
        public int GetScore(int userId)
        {
            return _userRepo.GetScore(userId);
        }
        
        public void checkTravelMode(int ID,List<string> data) {
            try
            {
                _userRepo.UpdateScore(ID, data);
            }
            catch { throw; };
        }

        public void SetTravelMode(int userId,int travelMode)
        {
            try
            {
                _userRepo.SetTravelMode(userId, travelMode);
            } 
            catch { throw; }
        }

        public UserDTO Login(string password, string userName)
        {
            UserDAL user;
            try {user = _userRepo.GetUserFromUserName(userName);}
            catch {throw;};
            
            if (user.Password != password)
                throw new ArgumentException("error, the name is not correct");
            
            return user.ToDTO();
        }

        public void SignUp(string name, string password, int idGroup, char idPersona)
        {
            try
            {
                _userRepo.CreateUser(name,password, idGroup, idPersona);
            }
            catch { throw; }
        }

        public UserDTO GetUser(int id)
        {
            try { return _userRepo.GetUser(id); } catch { throw; }
        }

        public void AddFriend(int id,string friendUserName)
        {
            try { _userRepo.AddFriend(id, friendUserName); } catch { throw; }
        }

        public List<UserDTO> GetFriendsLeaderboard(int id)
        {
            try { return _userRepo.GetFriendsLeaderboard(id); }catch { throw; }
        }

        public List<UserDTO> GetUniversityLeaderboard(int id)
        {
            try { return _userRepo.GetUniversityLeaderboard(id); } catch { throw; }
        }
        public List<int> GetUniversityScore(int id)
        {
            try { return _userRepo.GetUniversityScore(id); } catch { throw; }
        }

        public List<UserDTO> GetUsers()
        {
            return _userRepo.GetUsers();
        }

        public List<UniversityDTO> GetUniversitiesLeaderboard()
        {
            return _userRepo.GetUniversitiesLeaderboard();
        }

        public void RemoveUsers()
        {
            _userRepo.RemoveUsers();
        }


        public void RemoveUser(int id)
        {
            _userRepo.RemoveUser(id);
        }

        public void RemovePoints(int id, int value)
        {
            _userRepo.RemovePoints(id, value);
        }

        public string EndTrack(int ID, List<string> data)
        {
            return _userRepo.EndTrack(ID, data);
        }

        public void StartTrack(int ID)
        {
            _userRepo.StartTrack(ID);
        }
    }
}