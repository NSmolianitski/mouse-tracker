namespace MouseTracker.Application.DTOs;

public record MouseMovementDto(MovementData[] MovementData);
public record MovementData(int X, int Y, long Timestamp);
