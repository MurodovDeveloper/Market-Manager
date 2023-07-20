using MarketManager.API.Common.Services;
using MarketManager.Application.Common.Interfaces;

namespace MarketManager.API;

public static class ConfigureServices
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();
        return services;
    }
}
