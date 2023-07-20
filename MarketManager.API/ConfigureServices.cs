using MarketManager.API.Common.Services;
using MarketManager.Application.Common.Interfaces;
using Serilog.Events;
using Serilog;
using TelegramSink;

namespace MarketManager.API;

public static class ConfigureServices
{
    public static IServiceCollection AddApi(this IServiceCollection services,IConfiguration configuration)
    {
        SerilogSettings(configuration);
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpContextAccessor();
        return services;
    }
    public static void SerilogSettings(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(configuration)
           .MinimumLevel.Information()
           .WriteTo.Console()
           .Enrich.FromLogContext()
           .Enrich.WithEnvironmentUserName()
           .Enrich.WithMachineName()
           .Enrich.WithClientIp()
           .WriteTo.TeleSink(
            telegramApiKey: configuration.GetConnectionString("TelegramToken"),
            telegramChatId: "1856623462",
            minimumLevel: LogEventLevel.Error)
           .CreateLogger();
    }
}
