using Masny.DotNet.Auth.Jwt.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masny.DotNet.Auth.Jwt.Interfaces
{
    public interface IUserStoreManager
    {
        Task<IList<User>> GetAllAsync();

        Task AddAsync(User user);
    }
}
