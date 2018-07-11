using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveChatDemo.Models
{
    public class User
    {
        public User()
        {
            this.Messages = new HashSet<Message>();
            this.ChatRooms = new List<UserChatRoom>();
        }

        public int UserId { get; set; }

        public string ConnectionId { get; set; }

        public string UserName { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<UserChatRoom> ChatRooms { get; set; }
    }
}
