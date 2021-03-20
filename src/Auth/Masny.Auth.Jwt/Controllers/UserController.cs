using Masny.Auth.Jwt.Contracts.Requests;
using Masny.Auth.Jwt.Helpers;
using Masny.Auth.Jwt.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Masny.Auth.Jwt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost("signup")]
        public IActionResult SignUp(UserSignUpRequest model)
        {
            var authenticationResult = _userService.Create(model);

            return !authenticationResult.Result
                ? BadRequest(new { message = authenticationResult.Message })
                : NoContent();
        }

        [HttpPost("signin")]
        public IActionResult SignIn(UserSignInRequest model)
        {
            var authenticationResult = _userService.Authenticate(model);

            return !authenticationResult.Result
                ? BadRequest(new { message = authenticationResult.Message })
                : Ok(authenticationResult.Data);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
