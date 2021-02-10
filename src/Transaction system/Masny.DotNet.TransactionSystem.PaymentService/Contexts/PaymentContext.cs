using Masny.DotNet.TransactionSystem.PaymentService.Models;
using Microsoft.EntityFrameworkCore;

namespace Masny.DotNet.TransactionSystem.PaymentService.Contexts
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}