using Remind.Entities;
using Remind.Helpers;
using Remind.Services;

namespace Remind.Jobs
{
    public class SendReminders
    {
        private readonly IReminderService _reminderService;

        public SendReminders(IReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        public void Send()
        {
            var reminders = _reminderService.GetRemindersToBeSent();

            foreach (var reminder in reminders)
            {
                SendNotification(reminder);

                reminder.ReminderSent = true;
                _reminderService.Update(reminder);
            }
        }

        private void SendNotification(Reminder reminder)
        {
            var notificationTypeId =
                reminder.User.UserNotificationType.NotificationTypeId;

            var service = ReminderNotificationFactory.GetService(notificationTypeId);

            service.Send(reminder);
        }
    }
}
