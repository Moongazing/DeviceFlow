using Microsoft.AspNetCore.Mvc;
using Moongazing.DeviceFlow.Api.Entities;
using Moongazing.DeviceFlow.Api.Services.Events;

namespace Moongazing.DeviceFlow.Api.Controllers;

[ApiController]
[Route("api/events")]
public class EventDataController : ControllerBase
{
    private readonly IEventDataService eventDataService;

    public EventDataController(IEventDataService eventDataService)
    {
        this.eventDataService = eventDataService;
    }

    [HttpGet("{deviceId}")]
    public async Task<IActionResult> GetEventDataByDeviceId(int deviceId)
    {
        var data = await eventDataService.GetEventDataByDeviceIdAsync(deviceId);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> AddEventData([FromBody] EventData eventData)
    {
        await eventDataService.AddEventDataAsync(eventData);
        return CreatedAtAction(nameof(GetEventDataByDeviceId), new { deviceId = eventData.DeviceId }, eventData);
    }
}
