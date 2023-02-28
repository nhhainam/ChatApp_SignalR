using ChatApp_SignalR.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChatApp_SignalR.Pages
{
    public class IndexModel : PageModel
    {
        ChatAppContext context = new ChatAppContext();
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost(string username, string password)
        {
            User user = context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                user = new User();
                user.Username = username;
                user.Password = password;

                context.Users.Add(user);
                context.SaveChanges();
                Response.Redirect("Home");
            }
            else
            {
                Response.Redirect("Index");
            }
        }

    }
}