using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Engine;
using TODO.Utils.GlobalConstants;

namespace TODO.Commands
{
    public class ListLongTermTaskCommand : Command, ICommand
    {
        public override string Execute()
        {
            string ltTaskTitle = base.Parameters[0];

            if (!FindTask(ltTaskTitle))
            {
                return Messages.NoLongTermTaskFound();
            }

            return EngineMaikaTI.LoggedUser.LongTermTasks
                .First(ltt => ltt.Title == ltTaskTitle)
                .ToString();
        }

        private bool FindTask(string ltTaskTitle)
        {
            if (EngineMaikaTI.LoggedUser.LongTermTasks
                .Any(ltt => ltt.Title == ltTaskTitle))
            {
                return true;
            }
            return false;
        }

        public override void TakeInput()
        {
            List<string> inputParameters = new List<string>();
            inputParameters.Add(this.ReadOneLine("Task name: "));
            this.Parameters = inputParameters;
        }
    }
}
