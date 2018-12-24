using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using PushBulletNet;
using Remind.Entities;
using Remind.Helpers;

namespace Remind.Services
{
    public interface IReminderNotificationService
    {
        void Send(Reminder reminder);
    }

    public class PushBulletNotificationService : IReminderNotificationService
    {
        public void Send(Reminder reminder)
        {
            var message = $"Reminder: {reminder.Url}";

            var apiKey = reminder.User.UserNotificationType.Value;

            var client = new PushBulletClient(apiKey);

            client.PushAsync("Url Reminder", message, string.Empty).Wait();
        }
    }
}
