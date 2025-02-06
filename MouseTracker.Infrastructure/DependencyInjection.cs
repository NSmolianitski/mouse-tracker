using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MouseTracker.Application.Interfaces;
using MouseTracker.Infrastructure.Persistence;
using MouseTracker.Infrastructure.Repositories;

namespace MouseTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
        
        services.AddScoped<IMouseMovementRepository, MouseMovementRepository>();

        return services;
    }
}