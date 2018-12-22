using System.ComponentModel.DataAnnotations.Schema;

namespace Remind.Entities
{
    public class UserNotificationType
    {
        public int Id { get; set; }

        [ForeignKey("NotificationTypeId")]
        public NotificationType NotificationType { get; set; }
        public int NotificationTypeId { get; set; }

        public int UserId { get; set; }
    }
}
