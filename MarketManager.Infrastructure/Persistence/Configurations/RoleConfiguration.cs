using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketManager.Infrastructure.Persistence.Configurations;
public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(role => role.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(role => role.Permissions)
            .WithMany(permission => permission.Roles)
            .UsingEntity<Dictionary<string, object>>(
                "RolePermission",
                j => j.HasOne<Permission>().WithMany().HasForeignKey("PermissionId"),
                j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId")
            );

        builder.HasMany(role => role.Users)
            .WithMany(user => user.Roles)
            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                j => j.HasOne<User>().WithMany().HasForeignKey("UserId"),
                j => j.HasOne<Role>().WithMany().HasForeignKey("RoleId")
            );
    }
}
