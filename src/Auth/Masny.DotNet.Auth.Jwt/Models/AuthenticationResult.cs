using Masny.DotNet.Auth.Jwt.Contracts.Responses;

namespace Masny.DotNet.Auth.Jwt.Models
{
    public class AuthenticationResult
    {
        public bool Result { get; set; }

        public string Message { get; set; }

        public AuthenticateResponse Data { get; set; }
    }
}
