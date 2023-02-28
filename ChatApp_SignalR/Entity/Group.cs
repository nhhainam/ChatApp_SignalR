using System;
using System.Collections.Generic;

namespace ChatApp_SignalR.Entity;

public partial class Group
{
    public Group(string groupName)
    {
        GroupName = groupName;
    }

    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; } = new List<Message>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
