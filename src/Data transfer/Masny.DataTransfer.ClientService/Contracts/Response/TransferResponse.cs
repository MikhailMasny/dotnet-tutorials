using Masny.DataTransfer.ClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Masny.DataTransfer.ClientService.Contracts.Response
{
    public class TransferResponse
    {
        public bool IsSuccess { get; set; }
        public string Description { get; set; }
        public Account Account { get; set; }
    }
}
