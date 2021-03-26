using Flurl;
using Flurl.Http;
using Masny.DotNet.DataTransfer.ClientService.Contracts.Response;
using Masny.DotNet.DataTransfer.ClientService.Interfaces;
using System;
using System.Threading.Tasks;

namespace Masny.DotNet.DataTransfer.ClientService.Services
{
    public class RequestService : IRequestService
    {
        public async Task<UserResponse> GetUserFromApiAsync()
        {
            var response = new UserResponse();
            try
            {
                response = await "https://localhost:54576"
                    .AppendPathSegments("api", "user", "random")
                    .GetJsonAsync<UserResponse>();
            }
            catch (FlurlHttpException ex)
            {
                response.Description = ex.Message;
            }

            return response;
        }

        public async Task<TransferResponse> TransferDataAsync(int port, Guid id)
        {
            var response = new TransferResponse();
            try
            {
                response = await $"https://localhost:{port}"
                    .AppendPathSegments("api", "bank", "transfer", id)
                    .GetJsonAsync<TransferResponse>();
            }
            catch (FlurlHttpException ex)
            {
                response.Description = ex.Message;
            }

            return response;
        }
    }
}
