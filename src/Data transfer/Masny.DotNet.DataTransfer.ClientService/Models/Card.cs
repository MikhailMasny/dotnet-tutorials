using Masny.DotNet.DataTransfer.ClientService.Enums;
using System;

namespace Masny.DotNet.DataTransfer.ClientService.Models
{
    public class Card
    {
        public Guid Number { get; set; }

        public DateTime DateExpired { get; set; }

        public string OwnerName { get; set; }

        public CurrencyType Currency { get; set; }

        public decimal Amount { get; set; }
    }
}
