using Moongazing.DeviceFlow.Api.Entities;

namespace Moongazing.DeviceFlow.Api.Services.Energys;

public interface IEnergyDataService
{
    Task<IEnumerable<EnergyData>> GetEnergyDataByDeviceIdAsync(int deviceId);
    Task AddEnergyDataAsync(EnergyData energyData);
}