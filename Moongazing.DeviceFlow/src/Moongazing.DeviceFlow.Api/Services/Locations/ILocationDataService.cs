using Moongazing.DeviceFlow.Api.Entities;

namespace Moongazing.DeviceFlow.Api.Services.Locations
{
    public interface ILocationDataService
    {
        Task<IEnumerable<LocationData>> GetLocationDataByDeviceIdAsync(int deviceId);
        Task AddLocationDataAsync(LocationData locationData);
    }
}