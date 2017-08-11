using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class ClearHistoryCommand : Command, ICommand
    {
        public override string Execute()
        {
            Writer.ClearHistory();

            return Messages.HistoryCleared();
        }

        public override void TakeInput()
        {
            
        }
    }
}
