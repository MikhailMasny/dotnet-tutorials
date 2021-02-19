using Masny.Auth.Web.Models;
using System.Collections.Generic;

namespace Masny.Auth.Web.Services
{
    public class FakeAccountService
    {
        public IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    Email = "mike@email.com",
                    Password = "qwe1!Q",
                    FullName = "Mike M.",
                    Role = "User",
                    Organization = "TMS"
                },
                new User
                {
                    Email = "nick@email.com",
                    Password = "qwe1!Q",
                    FullName = "Nick N.",
                    Role = "Admin",
                    Organization = "NotTMS"
                }
            };
        }
    }
}
