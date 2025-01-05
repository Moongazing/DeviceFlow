using Microsoft.AspNetCore.Mvc;
using Moongazing.DeviceFlow.Api.Entities;
using Moongazing.DeviceFlow.Api.Services.Sensors;

namespace Moongazing.DeviceFlow.Api.Controllers
{
    [ApiController]
    [Route("api/sensors")]
    public class SensorDataController : ControllerBase
    {
        private readonly ISensorDataService sensorDataService;

        public SensorDataController(ISensorDataService sensorDataService)
        {
            this.sensorDataService = sensorDataService;
        }

        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetSensorDataByDeviceId(int deviceId)
        {
            var data = await sensorDataService.GetSensorDataByDeviceIdAsync(deviceId);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddSensorData([FromBody] SensorData sensorData)
        {
            await sensorDataService.AddSensorDataAsync(sensorData);
            return CreatedAtAction(nameof(GetSensorDataByDeviceId), new { deviceId = sensorData.DeviceId }, sensorData);
        }
    }
}


