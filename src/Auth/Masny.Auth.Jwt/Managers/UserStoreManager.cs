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
                FirstName = "Admin",
                LastName = "Test",
                Email = "admin@admin.admin",
                Username = Guid.NewGuid().ToString(),
                Password = "admin123",
                Roles = new List<string>
                {
                    "ROLE_ADMIN",
                },
            },
            new User
            {
                Id = 2,
                FirstName = "Moderator",
                LastName = "Test",
                Email = "moderator@moderator.moderator",
                Username = Guid.NewGuid().ToString(),
                Password = "moderator123",
                Roles = new List<string>
                {
                    "ROLE_MODERATOR",
                },
            },
            new User
            {
                Id = 3,
                FirstName = "User",
                LastName = "Test",
                Email = "user@user.user",
                Username = Guid.NewGuid().ToString(),
                Password = "user123",
                Roles = new List<string>
                {
                    "ROLE_USER",
                },
            },
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
