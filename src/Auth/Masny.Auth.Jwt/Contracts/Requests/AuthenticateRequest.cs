using System.ComponentModel.DataAnnotations;

namespace Masny.Auth.Jwt.Contracts.Requests
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
