using Masny.DotNet.DataTransfer.UserService.Contracts.Response;
using Masny.DotNet.DataTransfer.UserService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Masny.DotNet.DataTransfer.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IFakeUserService _fakeUserService;

        public UserController(IFakeUserService fakeUserService)
        {
            _fakeUserService = fakeUserService ?? throw new ArgumentNullException(nameof(fakeUserService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_fakeUserService.Get());
        }

        [HttpGet("random")]
        public IActionResult GetRandom()
        {
            var rnd = new Random();
            return Ok(new UserResponse
            {
                IsSuccess = true,
                User = _fakeUserService.Get().ToArray()[rnd.Next(0, 100)]
            });
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _fakeUserService.Get().SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                return NotFound(new UserResponse
                {
                    Description = "User not found"
                });
            }

            return Ok(new UserResponse
            {
                IsSuccess = true,
                User = user
            });
        }
    }
}