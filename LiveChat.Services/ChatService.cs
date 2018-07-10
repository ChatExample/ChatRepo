using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveChat.Data;
using LiveChat.Models;
using LiveChat.Services.Contracts;

namespace LiveChat.Services
{
    public class ChatService : IChatService
    {
        public static IList<UserDetail> ConnectedUsers = new List<UserDetail>();
        private readonly ApplicationDbContext dbContext;

        public ChatService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task SaveMessage(string message, string userName)
        {
            var userId = dbContext.Users.Where(u => u.UserName == userName).Select(x => x.Id).SingleOrDefault();
            var msg = new Message() { ChatRoomId = 1, Description = message, SendOn = DateTime.Now, UserId = userId };


            await dbContext.Messages.AddAsync(msg);
            await dbContext.SaveChangesAsync();
        }

        public void AddUserToConnectedUser(string userName, string connectionId)
        {
            var userId = GetUserId(userName);
            if (!string.IsNullOrEmpty(userId))
            {
                var userDetail = new UserDetail { ConnectionId = connectionId, UserName = userName, UserID = userId };
                if (ConnectedUsers.Where(x => x.UserName == userName).SingleOrDefault() == null)
                {
                    ConnectedUsers.Add(userDetail);
                }
            }
        }

        public void RemoveUserFromConnectedUser(string ConnectionId)
        {
            var userForRemove = ConnectedUsers.Where(x => x.ConnectionId == ConnectionId).SingleOrDefault();
            ConnectedUsers.Remove(userForRemove);
        }

        public async Task CheckForChatRoom(string fromUserId, string toUserId)
        {
            var haveRoom = dbContext.ChatRooms.Where(x => x.Users.Any(t => t.UserId == toUserId) && x.Users.Any(f => f.UserId == fromUserId)).SingleOrDefault();

            if (haveRoom == null)
            {
                var fromUser = dbContext.Users.Where(x => x.Id == fromUserId).SingleOrDefault();
                var toUser = dbContext.Users.Where(x => x.Id == toUserId).SingleOrDefault();
                var listOfUser = new List<UserChatRoom>();

                var userChatRoom = new UserChatRoom();
                var userChatRooms1 = new UserChatRoom();

                var chatRoom = new ChatRoom()
                {
                    StartConversation = DateTime.Now,
                };

                userChatRoom.User = fromUser;
                userChatRoom.ChatRoom = chatRoom;

                userChatRooms1.User = toUser;
                userChatRooms1.ChatRoom = chatRoom;

                chatRoom.Users.Add(userChatRoom);
                chatRoom.Users.Add(userChatRooms1);

                await dbContext.ChatRooms.AddAsync(chatRoom);

                await dbContext.UsersChatRooms.AddAsync(userChatRoom);
                await dbContext.UsersChatRooms.AddAsync(userChatRooms1);

                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    var e = ex.Message;
                    throw;
                }

            }
        }

        private string GetUserId(string userName)
        {
            var userId = dbContext.Users.Where(u => u.UserName == userName).Select(x => x.Id).SingleOrDefault();

            return userId;
        }
    }
}
