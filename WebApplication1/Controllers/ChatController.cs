using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LiveChat.Hubs;
using LiveChat.Services;

namespace LiveChat.Controllers
{
    public class ChatController : Controller
    {
        private ChatHub chatHub;

        public ChatController(ChatHub chatHub)
        {
            this.chatHub = chatHub;
        }

        public IActionResult StartChat(string id)
        {
            //var result = Request.Params["paramName"];
            return RedirectToAction("ChatHub", new { id = id });
        }

        public IActionResult ChatHub(string id)
        {
            var username = User.Identity.Name;
            var fromUser= ChatService.ConnectedUsers.Where(x => x.UserName == username).SingleOrDefault();

            var toUser = ChatService.ConnectedUsers.Where(x => x.UserID == id).SingleOrDefault();
            chatHub.SendPrivateMessage(toUser.UserID, "Test", fromUser.UserID, this.chatHub);

            return Redirect("/index");
        }
    }
}