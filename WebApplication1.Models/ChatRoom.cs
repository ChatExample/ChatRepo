using System;
using System.Collections.Generic;

namespace LiveChat.Models
{
    public class ChatRoom
    {
        public ChatRoom()
        {
            this.Users = new List<UserChatRoom>();
            this.Messages = new List<Message>();
        }
        public int ChatRoomId { get; set; }

        public IList<UserChatRoom> Users { get; set; }

        public IList<Message> Messages { get; set; }

        public DateTime? StartConversation { get; set; }

        public DateTime? EndConversation { get; set; }
    }
}