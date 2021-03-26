using Masny.DotNet.DataTransfer.ClientService.Models;

namespace Masny.DotNet.DataTransfer.ClientService.Contracts.Response
{
    public class UserResponse
    {
        public bool IsSuccess { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}