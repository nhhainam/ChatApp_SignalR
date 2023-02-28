using ChatApp_SignalR.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ChatApp_SignalR.Pages
{
    public class HomeModel : PageModel
    {
        ChatAppContext context = new ChatAppContext();
        public void OnGet()
        {
        }
        public void OnPost(string username, string password)
        {
            var user = context.Users.Where(x => x.Password == password).FirstOrDefault(x => x.Username == username);
            List<Group> groups = context.Groups.Include(x => x.Users).Where(g => g.Users.Contains(user)).ToList();
            ViewData["groups"] = groups;
            ViewData["user"] = user;
            List<User> users = context.Users.Where(u => u.Username.Equals(username) == false).ToList();
            ViewData["users"] = users;
        }

        public void OnPostGroup(string username, string password, List<int> userid, string groupname)
        {
            var user = context.Users.Where(x => x.Password == password).FirstOrDefault(x => x.Username == username);

            context.Groups.Add(new Group(groupname));
            context.SaveChanges();

            Group group = context.Groups.OrderByDescending(m => m.GroupId).FirstOrDefault();
            for (int i = 0; i < userid.Count; i++)
            {
                User userChat = context.Users.FirstOrDefault(u => u.UserId == userid[i]);
                group.Users.Add(userChat);
                context.SaveChanges();
            }

            group.Users.Add(user);
            context.SaveChanges();

            List<Group> groups = context.Groups.Include(x => x.Users).Where(g => g.Users.Contains(user)).ToList();
            ViewData["groups"] = groups;
            ViewData["user"] = user;
            List<User> users = context.Users.Where(u => u.Username.Equals(username) == false).ToList();
            ViewData["users"] = users;
        }
    }
}
