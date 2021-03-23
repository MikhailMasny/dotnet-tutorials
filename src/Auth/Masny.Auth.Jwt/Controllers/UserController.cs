using Masny.Auth.Jwt.Contracts.Requests;
using Masny.Auth.Jwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> SignUpAsync(UserSignUpRequest model)
        {
            var authenticationResult = await _userService.CreateAsync(model);

            return !authenticationResult.Result
                ? BadRequest(new { message = authenticationResult.Message })
                : NoContent();
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync(UserSignInRequest model)
        {
            var authenticationResult = await _userService.AuthenticateAsync(model);

            return !authenticationResult.Result
                ? BadRequest(new { message = authenticationResult.Message })
                : Ok(authenticationResult.Data);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        //[Authorize(Roles = "ROLE_ADMIN")]
        [HttpGet("admin")]
        public IActionResult Admin()
        {
            return Content("Secret message!");
        }
    }
}
