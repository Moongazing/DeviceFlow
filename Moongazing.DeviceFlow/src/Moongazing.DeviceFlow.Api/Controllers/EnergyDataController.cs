using Microsoft.AspNetCore.Mvc;
using Moongazing.DeviceFlow.Api.Entities;
using Moongazing.DeviceFlow.Api.Services.Energys;

namespace Moongazing.DeviceFlow.Api.Controllers
{
    [ApiController]
    [Route("api/energy")]
    public class EnergyDataController : ControllerBase
    {
        private readonly IEnergyDataService energyDataService;

        public EnergyDataController(IEnergyDataService energyDataService)
        {
            this.energyDataService = energyDataService;
        }

        [HttpGet("{deviceId}")]
        public async Task<IActionResult> GetEnergyDataByDeviceId(int deviceId)
        {
            var data = await energyDataService.GetEnergyDataByDeviceIdAsync(deviceId);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddEnergyData([FromBody] EnergyData energyData)
        {
            await energyDataService.AddEnergyDataAsync(energyData);
            return CreatedAtAction(nameof(GetEnergyDataByDeviceId), new { deviceId = energyData.DeviceId }, energyData);
        }
    }
}
