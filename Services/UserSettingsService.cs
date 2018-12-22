using System;
using Remind.Dtos;
using Remind.Entities;
using Remind.Helpers;

namespace Remind.Services
{
    public interface IUserSettingsService
    {
        User SetNotificationType(User user, NotificationTypeEnum notificationType);

        UserSettingsDto GetUserSettingsDashboard(User user);
    }

    public class UserSettingsService : IUserSettingsService
    {
        private readonly DataContext _context;

        public UserSettingsService(DataContext context)
        {
            _context = context;
        }

        public User SetNotificationType(User user, NotificationTypeEnum notificationType)
        {
            user.UserNotificationType = new UserNotificationType
            {
                NotificationTypeId = (int)notificationType
            };

            _context.SaveChanges();

            return user;
        }

        public UserSettingsDto GetUserSettingsDashboard(User user)
        {
            
            //userSettingsDto.SelectedReminderFrequencyId = user.UserNotificationTypeId; /*Enum.Parse(typeof(NotificationType), user.DefaultReminderFrequency);*/

            throw new NotImplementedException();
        }
    }
}
