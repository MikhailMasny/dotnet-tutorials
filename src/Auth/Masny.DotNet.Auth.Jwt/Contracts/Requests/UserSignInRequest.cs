using System.ComponentModel.DataAnnotations;

namespace Masny.DotNet.Auth.Jwt.Contracts.Requests
{
    public class UserSignInRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
