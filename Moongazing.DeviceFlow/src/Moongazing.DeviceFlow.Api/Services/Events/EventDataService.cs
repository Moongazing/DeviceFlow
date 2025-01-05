using Microsoft.EntityFrameworkCore;
using Moongazing.DeviceFlow.Api.Context;
using Moongazing.DeviceFlow.Api.Entities;

namespace Moongazing.DeviceFlow.Api.Services.Events
{

    public class EventDataService : IEventDataService
    {
        private readonly IoTDbContext context;

        public EventDataService(IoTDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<EventData>> GetEventDataByDeviceIdAsync(int deviceId)
        {
            return await context.EventData
                .Where(ed => ed.DeviceId == deviceId)
                .OrderBy(ed => ed.Timestamp)
                .ToListAsync();
        }

        public async Task AddEventDataAsync(EventData eventData)
        {
            await context.EventData.AddAsync(eventData);
            await context.SaveChangesAsync();
        }
    }
}