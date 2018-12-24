using System.ComponentModel.DataAnnotations.Schema;

namespace Remind.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        public int? ReminderFrequencyId { get; set; }
        [ForeignKey("ReminderFrequencyId")]
        public ReminderFrequency ReminderFrequency { get; set; }

        public int UserNotificationTypeId { get; set; }
        [ForeignKey("UserNotificationTypeId")]
        public UserNotificationType UserNotificationType { get; set; }
    }
}
