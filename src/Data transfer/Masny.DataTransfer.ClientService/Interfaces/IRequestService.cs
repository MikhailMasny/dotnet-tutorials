using Masny.DataTransfer.ClientService.Contracts.Response;
using System;
using System.Threading.Tasks;

namespace Masny.DataTransfer.ClientService.Interfaces
{
    public interface IRequestService
    {
        Task<UserResponse> GetUserFromApiAsync();

        Task<TransferResponse> TransferDataAsync(int port, Guid id);
    }
}
