using Masny.Auth.Jwt.Contracts.Requests;
using Masny.Auth.Jwt.Helpers;
using Masny.Auth.Jwt.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Masny.Auth.Jwt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            return response is null 
                ? BadRequest(new { message = "Username or password is incorrect" }) 
                : Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
