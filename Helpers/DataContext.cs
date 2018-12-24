using System.Linq;
using Microsoft.EntityFrameworkCore;
using Remind.Entities;

namespace Remind.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Reminder> Reminders { get; set; }

        public DbSet<NotificationType> NotificationTypes { get; set; }

        public DbSet<UserNotificationType> UserNotificationTypes { get; set; }

        public DbSet<ReminderFrequency> ReminderFrequency { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserNotificationType)
                .WithOne()
                .HasForeignKey<User>(u => u.UserNotificationTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
