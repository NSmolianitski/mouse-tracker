using MouseTracker.Domain;

namespace MouseTracker.Application.Interfaces;

public interface IMouseMovementRepository
{
    Task SaveMouseDataAsync(MouseMovementData mouseMovementData);
}