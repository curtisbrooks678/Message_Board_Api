using Microsoft.EntityFrameworkCore;
using System;

namespace MessageBoardApi.Models
{
    public class MessageBoardApiContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        
        public MessageBoardApiContext(DbContextOptions<MessageBoardApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Group>()
            .HasData(
                new Group { GroupId = 1, GroupName = "Group1! We did it! Amazing work!" } 
            );
        builder.Entity<Message>()
        .HasData(
            new Message { GroupId = 1, MessageId = 1, UserName = "user1", Content = "content1", DatePosted = new DateTime(2022, 1, 18, 12, 0, 0) },
            new Message { GroupId = 1, MessageId = 2, UserName = "user2",  Content = "content2", DatePosted = new DateTime(2021, 12, 25, 13, 0, 0) },
            new Message { GroupId = 1, MessageId = 3, UserName = "user3",  Content = "content3", DatePosted = new DateTime(2020, 12, 25, 13, 0, 0) },
            new Message { GroupId = 1, MessageId = 4, UserName = "user3",  Content = "content3", DatePosted = new DateTime(2020, 12, 25, 13, 0, 0) },
            new Message { GroupId = 1, MessageId = 5, UserName = "user3",  Content = "content3", DatePosted = new DateTime(2020, 12, 25, 13, 0, 0) },
            new Message { GroupId = 1, MessageId = 6, UserName = "user3",  Content = "content3", DatePosted = new DateTime(2020, 12, 25, 13, 0, 0) }
            );
        }
    }
}
