using Microsoft.EntityFrameworkCore;
using Moongazing.DeviceFlow.Api.Context;
using Moongazing.DeviceFlow.Api.Entities;

namespace Moongazing.DeviceFlow.Api.Services.Sensors;

public class SensorDataService : ISensorDataService
{
    private readonly IoTDbContext context;

    public SensorDataService(IoTDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<SensorData>> GetSensorDataByDeviceIdAsync(int deviceId)
    {
        return await context.SensorData
            .Where(sd => sd.DeviceId == deviceId)
            .OrderBy(sd => sd.Timestamp)
            .ToListAsync();
    }

    public async Task AddSensorDataAsync(SensorData sensorData)
    {
        await context.SensorData.AddAsync(sensorData);
        await context.SaveChangesAsync();
    }
}