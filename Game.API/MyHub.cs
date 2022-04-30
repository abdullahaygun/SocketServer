using Microsoft.AspNetCore.SignalR;

namespace Game.API
{
    public class MyHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.All.SendAsync("getConnectionId", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.All.SendAsync("getDisconnectedConnectionId", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
