using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using Business;
using System.Globalization;
using System.Net;
using System;

namespace travel_app.Controllers
{

    [Route("User")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("compareMode")]
        public ActionResult CheckMode([FromForm] string UID, [FromForm] int tagMode)
        {
            Console.WriteLine("UID === " + UID);
            try { _userService.CompareTravelMethod(UID, tagMode); return Ok("compare done"); } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("signUp")]
        public ActionResult SignUp([FromForm] string userName, [FromForm] int IdUID, [FromForm] int IdUniversity, [FromForm] char IdPersona)
        {
            try { _userService.SignUp(userName,IdUID,IdUniversity, IdPersona); return Ok("sign up done"); }  catch (Exception ex) { return BadRequest(ex.Message); }; ;
        }

        [HttpPost("login")]
        public ActionResult Login([FromForm] int IdUID, [FromForm] string userName)
        {

            try { return Ok(_userService.Login(IdUID,userName)); } catch (Exception ex)
            { 
                return new ContentResult
                {
                    Content = ex.Message,
                    ContentType = "text/plain",
                    StatusCode = (int?)HttpStatusCode.BadRequest
                };
            }
        }

        [HttpPut("set/travelMode")]
        public ActionResult SetCheck([FromForm] int id, [FromForm] int travelMode )
        {
            try { _userService.SetTravelMode(id, travelMode); return Ok("travel mode change"); } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("get/user")]
        public ActionResult<UserDTO> GetUser(int id) {
            try { return _userService.GetUser(id); }
            catch (Exception ex)
            {
                {
                    return new ContentResult
                    {
                        Content = $"Error: {ex.Message}",
                        ContentType = "text/plain",
                        StatusCode = (int?)HttpStatusCode.BadRequest
                    };
                }
            }
        }

        [HttpGet("friendsLeaderboard")]
        public ActionResult<List<UserDTO>> GetFriendsLeaderboard(int id)
        {
            try { return _userService.GetFriendsLeaderboard(id); } catch (Exception ex) { return BadRequest(ex.Message);}
        }

        [HttpGet("yourUniversityLeaderboard")]
        public ActionResult<List<UserDTO>> GetUniversityLeaderboard(int id)
        {
            try { return _userService.GetUniversityLeaderboard(id); } catch (Exception ex) { return BadRequest(ex.Message); }
        }
         
        [HttpPost("set/friend")]
        public ActionResult AddFriends(int id,int friendIdUID)
        {
            try { _userService.AddFriend(id, friendIdUID); return Ok("friend add"); } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("universityLeaderboard")]
        public List<UniversityDTO> GetUniversitiesLeaderboard()
        {
            return _userService.GetUniversitiesLeaderboard();
        }
    }
}
