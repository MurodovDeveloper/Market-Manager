using MarketManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace MarketManager.Infrastructure.Data.Configurations;
public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Property(client => client.TotalPrice).IsRequired();
        builder.Property(client => client.Discount).IsRequired();
    }
}
