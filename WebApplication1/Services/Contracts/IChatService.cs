using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services.Contracts
{
    public interface IChatService
    {
        Task SaveMessage(string userName, string message);

        void AddUserToConnectedUser(string userName, string connectionId);

        void RemoveUserFromConnectedUser(string ConnectionId);

        Task CheckForChatRoom(string fromUserId, string toUserId);
    }
}
