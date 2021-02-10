using System;
using System.ComponentModel.DataAnnotations;

namespace Masny.DotNet.TransactionSystem.PaymentService.Models
{
    public class Transaction
    {
        [Key]
        public Guid Guid { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public decimal Value { get; set; }

        public decimal Procent { get; set; }
    }
}