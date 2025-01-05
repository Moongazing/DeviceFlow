using Microsoft.EntityFrameworkCore;
using Moongazing.DeviceFlow.Api.Context;
using Moongazing.DeviceFlow.Api.Entities;
using Moongazing.DeviceFlow.Api.Services.Energys;

public class EnergyDataService : IEnergyDataService
{
    private readonly IoTDbContext context;

    public EnergyDataService(IoTDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<EnergyData>> GetEnergyDataByDeviceIdAsync(int deviceId)
    {
        return await context.EnergyData
            .Where(ed => ed.DeviceId == deviceId)
            .OrderBy(ed => ed.Timestamp)
            .ToListAsync();
    }

    public async Task AddEnergyDataAsync(EnergyData energyData)
    {
        await context.EnergyData.AddAsync(energyData);
        await context.SaveChangesAsync();
    }
}
