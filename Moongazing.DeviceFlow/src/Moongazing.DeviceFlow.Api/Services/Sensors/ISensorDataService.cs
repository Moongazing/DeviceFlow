using Moongazing.DeviceFlow.Api.Entities;

namespace Moongazing.DeviceFlow.Api.Services.Sensors;

public interface ISensorDataService
{
    Task<IEnumerable<SensorData>> GetSensorDataByDeviceIdAsync(int deviceId);
    Task AddSensorDataAsync(SensorData sensorData);
}