using Microsoft.AspNetCore.Mvc;
using Moongazing.DeviceFlow.Api.Entities;
using Moongazing.DeviceFlow.Api.Services.Locations;

namespace Moongazing.DeviceFlow.Api.Controllers;

[ApiController]
[Route("api/location")]
public class LocationDataController : ControllerBase
{
    private readonly ILocationDataService locationDataService;

    public LocationDataController(ILocationDataService locationDataService)
    {
        this.locationDataService = locationDataService;
    }

    [HttpGet("{deviceId}")]
    public async Task<IActionResult> GetLocationDataByDeviceId(int deviceId)
    {
        var data = await locationDataService.GetLocationDataByDeviceIdAsync(deviceId);
        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> AddLocationData([FromBody] LocationData locationData)
    {
        await locationDataService.AddLocationDataAsync(locationData);
        return CreatedAtAction(nameof(GetLocationDataByDeviceId), new { deviceId = locationData.DeviceId }, locationData);
    }
}
