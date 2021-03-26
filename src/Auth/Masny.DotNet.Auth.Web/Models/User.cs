namespace Masny.DotNet.Auth.Web.Models
{
    public class User
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Role { get; set; }

        public string Organization { get; set; }
    }
}
