using System.ComponentModel.DataAnnotations;

namespace Masny.DotNet.Auth.Jwt.Contracts.Requests
{
    public class UserSignUpRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
