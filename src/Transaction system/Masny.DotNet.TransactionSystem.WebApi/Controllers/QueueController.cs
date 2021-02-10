using Coravel.Queuing.Interfaces;
using Masny.DotNet.TransactionSystem.WebApi.Contexts;
using Masny.DotNet.TransactionSystem.WebApi.Contracts.Request;
using Masny.DotNet.TransactionSystem.WebApi.Enums;
using Masny.DotNet.TransactionSystem.WebApi.Jobs;
using Masny.DotNet.TransactionSystem.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Masny.DotNet.TransactionSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueue _queue;
        private readonly TransactionContext _transactionContext;

        public QueueController(
            IQueue queue,
            TransactionContext transactionContext)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
            _transactionContext = transactionContext;
        }

        [HttpGet("buy")]
        public async Task<IActionResult> BuyAsync([FromQuery] TransactionRequest transactionRequest)
        {
            var guid = Guid.NewGuid();
            var report = new Report
            {
                Guid = guid,
                Token = transactionRequest.Token,
                Value = transactionRequest.Value,
                Status = ReportStatusType.Processing,
            };

            await _transactionContext.Reports.AddAsync(report);
            await _transactionContext.SaveChangesAsync();
            _transactionContext.EnsureAutoHistory();

            _queue.QueueInvocableWithPayload<ProcessTransactionJob, Guid>(guid);

            return Ok(guid);
        }

        [HttpGet("status")]
        public async Task<IActionResult> StatusAsync([FromQuery] Guid guid)
        {
            var report =
                await _transactionContext.Reports
                    .AsNoTracking()
                    .SingleOrDefaultAsync(r => r.Guid == guid);

            if (report is null)
            {
                return NotFound("Report not found");
            }

            return Ok(new
            {
                status = report.Status.ToString(),
                description = report.Description ?? string.Empty,
            });
        }
    }
}