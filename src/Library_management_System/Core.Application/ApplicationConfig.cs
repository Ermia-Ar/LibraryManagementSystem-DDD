using System.Reflection;
using Core.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Application;

public static class ApplicationConfig
{
    public static IServiceCollection AddApplicationConfig(this  IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddMediatR(x =>
        {
            x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            x.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });
        
        return services;
    }
}
