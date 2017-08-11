using System.Collections.Generic;
using TODO.Models;

namespace TODO.Contracts
{
    public interface IUser : ICredentials, ISaveable, ISortable
    {
        ICollection<INotebook> Notebooks { get; set; }
        ICollection<ITask> Tasks { get; set; }
        ICollection<ILongTermTask> LongTermTasks { get; set; }

        void AddNotebook(INotebook notebook);
        void AddLongTermTask(ILongTermTask longTermTask);
        void DeleteNotebook();
        void AddTask(ITask task);
    }
}
