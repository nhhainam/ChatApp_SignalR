using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChatApp_SignalR.Entity;

public partial class ChatAppContext : DbContext
{
    public ChatAppContext()
    {
    }

    public ChatAppContext(DbContextOptions<ChatAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("server =NAM\\SQLEXPRESS; database =ChatApp_SignalR;uid=sa;pwd=123;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "nam", Password = "123"},
                new User { UserId = 2, Username = "hihi", Password = "123" },
                new User { UserId = 3, Username = "haha", Password = "123" }
            );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
