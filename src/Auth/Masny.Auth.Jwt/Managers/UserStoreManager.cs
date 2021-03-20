using Masny.Auth.Jwt.Interfaces;
using Masny.Auth.Jwt.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Masny.Auth.Jwt.Managers
{
    public class UserStoreManager : IUserStoreManager
    {
        private IList<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Test",
                LastName = "User",
                Username = Guid.NewGuid().ToString(),
                Password = "test"
            }
        };

        public Task AddAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        public Task<IList<User>> GetAllAsync()
        {
            return Task.FromResult(_users);
        }
    }
}
