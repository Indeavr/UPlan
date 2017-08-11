using System;

namespace TODO.Contracts
{
    public interface ISubTask : ITask
    {
        double ImportancePercent { get; set; }
        DateTime DueDate { get; }
    }
}
