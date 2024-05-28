using Microsoft.AspNetCore.SignalR;
using SignalR_Api.Models;
using System.Data;

namespace SignalR_Api.HubConfig
{
    public sealed class ChatHub: Hub
    {
 /*       public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Recieved Message", $"{Context.ConnectionId} has joined");
        }*/
        public async Task JoinChat(UserConnections conn)
        {
            await Clients.All.SendAsync("Recieved Message","admin", $"{conn.userName} has joined");
        }
        public async Task JoinSpecificChatRoom(UserConnections conn)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conn.chatRoom);
            await Clients.Group(conn.chatRoom)
                .SendAsync("Recieved Message", "admin", $"{conn.userName} has joined {conn.chatRoom}");
        }
    }
    
}
