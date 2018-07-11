namespace LiveChatDemo.Database
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class LiveChatDbContext : DbContext
    {
        public LiveChatDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<ChatRoom> ChatRooms { get; set; }

        public DbSet<UserChatRoom> UsersChatRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserChatRoom>()
                .HasOne(u => u.User)
                .WithMany(c => c.ChatRooms)
                .HasForeignKey(fk => fk.UserId);

            builder.Entity<UserChatRoom>()
                .HasOne(c => c.ChatRoom)
                .WithMany(u => u.Users)
                .HasForeignKey(fk => fk.ChatRoomId);

            builder.Entity<UserChatRoom>()
                .HasKey(uc => new { uc.UserId, uc.ChatRoomId });

            base.OnModelCreating(builder);
        }
    }
}
