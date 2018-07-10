using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace LiveChat.Pages.Chat
{
    public class StartChatModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            public string FromUserId { get; set; }

            [Required]
            public string ToUserId { get; set; }

            [Required]
            public int ChatRoomId { get; set; }
        }

        public void OnGet()
        {
        }

        public ActionResult StartChat(string id)
        {
            return Redirect("/");
        }
    }
}