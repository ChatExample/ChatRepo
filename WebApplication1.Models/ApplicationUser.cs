using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LiveChat.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<Message> Messages { get; set; } = new List<Message>();

        public List<UserChatRoom> ChatRooms { get; set; } = new List<UserChatRoom>();
    }
}
