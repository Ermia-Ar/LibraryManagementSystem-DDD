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