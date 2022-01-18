using Microsoft.EntityFrameworkCore;
using System;

namespace MessageBoardApi.Models
{
    public class MessageBoardApiContext : DbContext
    {
        public MessageBoardApiContext(DbContextOptions<MessageBoardApiContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Message>()
            .HasData(
                new Message { MessageId = 1, UserName = "user1", Content = "content1", DatePosted = new DateTime(2022, 1, 18, 12, 0, 0), Group = "Beta" },
                new Message { MessageId = 2, UserName = "user2",  Content = "content2", DatePosted = new DateTime(2021, 12, 25, 13, 0, 0), Group = "Alpha" },
                new Message { MessageId = 3, UserName = "user3",  Content = "content3", DatePosted = new DateTime(2020, 12, 25, 13, 0, 0), Group = "Zeta" }
            );
        }
    }
}