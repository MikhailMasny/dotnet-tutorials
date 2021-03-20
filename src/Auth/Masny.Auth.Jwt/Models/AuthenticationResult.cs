using Masny.Auth.Jwt.Contracts.Responses;

namespace Masny.Auth.Jwt.Models
{
    public class AuthenticationResult
    {
        public bool Result { get; set; }

        public string Message { get; set; }

        public AuthenticateResponse Data { get; set; }
    }
}
