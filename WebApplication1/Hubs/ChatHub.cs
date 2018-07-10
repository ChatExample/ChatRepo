using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using LiveChat.Models;
using LiveChat.Services;
using LiveChat.Services.Contracts;
using System.Linq;

namespace LiveChat.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService chatService;
        private UserManager<ApplicationUser> userManager;

        //static List<MessageDetail> CurrentMessage = new List<MessageDetail>();

        public ChatHub(IChatService chatService, UserManager<ApplicationUser> userManager)
        {
            this.chatService = chatService;
            this.userManager = userManager;

        }

        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            var userName = Context.User.Identity.Name;

            chatService.AddUserToConnectedUser(userName, connectionId);

            if (ChatService.ConnectedUsers.Count > 1)
            {
                var fromUser = ChatService.ConnectedUsers[1];
                var toUser = ChatService.ConnectedUsers[0];
                chatService.CheckForChatRoom(fromUser.UserID, toUser.UserID);
            }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            chatService.RemoveUserFromConnectedUser(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            await this.chatService.SaveMessage(message, user);
        }

        public void SendPrivateMessage(string toUserId, string message, string fromUserId, ChatHub chathub)
        {

            var toUser = ChatService.ConnectedUsers.FirstOrDefault(x => x.UserID == toUserId);
            var fromUser = ChatService.ConnectedUsers.FirstOrDefault(x => x.UserID == fromUserId);

            if (toUser != null && fromUser != null)
            {
                // send to 
                //Clients.Client(toUser.ConnectionId).SendAsync(fromUser.ConnectionId, fromUser.UserName, message);

                // send to caller user
                chathub.Clients.Caller.SendAsync(toUserId, fromUser.ConnectionId, message);
            }

        }
    }
}
