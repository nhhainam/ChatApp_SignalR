using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp_SignalR.Entity;

public partial class User
{
    public User()
    {
        Groups = new HashSet<Group>();
        Messages = new HashSet<Message>();
    }
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; } = new List<Message>();

    public virtual ICollection<Group> Groups { get; } = new List<Group>();

    [NotMapped]
    public string ConnectionId { get; set; }

    public User(string username, string connectionId)
    {
        Username = username;
        ConnectionId = connectionId;
    }
    public class UserList
    {
        public static List<User> Users = new List<User>();

        public static void AddUser(User user)
        {
            Users.Add(user);
        }

        public static User GetUser(string userName)
        {
            return Users.FirstOrDefault(x => x.Username.Equals(userName));
        }
    }
}
