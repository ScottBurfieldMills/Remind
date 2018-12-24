using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remind.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string DefaultReminderFrequency { get; set; }
    }

    public class UpdateUserSettingsDto
    {
        public int DefaultReminderFrequency { get; set; }
    }

    public class UserSettingsDto
    {
        public int? SelectedReminderFrequencyId { get; set; }
        public List<NotificationTypeDto> PossibleNotificationTypes { get; set; }

        public int SelectedNotificationTypeId { get; set; }
        public List<ReminderFrequencyDto> PossibleReminderFrequencies { get; set; }
    }
}
