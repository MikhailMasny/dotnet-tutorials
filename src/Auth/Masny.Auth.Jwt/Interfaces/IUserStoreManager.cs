using Masny.Auth.Jwt.Models;
using System.Collections.Generic;

namespace Masny.Auth.Jwt.Interfaces
{
    public interface IUserStoreManager
    {
        IEnumerable<User> GetAll();

        void Add(User user);
    }
}
