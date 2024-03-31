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

        [HttpPost("checkMode")]
        public ActionResult CheckMode([FromForm] int ID, [FromForm] List<string> tagMode)
        {
            Console.WriteLine("UID === " + ID);
            try { _userService.checkTravelMode(ID, tagMode); return Ok("compare done"); } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("signUp")]
        public ActionResult SignUp([FromForm] string userName, [FromForm] string password, [FromForm] int IdUniversity, [FromForm] char IdPersona)
        {
            try { _userService.SignUp(userName, password, IdUniversity, IdPersona); return Ok("sign up done"); } catch (Exception ex) { return BadRequest(ex.Message); }; ;
        }

        [HttpPost("login")]
        public ActionResult Login([FromForm] string password, [FromForm] string userName)
        {

            try { return Ok(_userService.Login(password, userName)); } catch (Exception ex)
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
        public ActionResult SetCheck([FromForm] int id, [FromForm] int travelMode)
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
            try { return _userService.GetFriendsLeaderboard(id); } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("yourUniversityScore")]
        public ActionResult<List<int>> GetUniversityScore(int id)
        {
            try { return _userService.GetUniversityScore(id); } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("yourUniversityLeaderboard")]
        public ActionResult<List<UserDTO>> GetUniversityLeaderboard(int id)
        {
            try { return _userService.GetUniversityLeaderboard(id); } catch (Exception ex) { return BadRequest(ex.Message); }
        }
         
        [HttpPost("set/friend")]
        public ActionResult AddFriends([FromForm] int id, [FromForm] string friendUserName)
        {
            try { _userService.AddFriend(id, friendUserName); return Ok("friend add"); } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("universityLeaderboard")]
        public List<UniversityDTO> GetUniversitiesLeaderboard()
        {
            return _userService.GetUniversitiesLeaderboard();
        }

        [HttpGet("get/users")]
        public List<UserDTO> GetUsers()
        {
            return _userService.GetUsers();
        }


        [HttpDelete("removeUsers")]
        public void RemoveUsers()
        {
            _userService.RemoveUsers();
        }

        [HttpDelete("removeUser")]
        public void RemoveUser([FromForm] int id)
        {
            _userService.RemoveUser(id);
        }


        [HttpPut("set/points")]
        public ActionResult RemovePoints([FromForm] int id, [FromForm] int value)
        {
            try { _userService.RemovePoints(id,value); return Ok("Points Remove"); } catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("startTrack")]
        public ActionResult StartTrack([FromForm] int id)
        {
            _userService.StartTrack(id);
            return Ok("API CALL");
        }
        [HttpPost("endTrack")]
        public ActionResult EndTrack([FromForm] int id, [FromForm] List<string> data)
        {
            return Ok(_userService.EndTrack(id,data));
        }

    }
}
