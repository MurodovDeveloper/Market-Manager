using MarketManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManager.Infrastructure.Data.Configurations
{
    public class ExpiredProductConfiguration : IEntityTypeConfiguration<ExpiredProduct>
    {
        public void Configure(EntityTypeBuilder<ExpiredProduct> builder)
        {
            builder.Property(x=>x.PackageId).IsRequired();
            builder.Property(x=>x.Count).IsRequired();
        }
    }
}
