[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Bootstrapper")]

namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure;

using Api.Controllers;
using Api.Cors;
using Api.Errors.Middleware;
using Api.Swagger;
using Api.WebSockets;
using BackgroundProcessing;
using Configuration;
using EventBus;
using FeatureFlags;
using HealthChecks;
using Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Observability;
using Persistance;

internal static class SharedInfrastructureModule
{
    internal static void AddSharedInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        services.AddInternalControllers();
        services.AddHttpClient();
        services.AddSwaggerModule();
        services.AddMvcCore();
        services.AddCors();
        services.AddBackgroundProcessing(configuration);
        services.AddSharedHealthChecks();
        services.AddObservability();
        services.AddConfiguration();
        services.AddLogging();
        services.AddFeatureFlags();
    }

    internal static void UseSharedInfrastructure(this IApplicationBuilder app)
    {
        var configuration = app.ApplicationServices.GetRequiredService<IConfiguration>();
        app.UseCors(configuration);
        app.UseWebSockets(configuration);
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSwaggerModule();
        app.UseExceptionHandling();
        app.UseLogging();
        app.UseBackgroundProcessing();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapSharedHealthChecks();
        });
        app.UseSharedPersistance();
        app.UseSharedHealthChecks();
    }

    internal static IHostBuilder UseSharedInfrastructure(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseEvents();

        return hostBuilder;
    }
}
