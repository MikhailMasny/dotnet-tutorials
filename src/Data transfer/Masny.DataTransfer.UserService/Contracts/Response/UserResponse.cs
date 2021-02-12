using Masny.DataTransfer.UserService.Models;

namespace Masny.DataTransfer.UserService.Contracts.Response
{
    public class UserResponse
    {
        public bool IsSuccess { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
    }
}