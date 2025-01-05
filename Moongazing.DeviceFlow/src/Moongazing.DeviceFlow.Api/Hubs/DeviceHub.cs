using Microsoft.AspNetCore.SignalR;

namespace Moongazing.DeviceFlow.Api.Hubs
{
    public class DeviceHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
