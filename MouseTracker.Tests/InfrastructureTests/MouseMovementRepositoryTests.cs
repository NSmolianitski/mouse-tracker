using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MouseTracker.Application.DTOs;
using MouseTracker.Domain;
using MouseTracker.Infrastructure.Persistence;
using MouseTracker.Infrastructure.Repositories;

namespace MouseTracker.Tests.InfrastructureTests;

public sealed class MouseMovementRepositoryTests : IDisposable
{
    private readonly AppDbContext _context;

    public MouseMovementRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
    }

    [Fact]
    public async Task SaveMouseDataAsync_ShouldSaveMouseData()
    {
        // Arrange
        var repository = new MouseMovementRepository(_context);
        var currentTime = DateTime.Now.Ticks;
        var movementData = new List<MovementData>
        {
            new MovementData(100, 150, currentTime),
            new MovementData(200, 250, currentTime + 1000),
        };
        var serializedData = new MouseMovementData
        {
            MovementData = JsonSerializer.Serialize(movementData)
        };
            
        // Act
        await repository.SaveMouseDataAsync(serializedData);

        // Assert
        var savedData = await _context.MouseMovements.ToListAsync();
        Assert.Single(savedData);
        Assert.Equal(serializedData.MovementData, savedData[0].MovementData);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}