using Masny.Auth.Jwt.Contracts.Requests;
using Masny.Auth.Jwt.Models;
using System.Collections.Generic;

namespace Masny.Auth.Jwt.Interfaces
{
    public interface IUserService
    {
        AuthenticationResult Authenticate(UserSignInRequest model);

        AuthenticationResult Create(UserSignUpRequest model);

        IEnumerable<User> GetAll();

        User GetById(int id);
    }
}
