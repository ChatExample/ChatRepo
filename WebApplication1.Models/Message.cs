using System;

namespace LiveChat.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        public string Description { get; set; }

        public DateTime SendOn { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int ChatRoomId { get; set; }

        public ChatRoom ChatRoom { get; set; }
    }
}