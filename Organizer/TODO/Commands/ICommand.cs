using System.Collections.Generic;

namespace TODO.Engine
{
    public interface ICommand
    {
        string Execute();
        void TakeInput();
    }
}
