using System;
using TODO.Models;

namespace TODO.Contracts
{
    public interface ITask : IAssignement, ISaveable
    {
        IReminder Reminder { get; set; }
        Priority Priority { get; }
        string AdditionalPrintingInformation();
        //void Sort();
    }
}