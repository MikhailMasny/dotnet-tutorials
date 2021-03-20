using Masny.Auth.Jwt.Interfaces;
using Masny.Auth.Jwt.Models;
using System;
using System.Collections.Generic;

namespace Masny.Auth.Jwt.Managers
{
    public class UserStoreManager : IUserStoreManager
    {
        private List<User> _users = new List<User>
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

        public void Add(User user)
        {
            _users.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
    }
}
