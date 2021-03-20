using Masny.Auth.Jwt.Contracts.Requests;
using Masny.Auth.Jwt.Contracts.Responses;
using Masny.Auth.Jwt.Models;
using System.Collections.Generic;

namespace Masny.Auth.Jwt.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        IEnumerable<User> GetAll();

        User GetById(int id);
    }
}
