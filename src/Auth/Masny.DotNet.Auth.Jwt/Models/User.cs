using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Masny.DotNet.Auth.Jwt.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public IEnumerable<string> Roles { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
