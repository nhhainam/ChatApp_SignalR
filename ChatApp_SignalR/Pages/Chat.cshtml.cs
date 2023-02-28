using ChatApp_SignalR.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ChatApp_SignalR.Pages
{
    public class ChatModel : PageModel
    {
        ChatAppContext context = new ChatAppContext();
        public void OnGet(int groupid, string username)
        {
            ViewData["username"] = username;
            Group group = context.Groups.Where(g => g.GroupId == groupid).FirstOrDefault();
            ViewData["group"] = group;
            ViewData["messages"] = context.Messages.Include(m => m.User).Where(m => m.GroupId == groupid).ToList();
        }
    }
}
