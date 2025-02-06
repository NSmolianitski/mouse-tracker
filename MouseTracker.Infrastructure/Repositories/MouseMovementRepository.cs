using MouseTracker.Application.Interfaces;
using MouseTracker.Domain;
using MouseTracker.Infrastructure.Persistence;

namespace MouseTracker.Infrastructure.Repositories;

public class MouseMovementRepository(AppDbContext context) : IMouseMovementRepository
{
    public async Task SaveMouseDataAsync(MouseMovementData mouseMovementData)
    {
        context.MouseMovements.Add(mouseMovementData);
        await context.SaveChangesAsync();
    }
}