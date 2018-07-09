using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<ApplicationUser> ChatUsers { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<UserChatRoom> UsersChatRooms { get; set; }

        public DbSet<ChatRoom> ChatRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

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
