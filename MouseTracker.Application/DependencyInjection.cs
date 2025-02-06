using Microsoft.Extensions.DependencyInjection;
using MouseTracker.Application.Interfaces;
using MouseTracker.Application.Services;

namespace MouseTracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<IMouseTrackingService, MouseTrackingService>();
        
        return services;
    }
}