﻿using System;
using Remind.Entities;
using System.Collections.Generic;
using System.Linq;
using Remind.Helpers;

namespace Remind.Services
{
    public interface IReminderService
    {
        Reminder GetById(int id);

        IEnumerable<Reminder> GetByUser(User user);
        IEnumerable<Reminder> GetByUser(int userId);

        Reminder Create(Reminder reminder);
    }

    public class ReminderService : IReminderService
    {
        private readonly DataContext _context;

        public ReminderService(DataContext context)
        {
            _context = context;
        }

        public Reminder GetById(int id)
        {
            var reminder = _context.Reminders.SingleOrDefault(x => x.Id == id);

            return reminder;
        }

        public IEnumerable<Reminder> GetByUser(User user)
        {
            var reminders = _context.Reminders.Where(x => x.User == user)
                .ToList();

            return reminders;
        }

        public IEnumerable<Reminder> GetByUser(int userId)
        {
            var reminders = _context.Reminders.Where(x => x.UserId == userId)
                .ToList();

            return reminders;
        }

        public Reminder Create(Reminder reminder)
        {
            // Validation
            if (reminder.User == null) throw new AppException("Reminder must be associated with a user");

            reminder.CreatedOn = DateTime.Now;  

            _context.Reminders.Add(reminder);
            _context.SaveChanges();

            return reminder;
        }
    }
}