using Masny.DataTransfer.ClientService.Models;

namespace Masny.DataTransfer.ClientService.Contracts.Response
{
    public class UserResponse
    {
        public bool IsSuccess { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}