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
        
        public void CompareTravelMethod(string UID,int travelMode) {
            try
            {
                _userRepo.UpdateScore(UID, travelMode);
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

        public UserDTO Login(int idUID, string name)
        {
            UserDAL user;
            try {user = _userRepo.GetUserFromUID(idUID);}
            catch {throw;};
            
            if (user.Name != name)
                throw new ArgumentException("error, the name is not correct");
            
            return user.ToDTO();
        }

        public void SignUp(string name, int idUID, int idGroup, char idPersona)
        {
            try
            {
                _userRepo.CreateUser(name,idUID, idGroup, idPersona);
            }
            catch { throw; }
        }

        public UserDTO GetUser(int id)
        {
            try { return _userRepo.GetUser(id); } catch { throw; }
        }

        public void AddFriend(int id,int friendIdUID)
        {
            try { _userRepo.AddFriend(id, friendIdUID); } catch { throw; }
        }

        public List<UserDTO> GetFriendsLeaderboard(int id)
        {
            try { return _userRepo.GetFriendsLeaderboard(id); }catch { throw; }
        }

        public List<UserDTO> GetUniversityLeaderboard(int id)
        {
            try { return _userRepo.GetUniversityLeaderboard(id); } catch { throw; }
        }

        public List<UniversityDTO> GetUniversitiesLeaderboard()
        {
            return _userRepo.GetUniversitiesLeaderboard();
        }
    }
}