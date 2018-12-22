using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remind.Entities;
using Remind.Helpers;

namespace Remind.Services
{
    public interface INotificationService
    {
        List<NotificationType> GetTypes();
    }

    public class NotificationService : INotificationService
    {
        private readonly DataContext _context;

        public NotificationService(DataContext context)
        {
            _context = context;
        }

        public List<NotificationType> GetTypes()
        {
            return _context.NotificationTypes.ToList();
        }
    }
}
