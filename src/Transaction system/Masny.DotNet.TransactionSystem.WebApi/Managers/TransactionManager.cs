using Flurl;
using Flurl.Http;
using Masny.DotNet.TransactionSystem.WebApi.Contexts;
using Masny.DotNet.TransactionSystem.WebApi.Contracts.Response;
using Masny.DotNet.TransactionSystem.WebApi.Enums;
using Masny.DotNet.TransactionSystem.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Masny.DotNet.TransactionSystem.WebApi.Managers
{
    public class TransactionManager : ITransactionManager
    {
        private readonly TransactionContext _transactionContext;

        public TransactionManager(TransactionContext transactionContext)
        {
            _transactionContext = transactionContext;
        }

        public async Task RunAsync(Guid payload)
        {
            var report = await _transactionContext.Reports.SingleOrDefaultAsync(r => r.Guid == payload);
            var response = new TransactionResponse();

            try
            {
                response = await "https://localhost:58526"
                    .AppendPathSegments("api", "payment")
                    .SetQueryParams(new { token = report.Token, value = report.Value })
                    //.AllowHttpStatus("400-404,5xx")
                    .GetJsonAsync<TransactionResponse>();
            }
            catch (FlurlHttpException ex)
            {
                response.Description = ex.Message;
            }
            finally
            {
                if (response.IsSuccess)
                {
                    report.Status = ReportStatusType.Success;
                    report.TransactionIdentifier = response.Guid;
                }
                else
                {
                    report.Status = ReportStatusType.Error;
                    report.Description = response.Description;
                }

                await _transactionContext.SaveChangesAsync();
                _transactionContext.EnsureAutoHistory();
            }
        }
    }
}