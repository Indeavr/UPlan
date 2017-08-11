using System;
using System.Collections.Generic;

namespace TODO.Contracts
{
    public interface IReminder : ISaveable
    {
        TimeSpan MomentToRemind { get; }
        void Remind(object state);
    }
}
