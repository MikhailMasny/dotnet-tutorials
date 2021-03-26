using Masny.DotNet.DataTransfer.UserService.Models;
using System.Collections.Generic;

namespace Masny.DotNet.DataTransfer.UserService.Interfaces
{
    public interface IFakeUserService
    {
        IEnumerable<User> Get();
    }
}