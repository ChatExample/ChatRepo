using System;
using System.Collections.Generic;

namespace LiveChatDemo.Models
{
    public class ChatRoom
    {
        public ChatRoom()
        {
            this.Users = new HashSet<UserChatRoom>();
        }

        public int ChatRoomId { get; set; }

        public ICollection<UserChatRoom> Users { get; set; }

        public DateTime? StartConversation { get; set; }

        public DateTime? EndConversation { get; set; }
    }
}