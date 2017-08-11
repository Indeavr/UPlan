using System;
using System.Collections.Generic;
using TODO.Contracts;

namespace TODO.Factories
{
    interface IOrganizerFactory
    {
        IUser CreateUser(string username, string password);

        INotebook CreateNotebook(string name);

        INote CreateNote(string title, string content);

        ITask CreateTask(string title, string description, string priority);

        ILongTermTask CreateLongTermTask(string title, string priority, string end, string description);

        ISubTask CreateSubTask(string title, string priority,
            string description, string end, string importancePercent = null);

        IReminder CreateReminder(DateTime dt);
    }
}
