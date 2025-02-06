using MouseTracker.Application.DTOs;

namespace MouseTracker.Application.Interfaces
{
    public interface IMouseTrackingService
    {
        Task SaveMouseDataAsync(MouseMovementDto data);
    }
}