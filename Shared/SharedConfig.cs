using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Middleware;

namespace Shared;

public static class SharedConfig
{
    public static IServiceCollection AddSharedConfig(this IServiceCollection services)
    {
        services.AddScoped<ErrorHandlerMiddleware>();
        return services;
    }

    public static IApplicationBuilder UserShared(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
        return app;
    }
}