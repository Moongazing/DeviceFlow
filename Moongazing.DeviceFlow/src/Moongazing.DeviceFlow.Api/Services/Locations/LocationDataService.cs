using Microsoft.EntityFrameworkCore;
using Moongazing.DeviceFlow.Api.Context;
using Moongazing.DeviceFlow.Api.Entities;

namespace Moongazing.DeviceFlow.Api.Services.Locations;


public class LocationDataService : ILocationDataService
{
    private readonly IoTDbContext context;

    public LocationDataService(IoTDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<LocationData>> GetLocationDataByDeviceIdAsync(int deviceId)
    {
        return await context.LocationData
            .Where(ld => ld.DeviceId == deviceId)
            .OrderBy(ld => ld.Timestamp)
            .ToListAsync();
    }

    public async Task AddLocationDataAsync(LocationData locationData)
    {
        await context.LocationData.AddAsync(locationData);
        await context.SaveChangesAsync();
    }
}