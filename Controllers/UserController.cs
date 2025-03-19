using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend_Mobile.Entities;
using Backend_Mobile.Services.UserService;

namespace Backend_Mobile.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[Action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> createUser(UserEntity user)
        {
            try
            {
                var result = await _userService.createUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> login([FromBody] LoginDataModel request)
        {
            var token = await _userService.AuthenticateUser(request.Email, request.Password);
            if (token == null)
            {
                return Unauthorized("Invalid email or password.");
            }
            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> GetUserProfile([FromBody] string email)
        {

            var userProfile = await _userService.GetUserProfile(email);
            if (userProfile == null)
            {
                return NotFound("User not found.");
            }
            return Ok(userProfile);
        }
    }
}