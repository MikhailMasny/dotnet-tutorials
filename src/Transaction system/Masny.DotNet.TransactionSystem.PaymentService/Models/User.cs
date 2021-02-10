using System.Collections.Generic;

namespace Masny.DotNet.TransactionSystem.PaymentService.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public decimal Amount { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}