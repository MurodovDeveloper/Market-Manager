﻿using MarketManager.Domain.Entities;
using MarketManager.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace MarketManager.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Supplier> Suppliers { get; }
    DbSet<User> Users { get; }
    DbSet<Client> Clients { get; }
    DbSet<Product> Products { get; }
    DbSet<ExpiredProduct> ExpiredProducts { get; }
    DbSet<Role> Roles { get; }
    DbSet<Permission> Permissions { get; }
    DbSet<Package> Packages { get; }
    DbSet<ProductType> ProductTypes { get; }
    DbSet<Order> Orders { get; }
    DbSet<Item> Items { get; }
    DbSet<UserRefreshToken> RefreshTokens { get; }
    DbSet<PaymentType> PaymentTypes { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
