using Microsoft.AspNetCore.SignalR;

namespace NewsApi.Services
{
    public class NotificationsHub : Hub
    {
        public async Task BroadcastMessage(Object[] messages)
        {
            await this.Clients.All.SendAsync("message_received", messages);
        }

        public async Task xd(Object[] messages)
        {
            await this.Clients.All.SendAsync("message_received", messages);
        }
    }
}
