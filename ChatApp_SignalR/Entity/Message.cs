using System;
using System.Collections.Generic;

namespace ChatApp_SignalR.Entity;

public partial class Message
{
    public Message(string content, DateTime timeSent, int userId, int groupId)
    {
        Content = content;
        TimeSent = timeSent;
        UserId = userId;
        GroupId = groupId;
    }

    public int MessageId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime TimeSent { get; set; }

    public int UserId { get; set; }

    public int GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
