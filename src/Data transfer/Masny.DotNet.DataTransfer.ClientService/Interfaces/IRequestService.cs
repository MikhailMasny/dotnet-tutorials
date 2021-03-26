using Masny.DotNet.DataTransfer.ClientService.Contracts.Response;
using System;
using System.Threading.Tasks;

namespace Masny.DotNet.DataTransfer.ClientService.Interfaces
{
    public interface IRequestService
    {
        Task<UserResponse> GetUserFromApiAsync();

        Task<TransferResponse> TransferDataAsync(int port, Guid id);
    }
}
