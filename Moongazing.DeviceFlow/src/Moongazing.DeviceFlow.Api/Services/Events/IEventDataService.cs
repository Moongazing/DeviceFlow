using Moongazing.DeviceFlow.Api.Entities;

namespace Moongazing.DeviceFlow.Api.Services.Events
{
    public interface IEventDataService
    {
        Task<IEnumerable<EventData>> GetEventDataByDeviceIdAsync(int deviceId);
        Task AddEventDataAsync(EventData eventData);
    }
}