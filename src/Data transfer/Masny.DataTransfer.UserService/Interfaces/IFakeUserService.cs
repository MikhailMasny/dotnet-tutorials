using Masny.DataTransfer.UserService.Models;
using System.Collections.Generic;

namespace Masny.DataTransfer.UserService.Interfaces
{
    public interface IFakeUserService
    {
        IEnumerable<User> Get();
    }
}