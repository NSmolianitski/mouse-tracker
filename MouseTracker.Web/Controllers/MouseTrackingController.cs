using Microsoft.AspNetCore.Mvc;
using MouseTracker.Application.DTOs;
using MouseTracker.Application.Interfaces;

namespace MouseTracker.Controllers;

[ApiController]
[Route("api/mouse")]
public class MouseTrackingController(IMouseTrackingService mouseTrackingService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> TrackMouse([FromBody] MouseMovementDto data)
    {
        await mouseTrackingService.SaveMouseDataAsync(data);
        return Created();
    }
}