using ChatApp_SignalR.Entity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static ChatApp_SignalR.Entity.User;

namespace ChatApp_SignalR.Hubs
{
    public class ChatHub : Hub
    {
        ChatAppContext context = new ChatAppContext();

        public async Task SendMessage(string user, string message, string chatid)
        {
            User u = context.Users.FirstOrDefault(m => m.Username == user);
            Message m = new Message(message, DateTime.Now, u.UserId, int.Parse(chatid));
            context.Messages.Add(m);
            context.SaveChanges();
            await Clients.Group(chatid).SendAsync("ReceivedMess", user, message);
        }

        public void SetUserName(string user, string chatid)
        {
            UserList.AddUser(new User(user, Context.ConnectionId));
            JoinRoom(chatid);
        }

        public Task JoinRoom(string chatid)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, chatid);
        }

    }
}
