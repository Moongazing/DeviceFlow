using Microsoft.EntityFrameworkCore;
using Moongazing.DeviceFlow.Api.Context;
using Moongazing.DeviceFlow.Api.Entities;

namespace Moongazing.DeviceFlow.Api.Services.Devices;


public class DeviceService : IDeviceService
{
    private readonly IoTDbContext context;

    public DeviceService(IoTDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<Device>> GetAllDevicesAsync()
    {
        return await context.Devices
            .Include(d => d.SensorData)
            .Include(d => d.LocationData)
            .Include(d => d.EnergyData)
            .Include(d => d.HealthData)
            .Include(d => d.EventData)
            .Include(d => d.NetworkData)
            .Include(d => d.CommandData)
            .ToListAsync();
    }

    public async Task<Device> GetDeviceByIdAsync(int id)
    {
        var device = await context.Devices
            .Include(d => d.SensorData)!
            .Include(d => d.LocationData)!
            .Include(d => d.EnergyData)!
            .Include(d => d.HealthData)!
            .Include(d => d.EventData)!
            .Include(d => d.NetworkData)
            .Include(d => d.CommandData)
            .FirstOrDefaultAsync(d => d.Id == id);
        if (device is null)
        {
            throw new Exception("Not found.");
        }
        return device;
    }

    public async Task AddDeviceAsync(Device device)
    {
        await context.Devices.AddAsync(device);
        await context.SaveChangesAsync();
    }

    public async Task UpdateDeviceAsync(Device device)
    {
        context.Devices.Update(device);
        await context.SaveChangesAsync();
    }

    public async Task DeleteDeviceAsync(int id)
    {
        var device = await context.Devices.FindAsync(id);
        if (device != null)
        {
            context.Devices.Remove(device);
            await context.SaveChangesAsync();
        }
    }
}