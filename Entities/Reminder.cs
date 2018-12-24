using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Remind.Entities
{
    public class Reminder
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Url { get; set; }

        public DateTime RemindAt { get; set; }

        [ForeignKey("ReminderFrequencyId")]
        public ReminderFrequency ReminderFrequency { get; set; }
        public int ReminderFrequencyId { get; set; }
    }
}
