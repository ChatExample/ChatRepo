using System;

namespace LiveChatDemo.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        public string Description { get; set; }

        public DateTime SendOn { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}