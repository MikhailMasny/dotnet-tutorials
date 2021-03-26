using Masny.DotNet.Crud.Configurations;
using Masny.DotNet.Crud.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Masny.DotNet.Crud.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //var options = optionsBuilder
            //        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DatabaseName;Trusted_Connection=True;")
            //        .Options;

            //Database.EnsureCreated();
        }

        public DbSet<ChildModel> ChildModels { get; set; }

        public DbSet<ParentModel> ParentModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ApplyConfiguration(new ChildModelConfiguration());
            builder.ApplyConfiguration(new ParentModelConfiguration());
        }
    }
}
