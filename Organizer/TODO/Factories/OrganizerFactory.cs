using System;
using System.Globalization;
using TODO.Contracts;
using TODO.Engine;
using TODO.Models;
using TODO.Utils.GlobalConstants;

namespace TODO.Factories
{
    public class OrganizerFactory : IOrganizerFactory
    {
        public INote CreateNote(string title, string content)
        {
            return new Note(title, content,false,DateTime.Now);
        }

        public INotebook CreateNotebook(string name)
        {
            return new Notebook(name);
        }

        public ITask CreateTask(string title, string priority, string description)
        {
            Priority resultPriority;
            if (!Enum.TryParse(priority, true, out resultPriority))
            {
                throw new ArgumentException("Wrong Priority");
            }

            return new Task(title, resultPriority, description,DateTime.Now);
        }

        public IUser CreateUser(string username, string password)
        {
            return new User(username, password);
        }

        public ILongTermTask CreateLongTermTask(string title, string priority, string end, string description)
        {
            Priority resultPriority;
            if (!Enum.TryParse(priority, true, out resultPriority))
            {
                throw new ArgumentException(Messages.WrongPriority());
            }

            return new LongTermTask(title, resultPriority,
                DateTime.Now,
                description,
                DateTime.ParseExact(end, Constants.Formats, CultureInfo.InvariantCulture, DateTimeStyles.None));
        }

        public ISubTask CreateSubTask(string title, string priority, string end, string description, string importancePercent)
        {
            Priority finalPriority;
            if (!Enum.TryParse(priority, true, out finalPriority))
            {
                throw new ArgumentException(Messages.WrongPriority());
            }

            DateTime dueDate = DateTime
                .ParseExact(end, Constants.Formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            if (DateTime.Compare(dueDate, EngineMaikaTI.CurrentLongTermTask.End) == 1)
            {
                throw new ArgumentException(Messages.WrongEndDate());
            }

            return new SubTask(title, finalPriority, description, dueDate, double.Parse(importancePercent),DateTime.Now);
        }

        public IReminder CreateReminder(DateTime dt,DateTime now)
        {
            TimeSpan wantedDateToRemind=dt.Subtract(now);
            return new Reminder(wantedDateToRemind);
        }
    }
}
