using Microsoft.AspNetCore.Mvc;
using Moongazing.DeviceFlow.Api.Entities;
using Moongazing.DeviceFlow.Api.Services.Devices;

namespace Moongazing.DeviceFlow.Api.Controllers;

[ApiController]
[Route("api/devices")]
public class DeviceController : ControllerBase
{
    private readonly IDeviceService deviceService;

    public DeviceController(IDeviceService deviceService)
    {
        this.deviceService = deviceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDevices()
    {
        var devices = await deviceService.GetAllDevicesAsync();
        return Ok(devices);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDeviceById(int id)
    {
        var device = await deviceService.GetDeviceByIdAsync(id);
        if (device == null)
        {
            return NotFound();
        }
        return Ok(device);
    }

    [HttpPost]
    public async Task<IActionResult> AddDevice([FromBody] Device device)
    {
        await deviceService.AddDeviceAsync(device);
        return CreatedAtAction(nameof(GetDeviceById), new { id = device.Id }, device);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDevice(int id, [FromBody] Device updatedDevice)
    {
        var existingDevice = await deviceService.GetDeviceByIdAsync(id);
        if (existingDevice == null)
        {
            return NotFound();
        }

        await deviceService.UpdateDeviceAsync(updatedDevice);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDevice(int id)
    {
        var device = await deviceService.GetDeviceByIdAsync(id);
        if (device == null)
        {
            return NotFound();
        }

        await deviceService.DeleteDeviceAsync(id);
        return NoContent();
    }
}
