using Masny.DotNet.Auth.Jwt.Models;
using System.Collections.Generic;

namespace Masny.DotNet.Auth.Jwt.Contracts.Responses
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Token { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Roles = user.Roles;
            Token = token;
        }
    }
}
