using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LiveChat.Models;
using LiveChat.Services;

namespace LiveChat.Pages
{
    public class IndexModel : PageModel
    {
        public IList<UserDetail> ChatUsers { get { return ChatService.ConnectedUsers; }  }

        public void OnGet()
        {

        }
    }
}
