namespace LiveChatDemo.Models
{
    public class UserChatRoom
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int ChatRoomId { get; set; }

        public ChatRoom ChatRoom { get; set; }
    }
}
