using MarketManager.Application.Common.Interfaces;
using MarketManager.Infrastructure.Persistence;
using MarketManager.Infrastructure.Persistence.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MarketManager.Infrastructure;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
        //{
        //    options.UseNpgsql(configuration.GetConnectionString("DbConnect"));
        //});

        //services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        return services;
    }
}
