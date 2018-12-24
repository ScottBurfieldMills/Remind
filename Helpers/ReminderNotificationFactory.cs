using System;
using Remind.Services;

namespace Remind.Helpers
{
    public class ReminderNotificationFactory
    {
        public static IReminderNotificationService GetService(int notificationTypeId)
        {
            switch (notificationTypeId)
            {
                case (int)NotificationTypeEnum.PushBullet:
                    return new PushBulletNotificationService();
                case (int)NotificationTypeEnum.Email:
                default:
                    throw new NotImplementedException();

            }
        }
    }
}
