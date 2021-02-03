using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// TODO: 
// random get result (true / false)
// random time

namespace Masny.DotNet.TransactionSystem.PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            await Task.Delay(5000);
            return Ok(Guid.NewGuid());
        }
    }
}
