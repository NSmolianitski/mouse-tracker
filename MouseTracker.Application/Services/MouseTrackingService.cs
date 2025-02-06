using System.Text.Json;
using MouseTracker.Application.DTOs;
using MouseTracker.Application.Interfaces;
using MouseTracker.Domain;

namespace MouseTracker.Application.Services;
 
public class MouseTrackingService(IMouseMovementRepository mouseMovementRepository) : IMouseTrackingService
{
    public async Task SaveMouseDataAsync(MouseMovementDto data)
    {
        var entity = new MouseMovementData
        {
            MovementData = JsonSerializer.Serialize(data.MovementData)
        };
        
        await mouseMovementRepository.SaveMouseDataAsync(entity);
    }
}