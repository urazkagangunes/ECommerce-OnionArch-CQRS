using ECommerce.Application.Services.Infrastructure;
using ECommerce.Infrastracture.CloudinaryServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastracture;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddIInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICloudinaryService, CloudinaryService>();
        services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));

        return services;
    }
}