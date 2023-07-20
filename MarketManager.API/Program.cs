
using MarketManager.API.Middlewares;
using MarketManager.Application;
using MarketManager.Infrastructure;
using Serilog;

namespace MarketManager.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddApi(builder.Configuration);
        builder.Host.UseSerilog();
        var app = builder.Build();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            
        }
        app.UseDirectoryBrowser("/pages");
        app.UseFileServer();
        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseGlobalExceptionMiddleware();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}