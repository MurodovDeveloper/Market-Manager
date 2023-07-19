﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MarketManager.Domain.Entities;

namespace MarketManager.Infrastructure.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(supplier => supplier.Name)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(supplier => supplier.Phone)
            .HasMaxLength(20)
            .IsRequired();
        }
    }
}
