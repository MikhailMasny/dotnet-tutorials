using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masny.DotNet.DataTransfer.ClientService.Contracts.Request
{
    public class TransferRequest
    {
        public string Server { get; set; }

        public Guid Id { get; set; }
    }
}
