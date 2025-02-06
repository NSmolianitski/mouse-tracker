using Microsoft.EntityFrameworkCore;
using MouseTracker.Domain;

namespace MouseTracker.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<MouseMovementData> MouseMovements { get; set; } = null!;
}