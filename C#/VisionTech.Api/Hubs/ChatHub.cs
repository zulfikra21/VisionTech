using Microsoft.AspNetCore.SignalR;

namespace VisionTech.Api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            // Broadcast the message to all connected clients
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            var clientId = Context.ConnectionId;
            await Clients.All.SendAsync("UserConnected", clientId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var clientId = Context.ConnectionId;
            await Clients.All.SendAsync("UserDisconnected", clientId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
