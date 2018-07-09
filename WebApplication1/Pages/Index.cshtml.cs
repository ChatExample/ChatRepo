using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        public IList<UserDetail> ChatUsers { get { return ChatService.ConnectedUsers; }  }

        public void OnGet()
        {

        }
    }
}
