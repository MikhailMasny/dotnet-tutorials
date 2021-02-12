using Flurl;
using Flurl.Http;
using Masny.DataTransfer.ClientService.Contracts.Response;
using Masny.DataTransfer.ClientService.Interfaces;
using System;
using System.Threading.Tasks;

namespace Masny.DataTransfer.ClientService.Services
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
