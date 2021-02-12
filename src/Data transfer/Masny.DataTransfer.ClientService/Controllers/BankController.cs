using Masny.DataTransfer.ClientService.Contracts.Request;
using Masny.DataTransfer.ClientService.Contracts.Response;
using Masny.DataTransfer.ClientService.Helpers;
using Masny.DataTransfer.ClientService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Masny.DataTransfer.ClientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IFakeBankService _fakeBankService;
        private readonly IRequestService _requestService;
        private readonly Ports _ports;

        public BankController(
            IFakeBankService fakeBankService,
            IRequestService requestService,
            IOptions<Ports> portsOptions)
        {
            _fakeBankService = fakeBankService ?? throw new ArgumentNullException(nameof(fakeBankService));
            _requestService = requestService ?? throw new ArgumentNullException(nameof(requestService));
            _ports = portsOptions.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_fakeBankService.Get());
        }

        [HttpGet("replace")]
        public async Task<IActionResult> GetAsync([FromQuery] TransferRequest transferRequest)
        {
            var port = transferRequest.Server.ConvertPort(_ports);
            var transferResponse = await _requestService.TransferDataAsync(port, transferRequest.Id);
            if (!transferResponse.IsSuccess)
            {
                return BadRequest("Error");
            }

            _fakeBankService.Save(transferResponse.Account);
            return Ok("Good");
        }

        [HttpGet("transfer/{id}")]
        public IActionResult Transfer(Guid id)
        {
            var (operationResult, account) = _fakeBankService.Transfer(id);
            if (!operationResult)
            {
                return NotFound(new TransferResponse
                {
                    Description = "Account not found"
                });
            }

            return Ok(new TransferResponse
            {
                IsSuccess = true,
                Account = account
            });
        }

        // POST api/<BankController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BankController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BankController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
