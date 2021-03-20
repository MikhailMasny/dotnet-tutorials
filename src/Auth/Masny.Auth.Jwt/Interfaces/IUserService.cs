using Masny.Auth.Jwt.Contracts.Requests;
using Masny.Auth.Jwt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masny.Auth.Jwt.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationResult> AuthenticateAsync(UserSignInRequest model);

        Task<AuthenticationResult> CreateAsync(UserSignUpRequest model);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);
    }
}
