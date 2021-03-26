using Masny.DotNet.Crud.Constants;
using Masny.DotNet.Crud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Masny.DotNet.Crud.Configurations
{
    public class ParentModelConfiguration : IEntityTypeConfiguration<ParentModel>
    {
        public void Configure(EntityTypeBuilder<ParentModel> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.ParentModels, Schema.Simple)
                .HasKey(parentModel => parentModel.Id);

            builder.Property(parentModel => parentModel.StringVar)
                .IsRequired()
                .HasMaxLength(SqlConfiguration.MaxLengthLong);
        }
    }
}
