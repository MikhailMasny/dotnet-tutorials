using Masny.DotNet.TransactionSystem.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Masny.DotNet.TransactionSystem.WebApi.Contexts
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options)
        {
        }

        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // enable auto history functionality.
            modelBuilder.EnableAutoHistory(2048);
        }
    }
}