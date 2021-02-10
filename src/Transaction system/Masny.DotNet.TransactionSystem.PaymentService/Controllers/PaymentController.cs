using Masny.DotNet.TransactionSystem.PaymentService.Contexts;
using Masny.DotNet.TransactionSystem.PaymentService.Contracts.Request;
using Masny.DotNet.TransactionSystem.PaymentService.Contracts.Response;
using Masny.DotNet.TransactionSystem.PaymentService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Masny.DotNet.TransactionSystem.PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentContext _paymentContext;
        private const decimal _systemProcent = 0.02M;

        public PaymentController(PaymentContext paymentContext)
        {
            _paymentContext = paymentContext ?? throw new ArgumentNullException(nameof(paymentContext));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] TransactionRequest transactionRequest)
        {
            var guid = Guid.NewGuid();
            var response = new TransactionResponse();
            using var contextTransaction = _paymentContext.Database.BeginTransaction();

            try
            {
                var user =
                _paymentContext.Users
                    .FirstOrDefault(user => user.Token == transactionRequest.Token);

                var procent = transactionRequest.Value * _systemProcent;
                var actualSum = procent + transactionRequest.Value;

                if (user.Amount < actualSum)
                {
                    return BadRequest(new TransactionResponse
                    {
                        Description = "Incorrect value",
                    });
                }

                user.Amount -= actualSum;

                var transaction = new Transaction
                {
                    Guid = Guid.NewGuid(),
                    UserId = user.Id,
                    Value = transactionRequest.Value,
                    Procent = procent
                };

                await _paymentContext.Transactions.AddAsync(transaction);
                await _paymentContext.SaveChangesAsync();

                var rnd = new Random();
                await Task.Delay(rnd.Next(10000, 20000));

                contextTransaction.Commit();
            }
            catch (Exception)
            {
                return BadRequest(new TransactionResponse
                {
                    Description = "Transaction error",
                });
            }

            return Ok(new TransactionResponse
            {
                Guid = guid.ToString(),
                IsSuccess = true,
            });
        }
    }
}