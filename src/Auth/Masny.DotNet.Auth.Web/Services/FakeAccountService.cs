using Masny.DotNet.Auth.Web.Models;
using System.Collections.Generic;

namespace Masny.DotNet.Auth.Web.Services
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
