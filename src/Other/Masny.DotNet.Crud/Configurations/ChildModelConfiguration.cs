using Masny.DotNet.Crud.Constants;
using Masny.DotNet.Crud.Enums;
using Masny.DotNet.Crud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Masny.DotNet.Crud.Configurations
{
    public class ChildModelConfiguration : IEntityTypeConfiguration<ChildModel>
    {
        public void Configure(EntityTypeBuilder<ChildModel> builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));

            builder.ToTable(Table.ChildModels, Schema.Dbo)
                .HasKey(childModel => childModel.Id);

            builder.Property(childModel => childModel.StringVar)
                .IsRequired()
                .HasMaxLength(SqlConfiguration.MaxLengthShort);

            builder.Property(childModel => childModel.StringNullVar)
                .HasMaxLength(SqlConfiguration.MaxLengthMedium);

            builder.Property(childModel => childModel.DecimalVar)
                .HasColumnType(SqlConfiguration.DecimalFormat);

            builder.Property(childModel => childModel.EnumType)
                .HasConversion(new EnumToNumberConverter<EnumType, int>());

            builder.Property(childModel => childModel.DateVar)
                .HasColumnType(SqlConfiguration.DateFormat);

            builder.HasOne(childModel => childModel.ParentModel)
                .WithMany(parentModel => parentModel.ChildModels)
                .HasForeignKey(childModel => childModel.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
